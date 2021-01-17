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
    /// <summary>
    /// The comment from a user on an exercise.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Table("comment")]
    public partial class Comment : IEntity
    {
        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the text of the comment.
        /// </summary>
        [Required]
        [Column("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets the creation date of the comment.
        /// </summary>
        [Column("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of the exercise.
        /// </summary>
        [Column("fk_exercise_id")]
        public int FkExerciseId { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key if of the user.
        /// </summary>
        [Column("fk_user_id")]
        public int FkUserId { get; set; }

        [ForeignKey(nameof(FkExerciseId))]
        [InverseProperty(nameof(Exercise.Comment))]
        public virtual Exercise FkExercise { get; set; }

        /// <summary>
        /// Gets or Sets the user that wrote the comment.
        /// </summary>
        [ForeignKey(nameof(FkUserId))]
        [InverseProperty(nameof(User.Comment))]
        public virtual User FkUser { get; set; }
    }
}
