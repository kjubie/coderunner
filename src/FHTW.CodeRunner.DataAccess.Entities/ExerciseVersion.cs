﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("exercise_version")]
    public partial class ExerciseVersion
    {
        public ExerciseVersion()
        {
            ExerciseLanguage = new HashSet<ExerciseLanguage>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("version_number")]
        public int VersionNumber { get; set; }
        [Column("creator_rating")]
        public int? CreatorRating { get; set; }
        [Column("creator_difficulty")]
        public int? CreatorDifficulty { get; set; }
        [Column("last_modified")]
        public DateTime LastModified { get; set; }
        [Column("fk_user_id")]
        public int FkUserId { get; set; }
        [Column("fk_exercise_id")]
        public int FkExerciseId { get; set; }

        [ForeignKey(nameof(FkExerciseId))]
        [InverseProperty(nameof(Exercise.ExerciseVersion))]
        public virtual Exercise FkExercise { get; set; }
        [ForeignKey(nameof(FkUserId))]
        [InverseProperty(nameof(Benutzer.ExerciseVersion))]
        public virtual Benutzer FkUser { get; set; }
        [InverseProperty("FkExerciseVersion")]
        public virtual ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}