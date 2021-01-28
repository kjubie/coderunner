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
        /// <returns>The collection with the corresponding id.</returns>
        Collection GetById(int id);

        /// <summary>
        /// Retrieves a list of minimal collections.
        /// </summary>
        /// <returns>list of minimal collections.</returns>
        List<MinimalCollection> GetMinimalCollections();

        /// <summary>
        /// Searches in tags, titles and introduction of the exercise.
        /// Filters by written language of the collection.
        /// </summary>
        /// <param name="search_term">the term to search for.</param>
        /// <param name="written_language">
        ///     the written language to filter by.
        ///     use string.Empty to not use filter.
        /// </param>
        /// <returns>list of minimal collections.</returns>
        List<MinimalCollection> SearchAndFilter(string search_term, string written_language);

        /// <summary>
        /// Retrieves the collectionView entity.
        /// </summary>
        /// <param name="id">the id of the collection.</param>
        /// <returns>the collection view.</returns>
        CollectionView GetCollectionView(int id);
    }
}
