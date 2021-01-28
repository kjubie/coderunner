// <copyright file="UserLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Exceptions;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using FHTW.CodeRunner.DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using DalEntities = FHTW.CodeRunner.DataAccess.Entities;

namespace FHTW.CodeRunner.BusinessLogic
{
    /// <summary>
    /// Logic Class for user actions.
    /// </summary>
    public class UserLogic : IUserLogic
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogic"/> class.
        /// </summary>
        /// <param name="logger">The injected logger.</param>
        /// <param name="mapper">The injected mapper.</param>
        /// <param name="userRepository">The injected user repository.</param>
        public UserLogic(ILogger<UserLogic> logger, IMapper mapper, IUserRepository userRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        /// <inheritdoc/>
        public int? AuthenticateUser(BlEntities.User user)
        {
            if (user == null)
            {
                this.logger.LogError("USer is null");
                throw new BlValidationException("User is null", null);
            }

            try
            {
                var dalUser = this.mapper.Map<DalEntities.User>(user);
                int? result = this.userRepository.Authenticate(dalUser);

                return result;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw new BlDataAccessException("Unable to authenticate user " + user.Name, e);
            }
        }
    }
}
