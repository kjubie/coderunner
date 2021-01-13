// <copyright file="CollectionInstance.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    /// <summary>
    /// The collection instance is a collection of <see cref="ExerciseInstance"/> and only on <see cref="CollectionLanguage"/>.
    /// This entity is not mapped and therefore readonly.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [NotMapped]
    public class CollectionInstance
    {
        /// <summary>
        /// Gets the id of the collection.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets the internal title of the collection.
        /// </summary>
        public string Title { get; init; }

        /// <summary>
        /// Gets the creation date of the collection.
        /// </summary>
        public DateTime Created { get; init; }

        /// <summary>
        /// Gets the user of the collection.
        /// </summary>
        public User User { get; init; }

        /// <summary>
        /// Gets the header of the collection.
        /// The header is the written language specific part of the collection.
        /// </summary>
        public CollectionLanguage Header { get; init; }

        /// <summary>
        /// Gets the exercise instances of the collection.
        /// </summary>
        public ICollection<ExerciseInstance> Exercises { get; init; }
    }
}
