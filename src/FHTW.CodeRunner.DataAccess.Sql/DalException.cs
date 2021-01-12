// <copyright file="DalException.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    /// <summary>
    /// Exception for any exception in the DAL.
    /// </summary>
    public class DalException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DalException"/> class.
        /// </summary>
        public DalException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DalException"/> class.
        /// </summary>
        /// <param name="message">Custom error message.</param>
        public DalException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DalException"/> class.
        /// </summary>
        /// <param name="message">Custom error message.</param>
        /// <param name="inner">The inner exception.</param>
        public DalException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
