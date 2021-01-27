// <copyright file="MinimalCollection.cs" company="FHTW CodeRunner">
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
    /// A minimal version of the collection entity.
    /// This Entity is not mapped and therefore not managed by the ef core.
    /// All modifications made to the entities will not be persistet.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [NotMapped]
    public class MinimalCollection
    {
        /// <summary>
        /// Gets projection from Collection to MinimalCollection.
        /// </summary>
        public static Expression<Func<Collection, MinimalCollection>> FromCollection
        {
            get
            {
                return c => new MinimalCollection()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Created = c.Created,
                    ExerciseCount = c.CollectionExercise.Count,
                    User = c.FkUser,
                    WrittenLanguageList = c.CollectionLanguage.Select(cl => cl.FkWrittenLanguage).ToList(),
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
        /// Gets the count of the amount of exercises in the collection.
        /// </summary>
        public int ExerciseCount { get; init; }

        /// <summary>
        /// Gets the user that created the collection.
        /// </summary>
        public User User { get; init; }

        /// <summary>
        /// Gets a list of written languages, in which the collection is available in.
        /// </summary>
        public List<WrittenLanguage> WrittenLanguageList { get; init; }

        /// <summary>
        /// Gets a list of tags.
        /// </summary>
        public List<Tag> TagList { get; init; }
    }
}
