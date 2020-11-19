// <copyright file="ExerciseLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("exercise_language")]
    public partial class ExerciseLanguage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseLanguage"/> class.
        /// </summary>
        public ExerciseLanguage()
        {
            this.ExerciseBody = new HashSet<ExerciseBody>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("fk_written_language_id")]
        public int FkWrittenLanguageId { get; set; }

        [Column("fk_exercise_version_id")]
        public int FkExerciseVersionId { get; set; }

        [Column("fk_exercise_header_id")]
        public int FkExerciseHeaderId { get; set; }

        [ForeignKey(nameof(FkExerciseHeaderId))]
        [InverseProperty(nameof(ExerciseHeader.ExerciseLanguage))]
        public virtual ExerciseHeader FkExerciseHeader { get; set; }

        [ForeignKey(nameof(FkExerciseVersionId))]
        [InverseProperty(nameof(ExerciseVersion.ExerciseLanguage))]
        public virtual ExerciseVersion FkExerciseVersion { get; set; }

        [ForeignKey(nameof(FkWrittenLanguageId))]
        [InverseProperty(nameof(WrittenLanguage.ExerciseLanguage))]
        public virtual WrittenLanguage FkWrittenLanguage { get; set; }

        [InverseProperty("FkExerciseLanguage")]
        public virtual ICollection<ExerciseBody> ExerciseBody { get; set; }
    }
}
