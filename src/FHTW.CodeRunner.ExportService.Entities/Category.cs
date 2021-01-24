// <copyright file="Category.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    /// <summary>
    /// Entity that describes a category.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [XmlRoot(ElementName = "category")]
    public class Category
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
    }
}
