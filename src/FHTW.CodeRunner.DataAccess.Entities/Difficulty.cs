// <copyright file="Difficulty.cs" company="FHTW CodeRunner">
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
        [InverseProperty(nameof(User.Difficulty))]
        public virtual User FkUser { get; set; }
    }
}
