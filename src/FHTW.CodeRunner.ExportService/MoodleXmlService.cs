// <copyright file="MoodleXmlService.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using FHTW.CodeRunner.ExportService.Entities;
using FHTW.CodeRunner.ExportService.Exceptions;
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
            try
            {
                using (var writer = new Utf8StringWriter())
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(quiz.GetType());
                    xmlSerializer.Serialize(writer, quiz);

                    return writer.ToString();
                }
            }
            catch (Exception e)
            {
                // this.logger.LogError(e.Message);
                throw new ExportXmlConversionException("Unable to convert to xml", e);
            }
        }

        /// <inheritdoc/>
        public Quiz ImportMoodleXml(string xml)
        {
            try
            {
                Quiz quiz = new Quiz();

                using (var reader = new StringReader(xml))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(quiz.GetType());
                    quiz = (Quiz)xmlSerializer.Deserialize(reader);
                }

                return quiz;
            }
            catch (Exception e)
            {
                // this.logger.LogError(e.Message);
                throw new ExportXmlConversionException("Unable to convert xml to object", e);
            }
        }
    }
}
