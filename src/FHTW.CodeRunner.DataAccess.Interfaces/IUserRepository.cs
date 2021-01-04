// <copyright file="IUserRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.DataAccess.Entities;

namespace FHTW.CodeRunner.DataAccess.Interfaces
{
    /// <summary>
    /// Repository for <see cref="FHTW.CodeRunner.DataAccess.Entities.User"/> entity.
    /// All base operations are defined in <see cref="ISimpleRepository{TEntity}"/>.
    /// </summary>
    public interface IUserRepository : ISimpleRepository<User>
    {
        /// <summary>
        /// Checks if a <see cref="User"/> entity with the given password exists.
        /// Note: Passwords are not yet supported.
        /// </summary>
        /// <param name="user">The user conteining both the name and password.</param>
        /// <returns>The user id if the user with the given name password exists, else null.</returns>
        int? Authenticate(User user);
    }
}
