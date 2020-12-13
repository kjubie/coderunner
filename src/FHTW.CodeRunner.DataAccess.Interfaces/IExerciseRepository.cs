// <copyright file="IExerciseRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using FHTW.CodeRunner.DataAccess.Entities;

namespace FHTW.CodeRunner.DataAccess.Interfaces
{
    public interface IExerciseRepository : ISimpleRepository<Exercise>
    {
        /// <summary>
        /// Creates an empty exercise.
        /// </summary>
        /// <param name="exercise">exercise containing title, date and user id. The id has to be 0.</param>
        /// <returns>returns the Exercise with id and version set.</returns>
        public Exercise Create(Exercise exercise);

        /// <summary>
        /// Updates an already existing exercise.
        /// </summary>
        /// <param name="exercise">the exercise with correct id.</param>
        /// <returns>returns the updated exercise.</returns>
        public new Exercise Update(Exercise exercise);
    }
}
