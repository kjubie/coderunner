// <copyright file="TestSuiteValidator.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Entities;
using FluentValidation;

namespace FHTW.CodeRunner.BusinessLogic.Validators
{
    public class TestSuiteValidator : AbstractValidator<TestSuite>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestSuiteValidator"/> class.
        /// </summary>
        public TestSuiteValidator()
        {
            this.RuleForEach(ts => ts.TestCase)
                .NotNull()
                .SetValidator(new TestCaseValidator());
        }
    }
}
