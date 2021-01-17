// <copyright file="BlDataNotFoundException.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Exceptions
{
    /// <summary>
    /// Exception for data not found issues in the Business Layer.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BlDataNotFoundException : BlException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlDataNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="inner">The inner exception.</param>
        public BlDataNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
