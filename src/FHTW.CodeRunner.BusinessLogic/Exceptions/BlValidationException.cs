// <copyright file="BlValidationException.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Exceptions
{
    /// <summary>
    /// Exception for validation issues in the Business Layer.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BlValidationException : BlException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlValidationException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public BlValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
