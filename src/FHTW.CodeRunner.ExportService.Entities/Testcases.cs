// <copyright file="Testcases.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    [XmlRoot(ElementName = "testcases")]
    public class Testcases
    {
        [XmlElement(ElementName = "testcase")]
        public Testcase Testcase { get; set; }
    }
}
