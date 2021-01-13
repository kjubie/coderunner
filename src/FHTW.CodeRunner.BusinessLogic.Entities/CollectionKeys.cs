// <copyright file="CollectionKeys.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that describes the needed information for a specific collection.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CollectionKeys
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the written language.
        /// </summary>
        public string WrittenLanguage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the language set in each collection exercise should be used or the language parameter.
        /// </summary>
        public bool UseSetLanguage { get; set; }
    }
}
