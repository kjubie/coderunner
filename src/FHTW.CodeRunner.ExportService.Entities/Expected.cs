// <copyright file="Expected.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    [XmlRoot(ElementName = "expected")]
    public class Expected
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
    }
}
