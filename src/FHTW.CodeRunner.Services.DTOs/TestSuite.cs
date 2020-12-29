// <copyright file="TestSuite.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class TestSuite
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestSuite"/> class.
        /// </summary>
        public TestSuite()
        {
            this.TestCase = new HashSet<TestCase>();
        }

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
        /// Gets or Sets the template parameter for the exercise.
        /// </summary>
        [DataMember(Name = "templateParam")]
        public string TemplateParam { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets a value indicatíng whether the template parameter namespace can be omitted.
        /// </summary>
        [DataMember(Name = "templateParamLiftFlag")]
        public bool TemplateParamLiftFlag { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether twig should be used for every field.
        /// </summary>
        [DataMember(Name = "twigAllFlag")]
        public bool TwigAllFlag { get; set; }

        [DataMember(Name = "testCaseList")]
        public ICollection<TestCase> TestCase { get; set; }
    }
}
