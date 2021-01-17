// <copyright file="ExerciseVersionValidator.cs" company="FHTW CodeRunner">
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
    /// Validator for the ExerciseVersion Entity.
    /// </summary>
    public class ExerciseVersionValidator : AbstractValidator<ExerciseVersion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseVersionValidator"/> class.
        /// </summary>
        public ExerciseVersionValidator()
        {
            this.RuleFor(ev => ev.FkUser)
                .NotNull()
                .SetValidator(new UserValidator());

            this.RuleForEach(ev => ev.ExerciseLanguage)
                .NotNull()
                .SetValidator(new ExerciseLanguageValidator());
        }
    }
}
