// <copyright file="Display.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    [XmlRoot(ElementName = "display")]
    public class Display
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
    }
}
