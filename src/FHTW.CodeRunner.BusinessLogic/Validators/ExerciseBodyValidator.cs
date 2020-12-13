// <copyright file="ExerciseBodyValidator.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Entities;
using FluentValidation;

namespace FHTW.CodeRunner.BusinessLogic.Validators
{
    public class ExerciseBodyValidator : AbstractValidator<ExerciseBody>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseBodyValidator"/> class.
        /// </summary>
        public ExerciseBodyValidator()
        {
            this.RuleFor(eb => eb.FkProgrammingLanguage)
                .NotNull()
                .SetValidator(new ProgrammingLanguageValidator());

            this.RuleFor(eb => eb.FkTestSuite)
                .NotNull()
                .SetValidator(new TestSuiteValidator());
        }
    }
}
