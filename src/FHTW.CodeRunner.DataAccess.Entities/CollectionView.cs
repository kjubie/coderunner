// <copyright file="CollectionView.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    /// <summary>
    /// A view version of the collection entity.
    /// It contains anything necessary to display the collection.
    /// This Entity is not mapped and therefore not managed by the ef core.
    /// All modifications made to the entities will not be persistet.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [NotMapped]
    public class CollectionView
    {
        /// <summary>
        /// Gets projection from Collection to MinimalCollection.
        /// </summary>
        public static Expression<Func<Collection, CollectionView>> FromCollection
        {
            get
            {
                return c => new CollectionView()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Created = c.Created,
                    User = c.FkUser,
                    CollectionLanguages = c.CollectionLanguage.ToList(),
                    TagList = c.CollectionTag.Select(ct => ct.FkTag).ToList(),
                };
            }
        }

        /// <summary>
        /// Gets the id of the collection.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets the title of the collection.
        /// </summary>
        public string Title { get; init; }

        /// <summary>
        /// Gets the creation date of the collection.
        /// </summary>
        public DateTime Created { get; init; }

        /// <summary>
        /// Gets the user that created the collection.
        /// </summary>
        public User User { get; init; }

        /// <summary>
        /// Gets the collection lanugages.
        /// </summary>
        public List<CollectionLanguage> CollectionLanguages { get; init; }

        /// <summary>
        /// Gets a list of tags.
        /// </summary>
        public List<Tag> TagList { get; init; }

        /// <summary>
        /// Gets or Sets the collection exercises.
        /// </summary>
        public List<MinimalCollectionExercise> MinimalCollectionExercises { get; set; }
    }
}
