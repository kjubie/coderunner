// <copyright file="Stdin.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    [XmlRoot(ElementName = "stdin")]
    public class Stdin
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
    }
}
