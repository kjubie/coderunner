// <copyright file="CollectionExercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that defines the exercise for the collection.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CollectionExercise
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the prefered version number for the exercise.
        /// </summary>
        public int VersionNumber { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of the regular exercise.
        /// </summary>
        public int FkExerciseId { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of the prefered programming language.
        /// </summary>
        public int FkProgrammingLanguageId { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of the prefered written language.
        /// </summary>
        public int FkWrittenLanguageId { get; set; }

        /// <summary>
        /// Gets or sets the hierarchy for the language.
        /// </summary>
        public CollectionLanguage FkCollectionLanguage { get; set; }

        /// <summary>
        /// Gets or sets an exercise.
        /// </summary>
        public Exercise FkExercise { get; set; }

        /// <summary>
        /// Gets or sets a programming language.
        /// </summary>
        public ProgrammingLanguage FkProgrammingLanguage { get; set; }

        /// <summary>
        /// Gets or sets a written language.
        /// </summary>
        public WrittenLanguage FkWrittenLanguage { get; set; }
    }
}
