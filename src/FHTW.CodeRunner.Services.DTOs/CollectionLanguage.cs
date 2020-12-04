// <copyright file="CollectionLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class CollectionLanguage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionLanguage"/> class.
        /// </summary>
        public CollectionLanguage()
        {
            this.CollectionExercise = new HashSet<CollectionExercise>();
        }

        [DataMember(Name = "fullTitle")]
        public string FullTitle { get; set; }

        [DataMember(Name = "shortTitle")]
        public string ShortTitle { get; set; }

        [DataMember(Name = "introduction")]
        public string Introduction { get; set; }

        [DataMember(Name = "collectionId")]
        public int FkCollectionId { get; set; }

        [DataMember(Name = "collection")]
        public Collection FkCollection { get; set; }

        [DataMember(Name = "collectionExerciseList")]
        public ICollection<CollectionExercise> CollectionExercise { get; set; }
    }
}
