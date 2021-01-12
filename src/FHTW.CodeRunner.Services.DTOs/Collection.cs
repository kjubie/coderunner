// <copyright file="Collection.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Entity that holds multiple Exercises.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class Collection
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        [DataMember(Name = "user")]
        public User FkUser { get; set; }

        /// <summary>
        /// Gets or sets multiple CollectionLanguage Entities.
        /// </summary>
        [DataMember(Name = "collectionLanguageList")]
        public ICollection<CollectionLanguage> CollectionLanguage { get; set; }

        /// <summary>
        /// Gets or sets multiple CollectionTage Entities.
        /// </summary>
        [DataMember(Name = "collectionTagList")]
        public ICollection<CollectionTag> CollectionTag { get; set; }

        /// <summary>
        /// Gets or sets multiple exercises.
        /// </summary>
        [DataMember(Name = "collectionExerciseList")]
        public ICollection<CollectionExercise> CollectionExercise { get; set; }
    }
}
