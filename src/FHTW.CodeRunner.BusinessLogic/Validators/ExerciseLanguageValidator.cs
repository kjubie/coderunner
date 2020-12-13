// <copyright file="ExerciseLanguageValidator.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Entities;
using FluentValidation;

namespace FHTW.CodeRunner.BusinessLogic.Validators
{
    public class ExerciseLanguageValidator : AbstractValidator<ExerciseLanguage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseLanguageValidator"/> class.
        /// </summary>
        public ExerciseLanguageValidator()
        {
            this.RuleFor(el => el.FkExerciseHeader)
                .NotNull()
                .SetValidator(new ExerciseHeaderValidator());

            this.RuleFor(el => el.FkWrittenLanguage)
                .NotNull()
                .SetValidator(new WrittenLanguageValidator());

            this.RuleForEach(ev => ev.ExerciseBody)
                .NotNull()
                .SetValidator(new ExerciseBodyValidator());
        }
    }
}
