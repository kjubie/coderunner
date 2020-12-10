// <copyright file="IUserLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Interfaces
{
    public interface IUserLogic
    {
        bool AuthenticateUser(string name, string password);
    }
}
