// <copyright file="Tags.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    /// <summary>
    /// Entity that describes tags.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [XmlRoot(ElementName = "tags")]
    public class Tags
    {
        /// <summary>
        /// Gets or sets multiple tag.
        /// </summary>
        [XmlElement(ElementName = "tag")]
        public List<Tag> Tag { get; set; }
    }
}
