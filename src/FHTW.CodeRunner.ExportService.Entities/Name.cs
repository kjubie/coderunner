// <copyright file="Name.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    [XmlRoot(ElementName = "name")]
    public class Name
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
    }
}
