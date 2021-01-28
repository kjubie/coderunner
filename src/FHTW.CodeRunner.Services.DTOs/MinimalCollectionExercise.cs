// <copyright file="MinimalCollectionExercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// A view version of the collection entity.
    /// It contains anything necessary to display the collection.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class MinimalCollectionExercise
    {
        /// <summary>
        /// Gets or sets the id of the exercise.
        /// </summary>
        [DataMember(Name = "exerciseId")]
        public int ExerciseId { get; set; }

        /// <summary>
        /// Gets or sets the title of the exercise.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the collection.
        /// </summary>
        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the user that created the collection.
        /// </summary>
        [DataMember(Name = "user")]
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the selected written language.
        /// </summary>
        [DataMember(Name = "writtenLanguage")]
        public string WrittenLanguage { get; set; }

        /// <summary>
        /// Gets or sets the selected programming language.
        /// </summary>
        [DataMember(Name = "programmingLanguage")]
        public string ProgrammingLanguage { get; set; }

        /// <summary>
        /// Gets or sets the selected version.
        /// </summary>
        [DataMember(Name = "version")]
        public int Version { get; set; }
    }
}
