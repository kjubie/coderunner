// <copyright file="Rating.cs" company="FHTW CodeRunner">
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
    /// A rating for an exercises quality.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Table("rating")]
    public partial class Rating : IEntity
    {
        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the quality number.
        /// </summary>
        [Column("number")]
        public int Number { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of the exercise.
        /// </summary>
        [Column("fk_exercise_id")]
        public int FkExerciseId { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of the user that made the rating.
        /// </summary>
        [Column("fk_user_id")]
        public int FkUserId { get; set; }

        [ForeignKey(nameof(FkExerciseId))]
        [InverseProperty(nameof(Exercise.Rating))]
        public virtual Exercise FkExercise { get; set; }

        /// <summary>
        /// Gets or Sets the user.
        /// </summary>
        [ForeignKey(nameof(FkUserId))]
        [InverseProperty(nameof(User.Rating))]
        public virtual User FkUser { get; set; }
    }
}
