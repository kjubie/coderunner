// <copyright file="ExerciseLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Entit that describes the written language for an exercise.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseLanguage
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the exercise header.
        /// </summary>
        [DataMember(Name = "exerciseHeader")]
        public ExerciseHeader FkExerciseHeader { get; set; }

        /// <summary>
        /// Gets or sets the written language.
        /// </summary>
        [DataMember(Name = "writtenLanguage")]
        public WrittenLanguage FkWrittenLanguage { get; set; }

        /// <summary>
        /// Gets or sets multiple exercise bodies.
        /// </summary>
        [DataMember(Name = "exerciseBody")]
        public ICollection<ExerciseBody> ExerciseBody { get; set; }
    }
}
