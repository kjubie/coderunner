// <copyright file="TagValidator.cs" company="FHTW CodeRunner">
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
    /// Validator for the Tag Entity.
    /// </summary>
    public class TagValidator : AbstractValidator<Tag>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagValidator"/> class.
        /// </summary>
        public TagValidator()
        {
            this.RuleFor(t => t.Name)
                .NotEmpty();
        }
    }
}
