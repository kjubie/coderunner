// <copyright file="IExerciseRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
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
        /// Requires:
        ///     - only one ExerciseVersion should be present.
        ///     - exercise Id and exercise userId should be set.
        /// </summary>
        /// <param name="exercise">the exercise with correct id.</param>
        /// <returns>returns the updated exercise.</returns>
        public new Exercise Update(Exercise exercise);

        /// <summary>
        /// Gets a list of exercises containing:
        ///     - tagList.
        ///     - writtenLanguageList.
        ///     - programmingLanguageList.
        /// </summary>
        /// <returns>The list of exercises.</returns>
        public List<MinimalExercise> GetMinimalList();

        /// <summary>
        /// Gets the latest version number of a given exercise.
        /// </summary>
        /// <param name="id">The id of the exercise</param>
        /// <returns>The lateset version nummber.</returns>
        public int GetLatestVersionNumber(int id);

        /// <summary>
        /// test.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ExerciseInstance GetExerciseInstance(int id, int version, string programming_language, string written_language);
    }
}
