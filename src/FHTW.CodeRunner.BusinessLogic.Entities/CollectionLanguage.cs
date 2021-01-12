// <copyright file="CollectionLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Enity for defining the exercises for a certain written language.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CollectionLanguage
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full title.
        /// </summary>
        public string FullTitle { get; set; }

        /// <summary>
        /// Gets or sets a short title.
        /// </summary>
        public string ShortTitle { get; set; }

        /// <summary>
        /// Gets or sets an introduction.
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// Gets or sets the id for the written language.
        /// </summary>
        public int FkWrittenLanguageId { get; set; }

        /// <summary>
        /// Gets or sets the written language.
        /// </summary>
        public WrittenLanguage FkWrittenLanguage { get; set; }
    }
}
