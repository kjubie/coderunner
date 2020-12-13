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

            if (version.Count != 1)
            {
                this.Logger.LogError("more than one version in exercise, on update");
                throw new DalException("only one version should be present when updating exercise");
            }

            try
            {
                using var transaction = this.Context.Database.BeginTransaction();

                exercise.ExerciseTag = exercise.ExerciseTag.Select(e =>
                {
                    e.FkExerciseId = exercise.Id;
                    this.Context.ExerciseTag.Add(e);
                    return e;
                }).ToList();

                this.Save();

                exercise.ExerciseVersion = exercise.ExerciseVersion.Select(e =>
                {
                    e.FkExerciseId = exercise.Id;
                    e.FkUserId = exercise.FkUserId;
                    e.ExerciseLanguage = e.ExerciseLanguage.Select(l =>
                    {
                        l.FkExerciseVersionId = e.Id;

                        // set ExerciseHeader
                        if (l.FkExerciseHeaderId == 0)
                        {
                            this.Context.ExerciseHeader.Add(l.FkExerciseHeader);
                        }else
                        {
                            this.Context.ExerciseHeader.Update(l.FkExerciseHeader);
                        }

                        this.Save();

                        l.FkExerciseHeaderId = l.FkExerciseHeader.Id;

                        // set ExerciseBody
                        l.ExerciseBody = l.ExerciseBody.Select(b =>
                        {
                            if (b.FkTestSuiteId == 0)
                            {
                                this.Context.TestSuite.Add(b.FkTestSuite);
                            }
                            else
                            {
                                this.Context.TestSuite.Update(b.FkTestSuite);
                            }

                            this.Save();

                            b.FkTestSuiteId = b.FkTestSuite.Id;

                            b.FkTestSuite.TestCase = b.FkTestSuite.TestCase.Select(tc =>
                            {
                                tc.FkTestSuiteId = b.FkTestSuiteId;
                                if (tc.Id == 0)
                                {
                                    this.Context.TestCase.Add(tc);
                                }else
                                {
                                    this.Context.TestCase.Update(tc);
                                }
                                return tc;
                            }).ToList();

                            this.Context.TestSuite.Update(b.FkTestSuite);

                            return b;
                        }).ToList();

                        return l;
                    }).ToList();
                    return e;
                }).ToList();


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
    }
}
