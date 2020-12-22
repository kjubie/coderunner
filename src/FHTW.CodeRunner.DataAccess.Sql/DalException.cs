// <copyright file="DalException.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

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
