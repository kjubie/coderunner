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
        public Exercise Create(Exercise exercise)
        {
            if (exercise.Id != 0)
            {
                throw new DalException($"Attempting to create exercise with Id = {exercise.Id}. Id must be 0");
            }

            // reset undesired properties
            exercise.Rating = null;
            exercise.FkUser = null;
            exercise.Difficulty = null;
            exercise.ExerciseTag = null;
            exercise.CollectionExercise = null;
            exercise.Comment = null;

            try
            {
                using var transaction = this.context.Database.BeginTransaction();

                this.context.Exercise.Add(exercise);
                this.context.SaveChanges();

                ExerciseVersion exerciseVersion = new ExerciseVersion();

                exerciseVersion.LastModified = exercise.Created;
                exerciseVersion.FkUserId = exercise.FkUserId;
                exerciseVersion.FkExerciseId = exercise.Id;
                exerciseVersion.VersionNumber = 0; // TODO maybe not start with zero ?
                exerciseVersion.ValidState = ValidState.NotChecked;

                this.context.ExerciseVersion.Add(exerciseVersion);
                this.context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new DalException("Creating exercise failed", e);
            }

            return exercise;
        }

        /// <inheritdoc/>
        public Exercise Update(Exercise exercise)
        {
            var version = exercise.ExerciseVersion;

            if (exercise.Id == 0)
            {
                throw new DalException("exercise should already exist");
            }

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

                // set known ids.
                exercise.ExerciseTag = exercise.ExerciseTag.Select(e =>
                {
                    e.FkExerciseId = exercise.Id;
                    return e;
                }).ToList();

                exercise.ExerciseVersion = exercise.ExerciseVersion.Select(e =>
                {
                    e.FkExerciseId = exercise.Id;
                    e.FkUserId = exercise.FkUserId;
                    e.ExerciseLanguage = e.ExerciseLanguage.Select(el =>
                    {
                        el.FkExerciseVersionId = e.Id;
                        return el;
                    }).ToList();

                    return e;
                }).ToList();

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

        /// <inheritdoc/>
        public Exercise CreateAndUpdate(Exercise exercise)
        {
            if (exercise.Id == 0)
            {
                var inserted_exercise = this.Create(exercise);
            }

            return this.Update(exercise);
        }

        /// <inheritdoc/>
        public Exercise GetById(int id)
        {
            return this.context.Exercise
                .Include(e => e.FkUser)
                .Include(e => e.ExerciseTag)
                    .ThenInclude(et => et.FkTag)
                .Include(e => e.ExerciseVersion)
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
                .FirstOrDefault(e => e.Id == id);
        }

        /// <inheritdoc/>
        public List<MinimalExercise> GetMinimalList()
        {
            return this.context.Exercise.AsNoTracking()
                .Select(m => new MinimalExercise
                {
                    Id = m.Id,
                    Title = m.Title,
                    Created = m.Created,
                    User = m.FkUser,
                    TagList = m.ExerciseTag
                        .Select(et => new Tag()
                        {
                            Id = et.FkTagId,
                            Name = et.FkTag.Name,
                        })
                        .ToList(),
                    WrittenLanguageList = m.ExerciseVersion
                        .Where(v => v.VersionNumber == m.ExerciseVersion.Max(vn => vn.VersionNumber))
                        .FirstOrDefault().ExerciseLanguage
                        .Select(el => new WrittenLanguage()
                        {
                            Id = el.FkWrittenLanguageId,
                            Name = el.FkWrittenLanguage.Name,
                        })
                        .ToList(),
                    ProgrammingLanguageList = m.ExerciseVersion
                        .Where(v => v.VersionNumber == m.ExerciseVersion.Max(vn => vn.VersionNumber))
                        .FirstOrDefault().ExerciseLanguage
                        .SelectMany(el => el.ExerciseBody.Select(eb => new ProgrammingLanguage()
                        {
                            Id = eb.FkProgrammingLanguageId,
                            Name = eb.FkProgrammingLanguage.Name,
                        }))
                        .ToHashSet(new ProgrammingLanguageComparator())
                        .ToList(),
                    VersionList = m.ExerciseVersion
                        .Select(v => v.VersionNumber)
                        .ToList(),
                })
                .ToList();
        }

        /// <inheritdoc/>
        public int GetLatestVersionNumber(int id)
        {
            var query = this.context.ExerciseVersion
                .Where(e => e.FkExerciseId == id);

            return query.Any() ? query.Max(e => e.VersionNumber) : throw new DalException($"No versions for exercise id = {id} found");
        }

        /// <inheritdoc/>
        public ExerciseInstance GetExerciseInstance(int id, string programming_language, string written_language, int version = -1)
        {
            using var transaction = this.context.Database.BeginTransaction();

            if (version == -1)
            {
                version = this.GetLatestVersionNumber(id);
            }

            var instance = this.context.Exercise
                .Where(e => e.Id == id)
                .Include(e => e.ExerciseVersion)
                    .ThenInclude(v => v.ExerciseLanguage)
                        .ThenInclude(el => el.ExerciseBody)
                            .ThenInclude(eb => eb.FkTestSuite)
                                .ThenInclude(ts => ts.TestCase)
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
        public bool InstanceExists(int id, string programming_language, string written_language, int version = -1)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Exists(Exercise exercise)
        {
            return this.context.Exercise.Any(e => e == exercise);
        }
    }
}
