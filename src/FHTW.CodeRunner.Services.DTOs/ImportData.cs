// <copyright file="ImportData.cs" company="FHTW CodeRunner">
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
    /// Entity that describes the needed data for the import of a collection.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ImportData
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        [DataMember(Name = "user")]
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the written language.
        /// </summary>
        [DataMember(Name = "writtenLanguage")]
        public WrittenLanguage WrittenLanguage { get; set; }

        /// <summary>
        /// Gets or sets the xml document as base64 string.
        /// </summary>
        [DataMember(Name = "Base64XmlString")]
        public string Base64XmlString { get; set; }
    }
}
