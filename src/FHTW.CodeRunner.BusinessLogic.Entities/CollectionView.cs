// <copyright file="CollectionView.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// A view version of the collection entity.
    /// It contains anything necessary to display the collection.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CollectionView
    {
        /// <summary>
        /// Gets or sets the id of the collection.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the collection.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the collection.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the user that created the collection.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the collection lanugages.
        /// </summary>
        public List<CollectionLanguage> CollectionLanguages { get; set; }

        /// <summary>
        /// Gets or sets a list of tags.
        /// </summary>
        public List<Tag> TagList { get; set; }

        /// <summary>
        /// Gets or sets the collection exercises.
        /// </summary>
        public List<CollectionExercise> CollectionExercises { get; set; }

        /// <summary>
        /// Gets or Sets the minimal exercises.
        /// </summary>
        public List<MinimalExercise> MinimalExercises { get; set; }
    }
}
