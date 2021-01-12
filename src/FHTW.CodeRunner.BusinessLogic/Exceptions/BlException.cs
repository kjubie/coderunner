// <copyright file="BlException.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Exceptions
{
    /// <summary>
    /// Base exception for issues in the Business Layer.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BlException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlException"/> class.
        /// </summary>
        /// <param name="message">The mesage of the exception.</param>
        /// <param name="inner">The inner exception.</param>
        public BlException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
