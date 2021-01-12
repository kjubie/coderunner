// <copyright file="ProgrammingLanguageValidator.cs" company="FHTW CodeRunner">
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
    /// Validator for the ProgrammingLanguage Entity.
    /// </summary>
    public class ProgrammingLanguageValidator : AbstractValidator<ProgrammingLanguage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgrammingLanguageValidator"/> class.
        /// </summary>
        public ProgrammingLanguageValidator()
        {
            this.RuleFor(pl => pl.Name)
                .NotEmpty();
        }
    }
}
