// <copyright file="Collection.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that holds multiple Exercises.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Collection
    {
        private User user;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the Foreign Key for the user.
        /// </summary>
        public int FkUserId { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public User FkUser
        {
            get
            {
                return this.user;
            }

            set
            {
                this.user = value;

                if (value != null)
                {
                    this.FkUserId = value.Id;
                }
            }
        }

        /// <summary>
        /// Gets or sets multiple CollectionLanguage Entities.
        /// </summary>
        public ICollection<CollectionLanguage> CollectionLanguage { get; set; }

        /// <summary>
        /// Gets or sets multiple CollectionTage Entities.
        /// </summary>
        public ICollection<CollectionTag> CollectionTag { get; set; }

        /// <summary>
        /// Gets or sets multiple exercises.
        /// </summary>
        public ICollection<CollectionExercise> CollectionExercise { get; set; }
    }
}
