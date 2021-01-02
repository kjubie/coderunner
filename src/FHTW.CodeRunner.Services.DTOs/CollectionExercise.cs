// <copyright file="CollectionExercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Entity that defines the exercise for the collection.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class CollectionExercise
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [DataMember(Name = "versionNumber")]
        public int VersionNumber { get; set; }

        /// <summary>
        /// Gets or sets the hierarchy for the language.
        /// </summary>
        [DataMember(Name = "collectionLanguage")]
        public CollectionLanguage FkCollectionLanguage { get; set; }

        /// <summary>
        /// Gets or sets an exercise.
        /// </summary>
        [DataMember(Name = "exercise")]
        public Exercise FkExercise { get; set; }

        /// <summary>
        /// Gets or sets a programming language.
        /// </summary>
        [DataMember(Name = "programmingLanguage")]
        public ProgrammingLanguage FkProgrammingLanguage { get; set; }

        /// <summary>
        /// Gets or sets a written language.
        /// </summary>
        [DataMember(Name = "writtenLanguage")]
        public WrittenLanguage FkWrittenLanguage { get; set; }
    }
}
