// <copyright file="TestSuite.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
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

        /// <summary>
        /// Gets or Sets the question type.
        /// </summary>
        public QuestionType FkQuestionType { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the from the template generated program should be displayed.
        /// </summary>
        public bool TemplateDebugFlag { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the test cases should be tested on save.
        /// Not part of FHTW-CodeRunner, but of moodle.
        /// </summary>
        public bool TestOnSaveFlag { get; set; }

        /// <summary>
        /// Gets or Sets the global extra that is available in each test case.
        /// </summary>
        public string GlobalExtraParam { get; set; }

        /// <summary>
        /// Gets or Sets runtime data.
        /// </summary>
        public string RuntimeData { get; set; }

        /// <summary>
        /// Gets or Sets the template parameter for the exercise.
        /// </summary>
        public string TemplateParam { get; set; }

        /// <summary>
        /// Gets or Sets a value indicatíng whether the template parameter namespace can be omitted.
        /// </summary>
        public bool TemplateParamLiftFlag { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether twig should be used for every field.
        /// </summary>
        public bool TwigAllFlag { get; set; }

        public ICollection<TestCase> TestCase { get; set; }
    }
}
