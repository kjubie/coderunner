// <copyright file="CollectionExercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    /// <summary>
    /// The collection exercise is a wrapper around a regular <see cref="Exercise"/>.
    /// It allows preferences to be set for version, written language and programming language.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Table("collection_exercise")]
    public partial class CollectionExercise : IEntity
    {
        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of the collection.
        /// </summary>
        [Column("fk_collection_id")]
        public int FkCollectionId { get; set; }

        /// <summary>
        /// Gets or Sets the prefered version number for the exercise.
        /// </summary>
        [Column("version_number")]
        public int VersionNumber { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of the regular exercise.
        /// </summary>
        [Column("fk_exercise_id")]
        public int FkExerciseId { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of the prefered programming language.
        /// </summary>
        [Column("fk_programming_language_id")]
        public int FkProgrammingLanguageId { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of the prefered written language.
        /// </summary>
        [Column("fk_written_language_id")]
        public int FkWrittenLanguageId { get; set; }

        [ForeignKey(nameof(FkCollectionId))]
        [InverseProperty(nameof(Collection.CollectionExercise))]
        public virtual Collection FkCollection { get; set; }

        [ForeignKey(nameof(FkExerciseId))]
        [InverseProperty(nameof(Exercise.CollectionExercise))]
        public virtual Exercise FkExercise { get; set; }

        /// <summary>
        /// Gets or Sets the prefered programming language.
        /// Inverse poperty.
        /// </summary>
        [ForeignKey(nameof(FkProgrammingLanguageId))]
        [InverseProperty(nameof(ProgrammingLanguage.CollectionExercise))]
        public virtual ProgrammingLanguage FkProgrammingLanguage { get; set; }

        /// <summary>
        /// Gets or Sets the prefered written language.
        /// Inverse poperty.
        /// </summary>
        [ForeignKey(nameof(FkWrittenLanguageId))]
        [InverseProperty(nameof(WrittenLanguage.CollectionExercise))]
        public virtual WrittenLanguage FkWrittenLanguage { get; set; }
    }
}
