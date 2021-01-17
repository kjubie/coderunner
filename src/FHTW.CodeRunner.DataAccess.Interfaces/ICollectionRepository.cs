// <copyright file="ICollectionRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.DataAccess.Entities;

namespace FHTW.CodeRunner.DataAccess.Interfaces
{
    /// <summary>
    /// An enum indicating how the entity wants to be accessed.
    /// </summary>
    public enum Mode
    {
        /// <summary>
        /// The entity is retrieved with not tracking and therefore readonly.
        /// Useful when handling two instances of the same entity.
        /// </summary>
        ReadOnly,

        /// <summary>
        /// The entity can be edited and changes are persisted in the db.
        /// </summary>
        WriteRead,
    }

    /// <summary>
    /// The interface for the collection repository.
    /// </summary>
    public interface ICollectionRepository
    {
        /// <summary>
        /// Queries a the exercise instances of a collection.
        /// </summary>
        /// <param name="id">The id of the collection.</param>
        /// <param name="language">
        ///     The language in which the exercises are queried.
        ///     Leave out or set null to use the language set in the collection exercises.
        ///     TODO what happens if exercises are not available in requested lanugage.
        /// </param>
        /// <returns>The exercise instances of a collection.</returns>
        ICollection<ExerciseInstance> GetExercisesInstances(int id, string language = null);

        /// <summary>
        /// Gets a instance of a collection.
        /// </summary>
        /// <param name="id">The id of the collection.</param>
        /// <param name="language">The requested language of the collection.</param>
        /// <param name="use_set_language">If true uses the language set in each collection exercise, else uses the language parameter.</param>
        /// <returns>The collection instance in the requested language.</returns>
        CollectionInstance GetCollectionInstance(int id, string language, bool use_set_language);

        /// <summary>
        /// Creates a new collection or adds a new one.
        /// Creates a new collection when id is 0.
        /// When updating all fields will be updated except:
        ///     - Created
        ///     - FkUser (The user entity itself)
        ///     - FkUserId (The user that created the collection cannot be changed)
        ///     - CollectionLanuage.FkWrittenLanguage (The entity itself, the id can be changed)
        ///     - CollectionExercise.FkWrittenLanguage (The entity itself, the id can be changed)
        ///     - CollectionExercise.FkProgrammingLanugage (The entity itself, the id can be changed)
        ///     - CollectionTag.FkTag (The entity itself, the id can be changed).
        /// </summary>
        /// <param name="collection">
        ///     The collection with collection_language, collection_exercise and collection tag set.
        /// </param>
        /// <returns>The updated collection, if needed.</returns>
        Collection CreateOrUpdate(Collection collection);

        /// <summary>
        /// Retrieves the collection with the corresponding id.
        /// </summary>
        /// <param name="id">A valid id of an existing collection.</param>
        /// <param name="query_mode">An enum indicating how the entity wants to be accessed.</param>
        /// <returns>The collection with the corresponding id.</returns>
        Collection GetById(int id, Mode query_mode);
    }
}
