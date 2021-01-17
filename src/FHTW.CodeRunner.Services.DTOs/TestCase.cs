// <copyright file="TestCase.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Entity that describes a test case.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class TestCase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets at what order the testcase should be called (optional).
        /// </summary>
        [DataMember(Name = "orderUsed")]
        public int? OrderUsed { get; set; }

        /// <summary>
        /// Gets or Sets the code for the test.
        /// </summary>
        [DataMember(Name = "testCode")]
        public string TestCode { get; set; }

        /// <summary>
        /// Gets or Sets the default input of the test.
        /// </summary>
        [DataMember(Name = "standardInput")]
        public string StandardInput { get; set; }

        /// <summary>
        /// Gets or Sets the expected ouput for the test.
        /// </summary>
        [DataMember(Name = "expectedOutput")]
        public string ExpectedOutput { get; set; }

        /// <summary>
        /// Gets or Sets additional data used in the testcase.
        /// </summary>
        [DataMember(Name = "additionalData")]
        public string AdditionalData { get; set; }

        /// <summary>
        /// Gets or Sets the attainable points of the test.
        /// </summary>
        [DataMember(Name = "points")]
        public int? Points { get; set; } // TODO null ?

        /// <summary>
        /// Gets or Sets a value indicating whether the test should be used as an example.
        /// </summary>
        [DataMember(Name = "useAsExampleFlag")]
        public bool UseAsExampleFlag { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the following test should be hidden if this one fails.
        /// </summary>
        [DataMember(Name = "hideOnFailFlag")]
        public bool HideOnFailFlag { get; set; }

        /// <summary>
        /// Gets or Sets in which case this test case should be hidden.
        /// Values: {SHOW, HIDE, HIDE_IF_FAIL, HIDE_IF_SUCCEED}.
        /// </summary>
        [DataMember(Name = "displayType")]
        public string DisplayType { get; set; }
    }
}
