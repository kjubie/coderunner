// <copyright file="UserValidator.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using FHTW.CodeRunner.BusinessLogic.Entities;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Validators
{
    [ExcludeFromCodeCoverage]
    public class UserValidator : AbstractValidator<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserValidator"/> class.
        /// </summary>
        public UserValidator()
        {
            this.RuleFor(b => b.Name)
                .NotNull();
        }
    }
}
