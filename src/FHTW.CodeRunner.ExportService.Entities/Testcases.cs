// <copyright file="Testcases.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    /// <summary>
    /// Entity that describes testcases.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [XmlRoot(ElementName = "testcases")]
    public class Testcases
    {
        /// <summary>
        /// Gets or sets multiple testcase.
        /// </summary>
        [XmlElement(ElementName = "testcase")]
        public List<Testcase> Testcase { get; set; }
    }
}
