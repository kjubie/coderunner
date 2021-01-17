// <copyright file="ExerciseIds.cs" company="FHTW CodeRunner">
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
    /// Entity that describes the needed ids for a specific exercise.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseIds
    {
        /// <summary>
        /// Gets or Sets the foreign key id of the regular exercise.
        /// </summary>
        [DataMember(Name = "id")]
        public int FkExerciseId { get; set; }

        /// <summary>
        /// Gets or Sets the prefered version number for the exercise.
        /// </summary>
        [DataMember(Name = "version")]
        public int VersionNumber { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of the prefered programming language.
        /// </summary>
        [DataMember(Name = "programmingLanguageId")]
        public int FkProgrammingLanguageId { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of the prefered written language.
        /// </summary>
        [DataMember(Name = "writtenLanguageId")]
        public int FkWrittenLanguageId { get; set; }
    }
}
