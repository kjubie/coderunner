﻿// <copyright file="UserRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    /// <summary>
    /// The repository for the <see cref="User"/> entity.
    /// </summary>
    public class UserRepository : SimpleRepository<User, CodeRunnerContext>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbcontext">The dbcontext to be used for the repository.</param>
        public UserRepository(CodeRunnerContext dbcontext)
            : base(dbcontext)
        {
        }

        /// <inheritdoc/>
        public bool Authenticate(User user)
        {
            return this.Exists(user);
        }
    }
}
