// <copyright file="TestSuite.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Enum for Precheck State.
    /// </summary>
    public enum PreCheckState
    {
        /// <summary>
        /// No precheck.
        /// </summary>
        Deactivated = 0,

        /// <summary>
        /// Run test with empty parameters.
        /// </summary>
        Empty = 1,

        /// <summary>
        /// Run all tests where UseAsExampleFlag is set.
        /// </summary>
        Examples = 2,

        /// <summary>
        /// Run all explicitly marked tests.
        /// </summary>
        Selected = 3,

        /// <summary>
        /// Run all tests.
        /// </summary>
        All = 4,
    }

    /// <summary>
    /// Enum for the display state of the feedback.
    /// </summary>
    public enum GeneralFeedbackDisplayState
    {
        /// <summary>
        /// Use value set by testcase.
        /// </summary>
        SetFromTest = 0,

        /// <summary>
        /// Force display of feedback.
        /// </summary>
        ForceDisplay = 1,

        /// <summary>
        /// Force hiding of feedback.
        /// </summary>
        ForceHide = 2,
    }

    /// <summary>
    /// Entity that describes the test suite.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class TestSuite
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the question type.
        /// </summary>
        [DataMember(Name = "questionType")]
        public QuestionType FkQuestionType { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the from the template generated program should be displayed.
        /// </summary>
        [DataMember(Name = "templateDebugFlag")]
        public bool TemplateDebugFlag { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the test cases should be tested on save.
        /// Not part of FHTW-CodeRunner, but of moodle.
        /// </summary>
        [DataMember(Name = "testOnSaveFlag")]
        public bool TestOnSaveFlag { get; set; }

        /// <summary>
        /// Gets or Sets the global extra that is available in each test case.
        /// </summary>
        [DataMember(Name = "globalExtraParam")]
        public string GlobalExtraParam { get; set; }

        /// <summary>
        /// Gets or Sets runtime data.
        /// </summary>
        [DataMember(Name = "runtimeData")]
        public string RuntimeData { get; set; }

        /// <summary>
        /// Gets or Sets state of precheck.
        /// </summary>
        [DataMember(Name = "preCheck")]
        public PreCheckState PreCheck { get; set; }

        /// <summary>
        /// Gets or Sets state of general feedback display.
        /// </summary>
        [DataMember(Name = "generalFeedbackDisplay")]
        public GeneralFeedbackDisplayState GeneralFeedbackDisplay { get; set; }

        /// <summary>
        /// Gets or sets multiple test case.
        /// </summary>
        [DataMember(Name = "testCaseList")]
        public ICollection<TestCase> TestCase { get; set; }
    }
}
