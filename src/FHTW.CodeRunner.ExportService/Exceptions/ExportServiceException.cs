// <copyright file="ExportServiceException.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.ExportService.Exceptions
{
    /// <summary>
    /// Base exception for issues in the Export Service Layer.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ExportServiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportServiceException"/> class.
        /// </summary>
        /// <param name="message">The mesage of the exception.</param>
        /// <param name="inner">The inner exception.</param>
        public ExportServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
