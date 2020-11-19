// <copyright file="ExerciseValidator.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using FHTW.CodeRunner.BusinessLogic.Entities;
using FluentValidation;

namespace FHTW.CodeRunner.BusinessLogic.Validators
{
    public class ExerciseValidator : AbstractValidator<Exercise>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseValidator"/> class.
        /// </summary>
        public ExerciseValidator()
        {
            this.RuleFor(e => e.Title)
                .NotNull();

            this.RuleFor(e => e.Created)
                .NotNull();

            this.RuleFor(e => e.FkUser)
                .NotNull()
                .SetValidator(new UserValidator());
        }
    }
}
