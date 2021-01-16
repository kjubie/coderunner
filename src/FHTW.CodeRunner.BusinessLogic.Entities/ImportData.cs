// <copyright file="ImportData.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that describes the needed data for the import of a collection.
    /// </summary>
    public class ImportData
    {
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the written language.
        /// </summary>
        public WrittenLanguage WrittenLanguage { get; set; }

        /// <summary>
        /// Gets or sets the xml document as string.
        /// </summary>
        public string XmlString { get; set; }
    }
}
