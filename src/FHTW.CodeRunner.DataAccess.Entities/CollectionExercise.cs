using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("collection_exercise")]
    public partial class CollectionExercise
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("fk_collection_language_id")]
        public int FkCollectionLanguageId { get; set; }
        [Column("version_number")]
        public int VersionNumber { get; set; }
        [Column("fk_exercise_id")]
        public int FkExerciseId { get; set; }
        [Column("fk_programming_language_id")]
        public int FkProgrammingLanguageId { get; set; }
        [Column("fk_written_language_id")]
        public int FkWrittenLanguageId { get; set; }

        [ForeignKey(nameof(FkCollectionLanguageId))]
        [InverseProperty(nameof(CollectionLanguage.CollectionExercise))]
        public virtual CollectionLanguage FkCollectionLanguage { get; set; }
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
