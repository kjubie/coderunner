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
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly CodeRunnerContext context;

        public ExerciseRepository(CodeRunnerContext dbcontext) => this.context = dbcontext;

        /// <inheritdoc/>
        Exercise IExerciseRepository.GetExerciseById(int id)
        {
            return this.context.Exercise
                    .Include(e => e.FkUser)
                    .Include(e => e.ExerciseVersion)
                        .ThenInclude(v => v.FkUser)
                    .Include(e => e.ExerciseVersion)
                        .ThenInclude(v => v.ExerciseLanguage)
                            .ThenInclude(el => el.FkWrittenLanguage)
                            .AsEnumerable()
                    .FirstOrDefault(e => e.Id == id);

            // throw new NotImplementedException();
        }
    }
}
