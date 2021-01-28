// <copyright file="ExportXmlConversionException.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.ExportService.Exceptions
{
    /// <summary>
    /// Exception for xml conversion issues in the Export Service Layer.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ExportXmlConversionException : ExportServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportXmlConversionException"/> class.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="inner">The inner exception.</param>
        public ExportXmlConversionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
