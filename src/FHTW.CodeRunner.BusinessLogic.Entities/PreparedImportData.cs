// <copyright file="PreparedImportData.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using EsEntities = FHTW.CodeRunner.ExportService.Entities;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that describes the prepared data for the import of a collection.
    /// </summary>
    public class PreparedImportData
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
        /// Gets or sets the quiz.
        /// </summary>
        public EsEntities.Quiz Quiz { get; set; }
    }
}
