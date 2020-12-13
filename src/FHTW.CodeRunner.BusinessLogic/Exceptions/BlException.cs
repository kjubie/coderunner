// <copyright file="BlException.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class BlException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlException"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public BlException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
