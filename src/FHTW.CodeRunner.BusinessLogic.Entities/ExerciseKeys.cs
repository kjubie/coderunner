// <copyright file="ExerciseKeys.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that describes the needed information for a specific exercise.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ExerciseKeys
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets the written language.
        /// </summary>
        public string WrittenLanguage { get; set; }

        /// <summary>
        /// Gets or sets the programming language.
        /// </summary>
        public string ProgrammingLanguage { get; set; }
    }
}
