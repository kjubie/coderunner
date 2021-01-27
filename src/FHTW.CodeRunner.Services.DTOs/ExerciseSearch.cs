// <copyright file="ExerciseSearch.cs" company="FHTW CodeRunner">
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
    /// Entity that describes the needed information for a search for exercises in the database.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseSearch
    {
        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        [DataMember(Name = "searchTerm")]
        public string SearchTerm { get; set; }

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
