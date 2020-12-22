// <copyright file="Testcase.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    [XmlRoot(ElementName = "testcase")]
    public class Testcase
    {
        [XmlElement(ElementName = "testcode")]
        public Testcode Testcode { get; set; }
        [XmlElement(ElementName = "stdin")]
        public Stdin Stdin { get; set; }
        [XmlElement(ElementName = "expected")]
        public Expected Expected { get; set; }
        [XmlElement(ElementName = "extra")]
        public Extra Extra { get; set; }
        [XmlElement(ElementName = "display")]
        public Display Display { get; set; }
        [XmlAttribute(AttributeName = "testtype")]
        public string Testtype { get; set; }
        [XmlAttribute(AttributeName = "useasexample")]
        public string Useasexample { get; set; }
        [XmlAttribute(AttributeName = "hiderestiffail")]
        public string Hiderestiffail { get; set; }
        [XmlAttribute(AttributeName = "mark")]
        public string Mark { get; set; }
    }
}
