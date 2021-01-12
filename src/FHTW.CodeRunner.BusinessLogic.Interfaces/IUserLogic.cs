// <copyright file="IUserLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Entities;

namespace FHTW.CodeRunner.BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface for dealing with user actions.
    /// </summary>
    public interface IUserLogic
    {
        /// <summary>
        /// Function that authenticates a user.
        /// </summary>
        /// <param name="user">The user data.</param>
        /// <returns>The id of the user. Is null when not authenticated.</returns>
        int? AuthenticateUser(User user);
    }
}
