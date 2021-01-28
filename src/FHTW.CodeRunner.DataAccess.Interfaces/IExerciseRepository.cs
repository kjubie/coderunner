// <copyright file="IExerciseRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using FHTW.CodeRunner.DataAccess.Entities;

namespace FHTW.CodeRunner.DataAccess.Interfaces
{
    /// <summary>
    /// The interface for the ExerciseRepository.
    /// It provides methods to create, update and query exercises.
    /// </summary>
    public interface IExerciseRepository
    {
        /// <summary>
        /// Retrieves the entity from the data provider with the corresponding id and version.
        /// If the version is less than 0 the latest version is queried.
        /// </summary>
        /// <param name="id">The id of the exercise.</param>
        /// <param name="version">The version of the exercise (default -1).</param>
        /// <returns>The instance of the entity.</returns>
        Exercise GetById(int id, int version = -1);

        /// <summary>
        /// Saves the exercise as a new TEMPORARY version.
        /// This means that subsequent save don't increase the version.
        /// </summary>
        /// <param name="exercise">the exercise.</param>
        /// <returns>returns inserted exercise.</returns>
        public Exercise TemporarySave(Exercise exercise);

        /// <summary>
        /// Saves the exercise as a new version.
        /// </summary>
        /// <param name="exercise">the exercise.</param>
        /// <returns>returns inserted exercise.</returns>
        public Exercise Save(Exercise exercise);

        /// <summary>
        /// Gets a list of exercises containing:
        ///     - tagList.
        ///     - writtenLanguageList.
        ///     - programmingLanguageList.
        /// </summary>
        /// <returns>The list of exercises.</returns>
        public List<MinimalExercise> GetMinimalList();

        /// <summary>
        /// Searches in titel, description, tags, user, feedback and hint.
        /// Filters by programming and written lanugage.
        /// Throws ArgumentNullException if any parameter is null.
        /// </summary>
        /// <param name="searchTerm">The searchterm to search for.</param>
        /// <param name="programming_lanmguage">
        ///     The programming language.
        ///     Use String.Empty to leave out this filter.
        /// </param>
        /// <param name="written_language">
        ///     The written language.
        ///     Use String.Empty to leave out this filter.
        /// </param>
        /// <returns>List of Minimalexercises that contain the searchterm and filters.</returns>
        public List<MinimalExercise> SearchAndFilter(string searchTerm, string programming_lanmguage, string written_language);

        /// <summary>
        /// Gets the latest version number of a given exercise.
        /// </summary>
        /// <param name="id">The id of the exercise.</param>
        /// <returns>The lateset version nummber.</returns>
        public int GetLatestVersionNumber(int id);

        /// <summary>
        /// Gets the an instance of a exercise, which only has one version, written lanuage and programming language.
        /// </summary>
        /// <param name="id">The id of the exercise.</param>
        /// <param name="programming_language">The programming language as a string.</param>
        /// <param name="written_language">The written language as a string.</param>
        /// <param name="version">The version of the exercise. If version is less than 0, the newest version is used.</param>
        /// <returns>The exercise instance.</returns>
        public ExerciseInstance GetExerciseInstance(int id, string programming_language, string written_language, int version = -1);

        /// <summary>
        /// Checks if exerice exists.
        /// </summary>
        /// <param name="exercise">The exercise.</param>
        /// <returns>True if exercise exists, else false.</returns>
        public bool Exists(Exercise exercise);

        /// <summary>
        /// Gets the question type with its programming language.
        /// </summary>
        /// <param name="questiontype">The questiontype.</param>
        /// <returns>The questiontype entity.</returns>
        public QuestionType GetQuestionType(string questiontype);

        /// <summary>
        /// Update the valid state of an exercise version.
        /// </summary>
        /// <param name="exercise_id">the exercise id.</param>
        /// <param name="version_number">the version number.</param>
        /// <param name="valid_state">the state that should be set.</param>
        public void UpdateValidState(int exercise_id, int version_number, ValidState valid_state);
    }
}
