// <copyright file="ExerciseTag.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that connects a tag to an exercise.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ExerciseTag
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        public Tag FkTag { get; set; }
    }
}
