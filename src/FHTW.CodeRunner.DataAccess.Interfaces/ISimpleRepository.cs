// <copyright file="ISimpleRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.DataAccess.Interfaces
{
    /// <summary>
    /// Interface for the genric base repository.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity.</typeparam>
    public interface ISimpleRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Retrieves the entity from the data provider with the corresponding id.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns>The instance of the entity.</returns>
        TEntity GetById(int id);

        /// <summary>
        /// Retrieves all instances of the entity.
        /// </summary>
        /// <returns>A collection of the entities.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Inserts a new entity instance into the data provider.
        /// </summary>
        /// <param name="entity">The entity to be inserted.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Updates an already existing entity.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes the data entry with the corresponding id.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Saves all changes made.
        /// </summary>
        void Save();

        /// <summary>
        /// Checks if an entity exists.
        /// </summary>
        /// <param name="entity">The entity that should or shouldn't exist.</param>
        /// <returns>True if the entity exists.</returns>
        bool Exists(TEntity entity);
    }
}
