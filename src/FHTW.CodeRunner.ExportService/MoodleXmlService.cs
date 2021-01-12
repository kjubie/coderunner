// <copyright file="MoodleXmlService.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using FHTW.CodeRunner.ExportService.Entities;
using FHTW.CodeRunner.ExportService.Interfaces;

namespace FHTW.CodeRunner.ExportService
{
    /// <summary>
    /// The service class for dealing with moodle xml actions.
    /// </summary>
    public class MoodleXmlService : IMoodleXmlService
    {
        /// <inheritdoc/>
        public string ExportMoodleXml(Quiz quiz)
        {
            using (var writer = new Utf8StringWriter())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(quiz.GetType());
                xmlSerializer.Serialize(writer, quiz);

                return writer.ToString();
            }
        }

        /// <inheritdoc/>
        public Quiz ImportMoodleXml()
        {
            throw new NotImplementedException();
        }
    }
}
