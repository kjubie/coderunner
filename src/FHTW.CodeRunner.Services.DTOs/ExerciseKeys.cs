// <copyright file="ExerciseKeys.cs" company="FHTW CodeRunner">
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
    /// Entity that describes the needed information for a specific exercise.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseKeys
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [DataMember(Name = "version")]
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets the written language.
        /// </summary>
        [DataMember(Name = "writtenLanguage")]
        public string WrittenLanguage { get; set; }

        /// <summary>
        /// Gets or sets the programming language.
        /// </summary>
        [DataMember(Name = "programmingLanguage")]
        public string ProgrammingLanguage { get; set; }
    }
}
