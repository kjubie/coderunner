// <copyright file="ExerciseRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Linq;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public ExerciseRepository(CodeRunnerContext dbcontext)
            : base(dbcontext)
        {
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
