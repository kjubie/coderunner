using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    /// <summary>
    /// Exception while updateing or saving data in the dal.
    /// </summary>
    public class DalUpdateException : DalException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DalUpdateException"/> class.
        /// </summary>
        public DalUpdateException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DalUpdateException"/> class.
        /// </summary>
        /// <param name="message">Custom error message.</param>
        public DalUpdateException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DalUpdateException"/> class.
        /// </summary>
        /// <param name="message">Custom error message.</param>
        /// <param name="inner">The inner exception.</param>
        public DalUpdateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
