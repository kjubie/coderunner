// <copyright file="IMoodleXmlService.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.ExportService.Entities;

namespace FHTW.CodeRunner.ExportService.Interfaces
{
    /// <summary>
    /// Interface for services that deal with the moodle xml.
    /// </summary>
    public interface IMoodleXmlService
    {
        /// <summary>
        /// Function that generates the moodle xml from the quiz.
        /// </summary>
        /// <param name="quiz">The moodle quiz entity.</param>
        /// <returns>The serialized xml string.</returns>
        public string ExportMoodleXml(Quiz quiz);

        /// <summary>
        /// Function that imports a moodle xml string.
        /// </summary>
        /// <returns>The moodle quiz entity.</returns>
        public Quiz ImportMoodleXml();
    }
}
