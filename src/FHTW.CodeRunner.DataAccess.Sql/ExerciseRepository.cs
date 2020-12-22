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
    public class ExerciseRepository : SimpleRepository<Exercise, CodeRunnerContext>, IExerciseRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseRepository"/> class.
        /// </summary>
        /// <param name="dbcontext">The dbcontext to be used for the repository.</param>
        /// <param name="logger">The logger.</param>
        public ExerciseRepository(CodeRunnerContext dbcontext, ILogger<ExerciseRepository> logger)
            : base(dbcontext, logger)
        {
        }

        /// <inheritdoc/>
        public Exercise Create(Exercise exercise)
        {
            this.Logger.LogDebug("Creating exercise: ", exercise);

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
                this.Logger.LogError("Exception thrown in ExerciseRepository.Create()", e);
                throw new DalException("Creating exercise failed", e);
            }

            return exercise;
        }

        /// <inheritdoc/>
        public new Exercise Update(Exercise exercise)
        {
            this.Logger.LogDebug("Updating exercise: ", exercise);

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
                this.Logger.LogError("Exception thrown in ExerciseRepository.Create()", e);
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
            return this.Context.Exercise
                /*
                .Include(e => e.ExerciseTag)
                .Include(e => e.FkUser)
                .Include(e => e.ExerciseVersion
                    .Where(v => v.VersionNumber == this.GetLatestVersionNumber(v.Id)))
                    .ThenInclude(v => v.ExerciseLanguage)
                        .ThenInclude(el => el.FkWrittenLanguage)
                .Include(e => e.ExerciseVersion
                    .Where(v => v.VersionNumber == this.GetLatestVersionNumber(v.Id)))
                    .ThenInclude(v => v.ExerciseLanguage)
                        .ThenInclude(el => el.ExerciseBody)
                            .ThenInclude(eb => eb.FkProgrammingLanguage)*/
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
                    writtenLanguageList = m.ExerciseVersion
                        .Where(v => v.VersionNumber == m.ExerciseVersion.Max(vn => vn.VersionNumber))
                        .FirstOrDefault().ExerciseLanguage
                        .Select(el => new WrittenLanguage()
                        {
                            Id = el.FkWrittenLanguageId,
                            Name = el.FkWrittenLanguage.Name,
                        })
                        .ToList(),
                    programmingLanguageList = m.ExerciseVersion
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
    }
}
