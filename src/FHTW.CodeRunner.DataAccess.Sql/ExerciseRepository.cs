﻿// <copyright file="ExerciseRepository.cs" company="FHTW CodeRunner">
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
    public class ExerciseRepository : SimpleRepository<Exercise, CodeRunnerContext>, IExerciseRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseRepository"/> class.
        /// </summary>
        /// <param name="dbcontext">The dbcontext to be used for the repository.</param>
        /// <param name="logger">The logger.</param>
        public ExerciseRepository(CodeRunnerContext dbcontext)
            : base(dbcontext)
        {
        }

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
                using var transaction = this.Context.Database.BeginTransaction();

                this.Context.Exercise.Add(exercise);
                this.Save();

                ExerciseVersion exerciseVersion = new ExerciseVersion();

                exerciseVersion.LastModified = exercise.Created;
                exerciseVersion.FkUserId = exercise.FkUserId;
                exerciseVersion.FkExerciseId = exercise.Id;
                exerciseVersion.VersionNumber = 0; // TODO
                exerciseVersion.ValidFlag = false;

                this.Context.ExerciseVersion.Add(exerciseVersion);
                this.Save();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new DalException("Creating exercise failed", e);
            }

            return exercise;
        }

        /// <inheritdoc/>
        public new Exercise Update(Exercise exercise)
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
                using var transaction = this.Context.Database.BeginTransaction();

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
                this.Context.ChangeTracker.TrackGraph(exercise, e =>
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
                this.Context.ChangeTracker.TrackGraph(exercise, e =>
                {
                    if (e.Entry.IsKeySet)
                    {
                        e.Entry.State = EntityState.Modified;
                    }
                });

                this.Save();

                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new DalException("Updating exercise failed", e);
            }

            return exercise;
        }

        /// <inheritdoc/>
        public override Exercise GetById(int id)
        {
            return this.Context.Exercise
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
            return this.Context.Exercise.AsNoTracking()
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
                })
                .ToList();
        }

        /// <inheritdoc/>
        public int GetLatestVersionNumber(int id)
        {
            return this.Context.ExerciseVersion
                .Where(e => e.FkExerciseId == id)
                .Max(e => e.VersionNumber);
        }

        /// <inheritdoc/>
        public ExerciseInstance GetExerciseInstance(int id, string programming_language, string written_language, int version = -1)
        {
            if (version == -1)
            {
                version = this.GetLatestVersionNumber(id);
            }

            return this.Context.Exercise.AsNoTracking()
                .Where(e => e.Id == id)
                .Include(e => e.ExerciseVersion)
                    .ThenInclude(v => v.ExerciseLanguage)
                        .ThenInclude(el => el.ExerciseBody)
                            .ThenInclude(eb => eb.FkTestSuite)
                                .ThenInclude(ts => ts.TestCase)
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
                        .Single(v => v.VersionNumber == version)
                        .ExerciseLanguage
                            .Single(el => el.FkWrittenLanguage.Name == written_language)
                                .FkWrittenLanguage.Name,
                    Version = e.ExerciseVersion
                        .Single(v => v.VersionNumber == version),
                    Header = e.ExerciseVersion
                        .Single(v => v.VersionNumber == version)
                        .ExerciseLanguage
                            .Single(el => el.FkWrittenLanguage.Name == written_language)
                                .FkExerciseHeader,
                    Body = e.ExerciseVersion
                        .Single(v => v.VersionNumber == version)
                        .ExerciseLanguage
                            .Single(el => el.FkWrittenLanguage.Name == written_language)
                                .ExerciseBody
                                    .Single(eb => eb.FkProgrammingLanguage.Name == programming_language),
                })
                .FirstOrDefault();
        }
    }
}
