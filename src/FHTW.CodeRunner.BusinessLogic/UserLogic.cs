// <copyright file="UserLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using FHTW.CodeRunner.DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using DalEntities = FHTW.CodeRunner.DataAccess.Entities;

namespace FHTW.CodeRunner.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UserLogic(ILogger<UserLogic> logger, IMapper mapper, IUserRepository userRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        /// <inheritdoc/>
        public bool AuthenticateUser(BlEntities.User user)
        {
            var dalUser = this.mapper.Map<DalEntities.User>(user);
            bool result = this.userRepository.Authenticate(dalUser);
            /*
            if (user.Name == "root" && user.Password == "toor")
            {
                return true;
            }*/

            return result;
        }
    }
}
