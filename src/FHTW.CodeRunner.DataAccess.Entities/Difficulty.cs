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
    /// <summary>
    /// The difficulty rating of an exercise made by a different user than the one that created it.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Table("difficulty")]
    public partial class Difficulty : IEntity
    {
        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the difficulty number.
        /// </summary>
        [Column("number")]
        public int Number { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of the exercise.
        /// </summary>
        [Column("fk_exercise_id")]
        public int FkExerciseId { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of user that created the difficulty rating.
        /// </summary>
        [Column("fk_user_id")]
        public int FkUserId { get; set; }

        [ForeignKey(nameof(FkExerciseId))]
        [InverseProperty(nameof(Exercise.Difficulty))]
        public virtual Exercise FkExercise { get; set; }

        /// <summary>
        /// Gets or Sets the user.
        /// Inverse property.
        /// </summary>
        [ForeignKey(nameof(FkUserId))]
        [InverseProperty(nameof(User.Difficulty))]
        public virtual User FkUser { get; set; }
    }
}
