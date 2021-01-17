// <copyright file="ExerciseHeaderValidator.cs" company="FHTW CodeRunner">
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
    /// Validator for the ExerciseHeader Entity.
    /// </summary>
    public class ExerciseHeaderValidator : AbstractValidator<ExerciseHeader>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseHeaderValidator"/> class.
        /// </summary>
        public ExerciseHeaderValidator()
        {
            this.RuleFor(eh => eh.FullTitle)
                .NotEmpty();

            this.RuleFor(eh => eh.Introduction)
                .NotEmpty();
        }
    }
}
