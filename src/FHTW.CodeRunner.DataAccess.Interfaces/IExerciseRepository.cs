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
        /// Gets the an instance of a exercise, which only has one version, written lanuage and programming language.
        /// </summary>
        /// <param name="id">The id of the exercise.</param>
        /// <param name="programming_language">The programming language as a string.</param>
        /// <param name="written_language">The written language as a string.</param>
        /// <param name="version">The version of the exercise. If version is -1 or not set, the newest version is used.</param>
        /// <returns>The exercise instance.</returns>
        public ExerciseInstance GetExerciseInstance(int id, string programming_language, string written_language, int version = -1);

        /// <summary>
        /// Checks if an exercise instance with a given version, programming language and writtenlanguage exists.
        /// </summary>
        /// <param name="id">The id of the exercise.</param>
        /// <param name="programming_language">The programming language as a string.</param>
        /// <param name="written_language">The written language as a string.</param>
        /// <param name="version">The version of the exercise. If version is -1 or not set, the newest version is used.</param>
        /// <returns>True if this exercise instance exists.</returns>
        public bool InstanceExists(int id, string programming_language, string written_language, int version = -1);
    }
}
