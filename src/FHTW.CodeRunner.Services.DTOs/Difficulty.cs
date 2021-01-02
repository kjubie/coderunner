// <copyright file="Difficulty.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Entity that describes the difficulty.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class Difficulty
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        [DataMember(Name = "number")]
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the exercise.
        /// </summary>
        [DataMember(Name = "exercise")]
        public Exercise FkExercise { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        [DataMember(Name = "user")]
        public User FkUser { get; set; }
    }
}
