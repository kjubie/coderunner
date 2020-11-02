﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("difficulty")]
    public partial class Difficulty
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("number")]
        public int Number { get; set; }
        [Column("fk_exercise_id")]
        public int FkExerciseId { get; set; }
        [Column("fk_user_id")]
        public int FkUserId { get; set; }

        [ForeignKey(nameof(FkExerciseId))]
        [InverseProperty(nameof(Exercise.Difficulty))]
        public virtual Exercise FkExercise { get; set; }
        [ForeignKey(nameof(FkUserId))]
        [InverseProperty(nameof(Benutzer.Difficulty))]
        public virtual Benutzer FkUser { get; set; }
    }
}