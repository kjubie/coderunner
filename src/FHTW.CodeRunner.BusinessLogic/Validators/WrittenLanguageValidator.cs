// <copyright file="WrittenLanguageValidator.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Entities;
using FluentValidation;

namespace FHTW.CodeRunner.BusinessLogic.Validators
{
    public class WrittenLanguageValidator : AbstractValidator<WrittenLanguage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrittenLanguageValidator"/> class.
        /// </summary>
        public WrittenLanguageValidator()
        {
        }
    }
}
