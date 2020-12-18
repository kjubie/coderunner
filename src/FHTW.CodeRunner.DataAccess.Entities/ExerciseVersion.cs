// <copyright file="ExerciseVersion.cs" company="FHTW CodeRunner">
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
    [Table("exercise_version")]
    public partial class ExerciseVersion : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseVersion"/> class.
        /// </summary>
        public ExerciseVersion()
        {
            this.ExerciseLanguage = new HashSet<ExerciseLanguage>();
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

        [Column("valid_flag")]
        public bool ValidFlag { get; set; }

        [Column("fk_user_id")]
        public int FkUserId { get; set; }

        [Column("fk_exercise_id")]
        public int FkExerciseId { get; set; }

        [ForeignKey(nameof(FkExerciseId))]
        [InverseProperty(nameof(Exercise.ExerciseVersion))]
        public virtual Exercise FkExercise { get; set; }

        [ForeignKey(nameof(FkUserId))]
        [InverseProperty(nameof(User.ExerciseVersion))]
        public virtual User FkUser { get; set; }

        [InverseProperty("FkExerciseVersion")]
        public virtual ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
