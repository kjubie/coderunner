﻿// <copyright file="Collection.cs" company="FHTW CodeRunner">
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
        /// <summary>
        /// Initializes a new instance of the <see cref="Collection"/> class.
        /// </summary>
        public Collection()
        {
            this.CollectionLanguage = new HashSet<CollectionLanguage>();
            this.CollectionTag = new HashSet<CollectionTag>();
        }

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
        /// Gets or sets the author.
        /// </summary>
        public User FkUser { get; set; }

        /// <summary>
        /// Gets or sets multiple CollectionLanguage Entities.
        /// </summary>
        public ICollection<CollectionLanguage> CollectionLanguage { get; set; }

        /// <summary>
        /// Gets or sets multiple CollectionTage Entities.
        /// </summary>
        public ICollection<CollectionTag> CollectionTag { get; set; }
    }
}
