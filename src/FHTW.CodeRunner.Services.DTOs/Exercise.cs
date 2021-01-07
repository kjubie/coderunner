// <copyright file="Exercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Entity that describes the exercise.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class Exercise
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        [DataMember(Name = "user")]
        public User FkUser { get; set; }

        /// <summary>
        /// Gets or sets multiple tags.
        /// </summary>
        [DataMember(Name = "exerciseTagList")]
        public ICollection<ExerciseTag> ExerciseTag { get; set; }

        /// <summary>
        /// Gets or sets multiple versions.
        /// </summary>
        [DataMember(Name = "exerciseVersionList")]
        public ICollection<ExerciseVersion> ExerciseVersion { get; set; }
    }
}
