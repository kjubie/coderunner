// <copyright file="MinimalCollectionExercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// A view version of the collection entity.
    /// It contains anything necessary to display the collection.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MinimalCollectionExercise
    {
        /// <summary>
        /// Gets or sets the id of the exercise.
        /// </summary>
        public int ExerciseId { get; set; }

        /// <summary>
        /// Gets or sets the title of the exercise.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the collection.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the user that created the collection.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the selected written language.
        /// </summary>
        public string WrittenLanguage { get; set; }

        /// <summary>
        /// Gets or sets the selected programming language.
        /// </summary>
        public string ProgrammingLanguage { get; set; }

        /// <summary>
        /// Gets or sets the selected version.
        /// </summary>
        public int Version { get; set; }
    }
}
