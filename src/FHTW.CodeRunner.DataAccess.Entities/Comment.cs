// <copyright file="Comment.cs" company="FHTW CodeRunner">
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
    [Table("comment")]
    public partial class Comment : IEntity
    {
        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("message")]
        public string Message { get; set; }

        [Column("created")]
        public DateTime Created { get; set; }

        [Column("fk_exercise_id")]
        public int FkExerciseId { get; set; }

        [Column("fk_user_id")]
        public int FkUserId { get; set; }

        [ForeignKey(nameof(FkExerciseId))]
        [InverseProperty(nameof(Exercise.Comment))]
        public virtual Exercise FkExercise { get; set; }

        [ForeignKey(nameof(FkUserId))]
        [InverseProperty(nameof(User.Comment))]
        public virtual User FkUser { get; set; }
    }
}
