// <copyright file="Tag.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    /// <summary>
    /// Entity that describes the tag.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [XmlRoot(ElementName = "tag")]
    public class Tag
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
    }
}
