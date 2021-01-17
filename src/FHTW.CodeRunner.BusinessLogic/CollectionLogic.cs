﻿// <copyright file="CollectionLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Exceptions;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using FHTW.CodeRunner.BusinessLogic.Validators;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Logging;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using DalEntities = FHTW.CodeRunner.DataAccess.Entities;

namespace FHTW.CodeRunner.BusinessLogic
{
    /// <summary>
    /// Logic Class for dealing with collection actions.
    /// </summary>
    public class CollectionLogic : ICollectionLogic
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly ICollectionRepository collectionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionLogic"/> class.
        /// </summary>
        /// <param name="logger">The injected logger.</param>
        /// <param name="mapper">The injected mapper.</param>
        /// <param name="collectionRepository">The injected exercise repository.</param>
        public CollectionLogic(ILogger<CollectionLogic> logger, IMapper mapper, ICollectionRepository collectionRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.collectionRepository = collectionRepository;
        }

        /// <inheritdoc/>
        public void SaveCollection(BlEntities.Collection collection)
        {
            if (collection == null)
            {
                this.logger.LogError("Collection is null");
                throw new BlValidationException("Collection is null", null);
            }
            else
            {
                if (collection.Created == null)
                {
                    collection.Created = DateTime.Now;
                }

                var dalCollection = this.mapper.Map<DalEntities.Collection>(collection);

                this.collectionRepository.CreateOrUpdate(dalCollection);
                this.logger.LogInformation("BL passing Collection with Title: " + collection.Title + " to DAL.");
            }
        }
    }
}
