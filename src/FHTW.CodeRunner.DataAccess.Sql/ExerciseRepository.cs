// <copyright file="ExerciseRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NinjaNye.SearchExtensions;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    /// <summary>
    /// The repository for the <see cref="Exercise"/> entity.
    /// </summary>
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly CodeRunnerContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseRepository"/> class.
        /// </summary>
        /// <param name="dbcontext">The dbcontext to be used for the repository.</param>
        public ExerciseRepository(CodeRunnerContext dbcontext) => this.context = dbcontext;

        /// <inheritdoc/>
        public Exercise Save(Exercise exercise)
        {
            this.TemporarySave(exercise);

            var version = exercise.ExerciseVersion.FirstOrDefault();

            if (version == null)
            {
                throw new DalException("No exercise version to update");
            }

            version.TemporaryFlag = false;

            this.context.SaveChanges();

            return exercise;
        }

        /// <inheritdoc/>
        public Exercise TemporarySave(Exercise exercise)
        {
            int latest_version = this.GetLatestVersionNumber(exercise.Id);

            var version = exercise.ExerciseVersion.FirstOrDefault();

            if (version == null)
            {
                throw new DalException("No exercise version to update");
            }

            if (version.VersionNumber != latest_version)
            {
                throw new DalException($"TemporarySave only allowed for latest version. latest_version = {latest_version} version requested to be saved = {version.VersionNumber}");
            }

            bool is_temporary = this.context.ExerciseVersion
                    .Where(ev => ev.Id == exercise.ExerciseVersion.FirstOrDefault().Id)
                    .Select(ev => ev.TemporaryFlag)
                    .ToList()
                    .DefaultIfEmpty(true)
                    .First();

            // create new temporary version / reset ids
            if (!is_temporary || version.VersionNumber == 0)
            {
                version.Id = 0;
                version.VersionNumber += 1;
                version.ValidState = ValidState.NotChecked;
                version.TemporaryFlag = true;
                foreach (var el in version.ExerciseLanguage)
                {
                    el.Id = 0;
                    el.FkExerciseVersionId = 0;
                    el.FkExerciseHeaderId = 0;
                    el.FkExerciseHeader.Id = 0;
                    foreach (var eb in el.ExerciseBody)
                    {
                        eb.Id = 0;
                        eb.FkExerciseLanguageId = 0;
                        eb.FkTestSuiteId = 0;
                        eb.FkTestSuite.Id = 0;
                        foreach (var tc in eb.FkTestSuite.TestCase)
                        {
                            tc.Id = 0;
                            tc.FkTestSuiteId = 0;
                        }
                    }
                }
            }

            return this.CreateAndUpdate(exercise);
        }

        private void ResolveValueConflicts(Exercise exercise)
        {
            // set ids of existing questiontypes with no id.
            // this can happen if an exercise imported from moodle has the same questiontype, but of course no id.
            exercise.ExerciseVersion.ToList().ForEach(ev =>
            {
                ev.ExerciseLanguage.ToList().ForEach(el =>
                {
                    el.ExerciseBody.ToList().ForEach(eb =>
                    {
                        if (eb.FkTestSuite != null)
                        {
                            if (eb.FkTestSuite.FkQuestionType != null)
                            {
                                // get id if question type exists.
                                var questionType = this.context.QuestionType
                                    .AsNoTracking()
                                    .SingleOrDefault(qt => qt.Name == eb.FkTestSuite.FkQuestionType.Name);

                                if (questionType != null)
                                {
                                    eb.FkTestSuite.FkQuestionType.Id = questionType.Id;
                                    eb.FkTestSuite.FkQuestionType.FkProgrammingLanuageId = questionType.FkProgrammingLanuageId;
                                }
                            }
                        }
                    });
                });
            });

            exercise.ExerciseTag.ToList().ForEach(et =>
            {
                if (et.FkTag != null)
                {
                    int? id = this.context.Tag.AsNoTracking().SingleOrDefault(t => t.Name == et.FkTag.Name)?.Id;
                    if (id != null)
                    {
                        et.FkTagId = (int)id;
                        et.FkTag = null;
                    }
                }
            });
        }

        /// <inheritdoc/>
        public Exercise GetById(int id, int version = -1)
        {
            using var transaction = this.context.Database.BeginTransaction();

            if (version < 0)
            {
                version = this.GetLatestVersionNumber(id);
            }

            return this.context.Exercise
                .Where(e => e.Id == id)
                .Include(e => e.FkUser)
                .Include(e => e.ExerciseTag)
                    .ThenInclude(et => et.FkTag)
                .Include(e => e.ExerciseVersion.Where(ev => ev.VersionNumber == version))
                    .ThenInclude(v => v.FkUser)
                .Include(e => e.ExerciseVersion)
                    .ThenInclude(v => v.ExerciseLanguage)
                        .ThenInclude(el => el.FkWrittenLanguage)
                .Include(e => e.ExerciseVersion)
                    .ThenInclude(v => v.ExerciseLanguage)
                        .ThenInclude(el => el.FkExerciseHeader)
                .Include(e => e.ExerciseVersion)
                    .ThenInclude(v => v.ExerciseLanguage)
                        .ThenInclude(el => el.ExerciseBody)
                            .ThenInclude(eb => eb.FkTestSuite)
                                .ThenInclude(ts => ts.TestCase)
                .Include(e => e.ExerciseVersion)
                    .ThenInclude(v => v.ExerciseLanguage)
                        .ThenInclude(el => el.ExerciseBody)
                            .ThenInclude(eb => eb.FkProgrammingLanguage)
                .AsEnumerable()
                .FirstOrDefault();
        }

        /// <inheritdoc/>
        public List<MinimalExercise> GetMinimalList()
        {
            return this.context.Exercise.AsNoTracking()
                .Select(MinimalExercise.FromExercise)
                .ToList();
        }

        /// <inheritdoc/>
        public int GetLatestVersionNumber(int id)
        {
            var query = this.context.ExerciseVersion
                .Where(e => e.FkExerciseId == id);

            return query.Any() ? query.Max(e => e.VersionNumber) : 0;
        }

        /// <inheritdoc/>
        public ExerciseInstance GetExerciseInstance(int id, string programming_language, string written_language, int version = -1)
        {
            using var transaction = this.context.Database.BeginTransaction();

            if (version < 0)
            {
                version = this.GetLatestVersionNumber(id);
            }

            var instance = this.context.Exercise
                .Where(e => e.Id == id)
                .Include(e => e.ExerciseVersion)
                    .ThenInclude(v => v.ExerciseLanguage)
                        .ThenInclude(el => el.ExerciseBody)
                            .ThenInclude(eb => eb.FkTestSuite)
                                .ThenInclude(ts => ts.TestCase.OrderBy(c => c.OrderUsed))
                .Include(e => e.ExerciseVersion)
                    .ThenInclude(v => v.ExerciseLanguage)
                        .ThenInclude(el => el.ExerciseBody)
                            .ThenInclude(eb => eb.FkTestSuite)
                                .ThenInclude(ts => ts.FkQuestionType)
                .Include(e => e.ExerciseVersion)
                    .ThenInclude(v => v.ExerciseLanguage)
                        .ThenInclude(el => el.ExerciseBody)
                            .ThenInclude(eb => eb.FkProgrammingLanguage)
                .Select(e => new ExerciseInstance
                {
                    Id = e.Id,
                    Title = e.Title,
                    Created = e.Created,
                    User = e.FkUser,
                    WrittenLanguage = e.ExerciseVersion
                        .SingleOrDefault(v => v.VersionNumber == version)
                        .ExerciseLanguage
                            .SingleOrDefault(el => el.FkWrittenLanguage.Name == written_language)
                                .FkWrittenLanguage.Name,
                    Version = e.ExerciseVersion
                        .SingleOrDefault(v => v.VersionNumber == version),
                    Header = e.ExerciseVersion
                        .SingleOrDefault(v => v.VersionNumber == version)
                        .ExerciseLanguage
                            .SingleOrDefault(el => el.FkWrittenLanguage.Name == written_language)
                                .FkExerciseHeader,
                    Body = e.ExerciseVersion
                        .SingleOrDefault(v => v.VersionNumber == version)
                        .ExerciseLanguage
                            .SingleOrDefault(el => el.FkWrittenLanguage.Name == written_language)
                                .ExerciseBody
                                    .SingleOrDefault(eb => eb.FkProgrammingLanguage.Name == programming_language),
                    TagList = e.ExerciseTag
                        .Select(et => new Tag()
                        {
                            Id = et.FkTagId,
                            Name = et.FkTag.Name,
                        })
                        .ToList(),
                }).FirstOrDefault();

            if (instance == null)
            {
                throw new DalException($"No exercise with id = {id} found");
            }

            if (instance.Version == null)
            {
                throw new DalException($"exercise with id = {id} has no version = {version}");
            }

            if (instance.WrittenLanguage == null || instance.Header == null)
            {
                throw new DalException($"exercise with id = {id} has no written language = {written_language}");
            }

            if (instance.Body == null)
            {
                throw new DalException($"exercise with id = {id} has no programming language = {programming_language}");
            }

            return instance;
        }

        /// <inheritdoc/>
        public bool Exists(Exercise exercise)
        {
            return this.context.Exercise.Any(e => e == exercise);
        }

        /// <inheritdoc/>
        public QuestionType GetQuestionType(string questiontype)
        {
            return this.context.QuestionType
                    .AsNoTracking()
                    .Include(qt => qt.FkProgrammingLanguage)
                    .SingleOrDefault(qt => qt.Name == questiontype);
        }

        /// <inheritdoc/>
        public List<MinimalExercise> SearchAndFilter(string searchTerm, string programming_language, string written_language)
        {
            if (searchTerm is null || programming_language is null || written_language is null)
            {
                throw new ArgumentNullException("searchterms and filters should not be null, use \"\" for wildcard search");
            }

            // caseinsensitive search not available for iqueryiable
            // because of tolower is used, but is probably inefficient
            HashSet<int> ids = this.context.ExerciseBody
                .Search(
                        b => b.Description.ToLower(),
                        b => b.Feedback.ToLower(),
                        b => b.Hint.ToLower(),
                        b => b.FkExerciseLanguage.FkExerciseVersion.FkUser.Name.ToLower(),
                        b => b.FkExerciseLanguage.FkExerciseVersion.FkExercise.Title.ToLower())
                    .Containing(searchTerm.ToLower())
                .Select(v => v.FkExerciseLanguage.FkExerciseVersion.FkExerciseId)
                .ToHashSet();

            HashSet<int> exercise_ids_from_tag_search = this.context.ExerciseTag
                .Search(t => t.FkTag.Name.ToLower())
                    .Containing(searchTerm.ToLower())
                .Select(et => et.FkExerciseId)
                .ToHashSet();

            // both search in exercise and tags are part of the text search
            ids.UnionWith(exercise_ids_from_tag_search);

            // apply filter only if values are set
            if (programming_language != string.Empty && written_language != string.Empty)
            {
                HashSet<int> filter_ids = this.context.ExerciseBody
                    .Search(b => b.FkProgrammingLanguage.Name)
                        .Containing(programming_language)
                    .Search(b => b.FkExerciseLanguage.FkWrittenLanguage.Name)
                        .Containing(written_language)
                    .Select(v => v.FkExerciseLanguage.FkExerciseVersion.FkExerciseId)
                    .ToHashSet();

                // filters are applied
                ids.IntersectWith(filter_ids);
            }

            List<MinimalExercise> result;

            if (ids.Count > 0)
            {
                result = this.context.Exercise
                    .Where(e => ids.Contains(e.Id))
                    .Select(MinimalExercise.FromExercise)
                    .ToList();
            }
            else
            {
                result = new List<MinimalExercise>();
            }

            return result;
        }

        private Exercise CreateAndUpdate(Exercise exercise)
        {
            var version = exercise.ExerciseVersion;

            if (exercise.FkUserId == 0)
            {
                throw new DalException("exercise userid must be set");
            }

            if (version == null)
            {
                throw new DalException("at least one version entity should be present");
            }

            if (version.Count != 1)
            {
                throw new DalException($"only one version should be present when updating exercise. Count = {version.Count}");
            }

            try
            {
                using var transaction = this.context.Database.BeginTransaction();

                this.ResolveValueConflicts(exercise);

                // add everything new
                this.context.ChangeTracker.TrackGraph(exercise, e =>
                {
                    if (e.Entry.IsKeySet)
                    {
                        e.Entry.State = EntityState.Unchanged;
                    }
                    else
                    {
                        e.Entry.State = EntityState.Added;
                    }
                });

                this.context.SaveChanges();

                // update existing
                this.context.ChangeTracker.TrackGraph(exercise, e =>
                {
                    if (e.Entry.IsKeySet)
                    {
                        e.Entry.State = EntityState.Modified;
                    }
                });

                this.context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new DalException("Updating exercise failed", e);
            }

            return exercise;
        }
    }
}
