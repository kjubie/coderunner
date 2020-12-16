// <copyright file="ExerciseTag.cs" company="FHTW CodeRunner">
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
    [Table("exercise_tag")]
    public partial class ExerciseTag
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("fk_tag_id")]
        public int FkTagId { get; set; }

        [Column("fk_exercise_id")]
        public int FkExerciseId { get; set; }

        [ForeignKey(nameof(FkExerciseId))]
        [InverseProperty(nameof(Exercise.ExerciseTag))]
        public virtual Exercise FkExercise { get; set; }

        [ForeignKey(nameof(FkTagId))]
        [InverseProperty(nameof(Tag.ExerciseTag))]
        public virtual Tag FkTag { get; set; }
    }
}
