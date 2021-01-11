// <copyright file="TestCase.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that describes a test case.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TestCase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets at what order the testcase should be called (optional).
        /// </summary>
        public int? OrderUsed { get; set; }

        /// <summary>
        /// Gets or Sets the code for the test.
        /// </summary>
        public string TestCode { get; set; }

        /// <summary>
        /// Gets or Sets the default input of the test.
        /// </summary>
        public string StandardInput { get; set; }

        /// <summary>
        /// Gets or Sets the expected ouput for the test.
        /// </summary>
        public string ExpectedOutput { get; set; }

        /// <summary>
        /// Gets or Sets additional data used in the testcase.
        /// </summary>
        public string AdditionalData { get; set; }

        /// <summary>
        /// Gets or Sets the attainable points of the test.
        /// </summary>
        public int? Points { get; set; } // TODO null ?

        /// <summary>
        /// Gets or Sets a value indicating whether the test should be used as an example.
        /// </summary>
        public bool UseAsExampleFlag { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the following test should be hidden if this one fails.
        /// </summary>
        public bool HideOnFailFlag { get; set; }

        /// <summary>
        /// Gets or Sets in which case this test case should be hidden.
        /// Values: {SHOW, HIDE, HIDE_IF_FAIL, HIDE_IF_SUCCEED}.
        /// </summary>
        public string DisplayType { get; set; }
    }
}
