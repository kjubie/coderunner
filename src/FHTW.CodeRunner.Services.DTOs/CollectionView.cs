// <copyright file="CollectionView.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// A view version of the collection entity.
    /// It contains anything necessary to display the collection.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class CollectionView
    {
        /// <summary>
        /// Gets or sets the id of the collection.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the collection.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the collection.
        /// </summary>
        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the user that created the collection.
        /// </summary>
        [DataMember(Name = "user")]
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the collection lanugages.
        /// </summary>
        [DataMember(Name = "collectionLanguageList")]
        public List<CollectionLanguage> CollectionLanguages { get; set; }

        /// <summary>
        /// Gets or sets a list of tags.
        /// </summary>
        [DataMember(Name = "collectionTagList")]
        public List<Tag> TagList { get; set; }

        /// <summary>
        /// Gets or sets the collection exercises.
        /// </summary>
        [DataMember(Name = "collectionExerciseList")]
        public List<CollectionExercise> CollectionExercises { get; set; }

        /// <summary>
        /// Gets or Sets the minimal exercises.
        /// </summary>
        [DataMember(Name = "collectionExerciseMinimalList")]
        public List<MinimalExercise> MinimalExercises { get; set; }
    }
}
