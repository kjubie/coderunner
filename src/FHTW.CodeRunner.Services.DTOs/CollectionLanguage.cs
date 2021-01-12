// <copyright file="CollectionLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Enity for defining the exercises for a certain written language.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class CollectionLanguage
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full title.
        /// </summary>
        [DataMember(Name = "fullTitle")]
        public string FullTitle { get; set; }

        /// <summary>
        /// Gets or sets a short title.
        /// </summary>
        [DataMember(Name = "shortTitle")]
        public string ShortTitle { get; set; }

        /// <summary>
        /// Gets or sets an introduction.
        /// </summary>
        [DataMember(Name = "introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// Gets or sets the id for the written language.
        /// </summary>
        [DataMember(Name = "writtenLanguageId")]
        public int FkWrittenLanguageId { get; set; }

        /// <summary>
        /// Gets or sets the written language.
        /// </summary>
        [DataMember(Name = "writtenLanguage")]
        public WrittenLanguage FkWrittenLanguage { get; set; }
    }
}
