// <copyright file="UserLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Interfaces;

namespace FHTW.CodeRunner.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        /// <inheritdoc/>
        public bool AuthenticateUser(string name, string password)
        {
            if (name == "root" && password == "toor")
            {
                return true;
            }

            return false;
        }
    }
}
