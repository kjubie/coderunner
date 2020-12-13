using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    public class DalException : Exception
    {
        public DalException()
        {
        }

        public DalException(string message)
            : base(message)
        {
        }

        public DalException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
