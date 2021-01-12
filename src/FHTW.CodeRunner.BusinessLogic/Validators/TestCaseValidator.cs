// <copyright file="TestCaseValidator.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Entities;
using FluentValidation;

namespace FHTW.CodeRunner.BusinessLogic.Validators
{
    /// <summary>
    /// Validator for the TestCase Entity.
    /// </summary>
    public class TestCaseValidator : AbstractValidator<TestCase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseValidator"/> class.
        /// </summary>
        public TestCaseValidator()
        {
        }
    }
}
