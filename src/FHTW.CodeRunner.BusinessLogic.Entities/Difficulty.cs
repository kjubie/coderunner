// <copyright file="Difficulty.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that describes the difficulty.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Difficulty
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the exercise.
        /// </summary>
        public Exercise FkExercise { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public User FkUser { get; set; }
    }
}
