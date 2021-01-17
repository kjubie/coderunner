// <copyright file="Testcase.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    /// <summary>
    /// Entity that describes the testcase.
    /// </summary>
    [XmlRoot(ElementName = "testcase")]
    public class Testcase
    {
        /// <summary>
        /// Gets or sets the testcode.
        /// </summary>
        [XmlElement(ElementName = "testcode")]
        public Testcode Testcode { get; set; }

        /// <summary>
        /// Gets or sets the stdin.
        /// </summary>
        [XmlElement(ElementName = "stdin")]
        public Stdin Stdin { get; set; }

        /// <summary>
        /// Gets or sets the expected.
        /// </summary>
        [XmlElement(ElementName = "expected")]
        public Expected Expected { get; set; }

        /// <summary>
        /// Gets or sets the extra.
        /// </summary>
        [XmlElement(ElementName = "extra")]
        public Extra Extra { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        [XmlElement(ElementName = "display")]
        public Display Display { get; set; }

        /// <summary>
        /// Gets or sets the test type.
        /// </summary>
        [XmlAttribute(AttributeName = "testtype")]
        public string Testtype { get; set; }

        /// <summary>
        /// Gets or sets the useasexample flag..
        /// </summary>
        [XmlAttribute(AttributeName = "useasexample")]
        public string Useasexample { get; set; }

        /// <summary>
        /// Gets or sets the hiderestiffail flag.
        /// </summary>
        [XmlAttribute(AttributeName = "hiderestiffail")]
        public string Hiderestiffail { get; set; }

        /// <summary>
        /// Gets or sets the mark.
        /// </summary>
        [XmlAttribute(AttributeName = "mark")]
        public string Mark { get; set; }
    }
}
