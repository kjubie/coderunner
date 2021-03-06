// <copyright file="ExerciseValidator.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using FHTW.CodeRunner.BusinessLogic.Entities;
using FluentValidation;

namespace FHTW.CodeRunner.BusinessLogic.Validators
{
    /// <summary>
    /// Validator for the ExerciseValidator Entity.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ExerciseValidator : AbstractValidator<Exercise>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseValidator"/> class.
        /// </summary>
        public ExerciseValidator()
        {
            this.RuleFor(e => e.Title)
                .NotEmpty();

            this.RuleFor(e => e.FkUser)
                .NotNull()
                .SetValidator(new UserValidator());

            this.RuleForEach(e => e.ExerciseTag)
                .SetValidator(new ExerciseTagValidator());

            this.RuleForEach(e => e.ExerciseVersion)
                .NotNull()
                .SetValidator(new ExerciseVersionValidator());
        }
    }
}
