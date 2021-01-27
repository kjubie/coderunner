// <copyright file="SearchObject.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that describes the needed information for a search in the database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SearchObject
    {
        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        public string SearchTerm{ get; set; }

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
