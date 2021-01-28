// <copyright file="CollectionLogic.cs" company="FHTW CodeRunner">
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
        public List<BlEntities.MinimalCollection> GetMinimalCollectionList()
        {
            try
            {
                var dalCollectionList = this.collectionRepository.GetMinimalCollections();
                var blCollectionList = this.mapper.Map<List<BlEntities.MinimalCollection>>(dalCollectionList);

                return blCollectionList;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw new BlDataAccessException("Unable to retrieve a list of collections from the DAL!", e);
            }
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
                try
                {
                    if (collection.Created == null)
                    {
                        collection.Created = DateTime.Now;
                    }

                    var dalCollection = this.mapper.Map<DalEntities.Collection>(collection);

                    this.collectionRepository.CreateOrUpdate(dalCollection);
                    this.logger.LogInformation("BL passing Collection with Title: " + collection.Title + " to DAL.");
                }
                catch (Exception e)
                {
                    this.logger.LogError(e.Message);
                    throw new BlDataAccessException("Unable to save the collection " + collection.Title, e);
                }
            }
        }

        /// <inheritdoc/>
        public List<BlEntities.MinimalCollection> SearchAndFilter(BlEntities.SearchObject searchObject)
        {
            if (searchObject == null)
            {
                this.logger.LogError("Search Object is null");
                throw new BlValidationException("Search Object is null", null);
            }
            else
            {
                try
                {
                    this.logger.LogInformation($"BL searching for Collections, Search Term {searchObject.SearchTerm} and Written Language {searchObject.WrittenLanguage}.");
                    var dalCollectionList = this.collectionRepository.SearchAndFilter(searchObject.SearchTerm, searchObject.WrittenLanguage);
                    var blCollectionList = this.mapper.Map<List<BlEntities.MinimalCollection>>(dalCollectionList);

                    return blCollectionList;
                }
                catch (Exception e)
                {
                    this.logger.LogError(e.Message);
                    throw new BlDataAccessException("Unable to search and filter for collections", e);
                }
            }
        }

        /// <inheritdoc/>
        public BlEntities.CollectionView GetCollectionView(int id)
        {
            try
            {
                var dalCollectionView = this.collectionRepository.GetCollectionView(id);
                var blCollectionView = this.mapper.Map<BlEntities.CollectionView>(dalCollectionView);

                return blCollectionView;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw new BlDataAccessException("Unable to retrieve the collection view from the DAL!", e);
            }
        }
    }
}
