// <copyright file="Questiontext.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    [XmlRoot(ElementName = "questiontext")]
    public class Questiontext
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "format")]
        public string Format { get; set; }
    }
}
