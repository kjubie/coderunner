// <copyright file="CollectionKeys.cs" company="FHTW CodeRunner">
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
    /// Entity that describes the needed information for a specific collection.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class CollectionKeys
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the written language.
        /// </summary>
        [DataMember(Name = "writtenLanguage")]
        public string WrittenLanguage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the language set in each collection exercise should be used or the language parameter.
        /// </summary>
        [DataMember(Name = "useSetLanguage")]
        public bool UseSetLanguage { get; set; }
    }
}
