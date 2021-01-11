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
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        Collection CreateOrUpdate(Collection collection);
    }
}
