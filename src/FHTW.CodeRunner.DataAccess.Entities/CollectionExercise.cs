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
    [ExcludeFromCodeCoverage]
    [Table("collection_exercise")]
    public partial class CollectionExercise : IEntity
    {
        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("fk_collection_id")]
        public int FkCollectionId { get; set; }

        [Column("version_number")]
        public int VersionNumber { get; set; }

        [Column("fk_exercise_id")]
        public int FkExerciseId { get; set; }

        [Column("fk_programming_language_id")]
        public int FkProgrammingLanguageId { get; set; }

        [Column("fk_written_language_id")]
        public int FkWrittenLanguageId { get; set; }

        [ForeignKey(nameof(FkCollectionId))]
        [InverseProperty(nameof(Collection.CollectionExercise))]
        public virtual Collection FkCollection { get; set; }

        [ForeignKey(nameof(FkExerciseId))]
        [InverseProperty(nameof(Exercise.CollectionExercise))]
        public virtual Exercise FkExercise { get; set; }

        [ForeignKey(nameof(FkProgrammingLanguageId))]
        [InverseProperty(nameof(ProgrammingLanguage.CollectionExercise))]
        public virtual ProgrammingLanguage FkProgrammingLanguage { get; set; }

        [ForeignKey(nameof(FkWrittenLanguageId))]
        [InverseProperty(nameof(WrittenLanguage.CollectionExercise))]
        public virtual WrittenLanguage FkWrittenLanguage { get; set; }
    }
}
