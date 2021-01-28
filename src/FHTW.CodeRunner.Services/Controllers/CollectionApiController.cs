// <copyright file="CollectionApiController.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Exceptions;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using SvcEntities = FHTW.CodeRunner.Services.DTOs;

namespace FHTW.CodeRunner.Services.Controllers
{
    /// <summary>
    /// All collection operations can be accessed with this controller.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api")]
    public class CollectionApiController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly ICollectionLogic collectionLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionApiController"/> class.
        /// </summary>
        /// <param name="logger">The injected logger.</param>
        /// <param name="mapper">The injected AutoMapper.</param>
        /// <param name="collectionLogic">The injected logic class.</param>
        public CollectionApiController(ILogger<CollectionApiController> logger, IMapper mapper, ICollectionLogic collectionLogic)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.collectionLogic = collectionLogic;
        }

        /// <summary>
        /// Saves a collection to the system.
        /// </summary>
        /// <param name="body">An exercise.</param>
        /// <returns>A Statuscode.</returns>
        [HttpPost]
        [Route("collection")]
        [SwaggerOperation("SaveCollection")]
        [SwaggerResponse(statusCode: 200, description: "Successfully saved the collection")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "The operation failed due to an error.")]
        public virtual IActionResult SaveCollection([FromBody] SvcEntities.Collection body)
        {
            if (body == null)
            {
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = "Collection should not be null",
                });
            }

            try
            {
                var blCollection = this.mapper.Map<BlEntities.Collection>(body);

                this.collectionLogic.SaveCollection(blCollection);
                return this.Ok();
            }
            catch (BlValidationException e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = e.Message,
                });
            }
            catch (BlDataAccessException e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = e.Message,
                });
            }
        }

        /// <summary>
        /// Gets a list of collections.
        /// </summary>
        /// <returns>A list of collections in a minmal format.</returns>
        [HttpGet]
        [Route("collection/minimal")]
        [SwaggerOperation("GetMinimalCollection")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<SvcEntities.MinimalCollection>), description: "Successful response")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "An error occurred loading.")]
        public virtual IActionResult GetMinimalCollection()
        {
            try
            {
                List<BlEntities.MinimalCollection> blMinimalCollections = this.collectionLogic.GetMinimalCollectionList();
                var svcMinimalCollections = this.mapper.Map<List<SvcEntities.MinimalCollection>>(blMinimalCollections);

                return this.Ok(svcMinimalCollections);
            }
            catch (BlValidationException e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = e.Message,
                });
            }
            catch (BlDataAccessException e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = e.Message,
                });
            }
        }

        /// <summary>
        /// Gets a collection by id.
        /// </summary>
        /// <param name="id">The id of the collection.</param>
        /// <returns>A full collection.</returns>
        [HttpGet]
        [Route("collection/{id}")]
        [SwaggerOperation("GetCollectionById")]
        [SwaggerResponse(statusCode: 200, type: typeof(SvcEntities.CollectionView), description: "Successful response")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "An error occurred loading.")]
        public virtual IActionResult GetCollectionById(int id)
        {
            try
            {
                var blCollectionView = this.collectionLogic.GetCollectionView(id);
                var svcCollectinView = this.mapper.Map<SvcEntities.CollectionView>(blCollectionView);

                return this.Ok(svcCollectinView);
            }
            catch (BlValidationException e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = e.Message,
                });
            }
            catch (BlDataAccessException e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = e.Message,
                });
            }
        }

        /// <summary>
        /// Searches and filters for a list of collections.
        /// </summary>
        /// <param name="body">Options for filtering.</param>
        /// <returns>A list of collections in a minmal format.</returns>
        [HttpPost]
        [Route("collection/search")]
        [SwaggerOperation("SearchAndFilterCollections")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<SvcEntities.MinimalCollection>), description: "Successful response")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "An error occurred loading.")]
        public virtual IActionResult SearchAndFilterCollections([FromBody] SvcEntities.SearchCollection body)
        {
            if (body == null)
            {
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = "Search for Collection should not be null",
                });
            }

            try
            {
                var blSearchObject = this.mapper.Map<BlEntities.SearchObject>(body);
                List<BlEntities.MinimalCollection> blMinimalCollectionList = this.collectionLogic.SearchAndFilter(blSearchObject);
                var svcMinimalCollectionList = this.mapper.Map<List<SvcEntities.MinimalCollection>>(blMinimalCollectionList);

                return this.Ok(svcMinimalCollectionList);
            }
            catch (BlValidationException e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = e.Message,
                });
            }
            catch (BlDataAccessException e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = e.Message,
                });
            }
        }
    }
}
