// <copyright file="ExerciseTagValidator.cs" company="FHTW CodeRunner">
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
    /// Validator for the ExerciseTage Entity.
    /// </summary>
    public class ExerciseTagValidator : AbstractValidator<ExerciseTag>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseTagValidator"/> class.
        /// </summary>
        public ExerciseTagValidator()
        {
            this.RuleFor(et => et.FkTag)
                .SetValidator(new TagValidator());
        }
    }
}
