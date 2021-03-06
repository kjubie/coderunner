// <copyright file="IExerciseLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Entities;

namespace FHTW.CodeRunner.BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface for dealing with exercise actions.
    /// </summary>
    public interface IExerciseLogic
    {
        /// <summary>
        /// Function for retrieving a full exercise.
        /// </summary>
        /// <param name="id">The id of the exercise.</param>
        /// <param name="version">The version of the exercise.</param>
        /// <returns>The found exercise.</returns>
        Exercise GetExerciseById(int id, int version);

        /// <summary>
        /// Function for retrieving data needed in the GUI when creating an exercise.
        /// </summary>
        /// <returns>Data for the frontend.</returns>
        ExerciseCreatePreparation GetExerciseCreatePreparation();

        /// <summary>
        /// Function for retrieving a list of exercises.
        /// </summary>
        /// <returns>List of exercises in a minmal version.</returns>
        List<MinimalExercise> GetMinimalExerciseList();

        /// <summary>
        /// Function for saving an exercise.
        /// </summary>
        /// <param name="exercise">The incoming exercise.</param>
        public void SaveExercise(Exercise exercise);

        /// <summary>
        /// Function for saving an exercise temporarily.
        /// </summary>
        /// <param name="exercise">The incoming exercise.</param>
        /// <returns>The found exercise.</returns>
        public Exercise TemporarySaveExercise(Exercise exercise);

        /// <summary>
        /// Function for validating an exercise.
        /// </summary>
        /// <param name="exercise">The incoming exercise.</param>
        /// <param name="exerciseId">The id of the exercise.</param>
        /// <param name="exerciseVersion">The version of the exercise.</param>
        public void ValidateExercise(Exercise exercise, int exerciseId, int exerciseVersion);

        /// <summary>
        /// Function for filtering exercises.
        /// </summary>
        /// <param name="searchObject">The search options for filtering.</param>
        /// <returns>List of exercises in a minmal version.</returns>
        public List<MinimalExercise> SearchAndFilter(SearchObject searchObject);
    }
}
