// <copyright file="CollectionLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Enity for defining the exercises for a certain written language.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class CollectionLanguage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionLanguage"/> class.
        /// </summary>
        public CollectionLanguage()
        {
            this.CollectionExercise = new HashSet<CollectionExercise>();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full title.
        /// </summary>
        [DataMember(Name = "fullTitle")]
        public string FullTitle { get; set; }

        /// <summary>
        /// Gets or sets a short title.
        /// </summary>
        [DataMember(Name = "shortTitle")]
        public string ShortTitle { get; set; }

        /// <summary>
        /// Gets or sets an introduction.
        /// </summary>
        [DataMember(Name = "introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// Gets or sets multiple Collection Exercise entities.
        /// </summary>
        [DataMember(Name = "collectionExerciseList")]
        public ICollection<CollectionExercise> CollectionExercise { get; set; }
    }
}
