// <copyright file="Extra.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    [XmlRoot(ElementName = "extra")]
    public class Extra
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
    }
}
