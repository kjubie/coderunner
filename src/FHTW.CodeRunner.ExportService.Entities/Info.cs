// <copyright file="Info.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    /// <summary>
    /// Entity that describes the info.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [XmlRoot(ElementName = "info")]
    public class Info
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        [XmlAttribute(AttributeName = "format")]
        public string Format { get; set; }
    }
}
