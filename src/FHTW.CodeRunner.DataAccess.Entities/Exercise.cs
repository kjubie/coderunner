// <copyright file="Exercise.cs" company="FHTW CodeRunner">
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
    /// The exercise is one coderunner question that can be written in different written languages and programming languages.
    /// The exercise can also have tags, comments, difficulty, quality rating and different versions.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Table("exercise")]
    public partial class Exercise : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Exercise"/> class.
        /// </summary>
        public Exercise()
        {
            this.CollectionExercise = new HashSet<CollectionExercise>();
            this.Comment = new HashSet<Comment>();
            this.Difficulty = new HashSet<Difficulty>();
            this.ExerciseTag = new HashSet<ExerciseTag>();
            this.ExerciseVersion = new HashSet<ExerciseVersion>();
            this.Rating = new HashSet<Rating>();
        }

        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the internal title of the exercise.
        /// The internal title is similar to a file name and not visible for the person taking the quiz.
        /// </summary>
        [Required]
        [Column("title")]
        [StringLength(255)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets the creation date of the exercise.
        /// </summary>
        [Required]
        [Column("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id of user that created/owns the exercise.
        /// </summary>
        [Required]
        [Column("fk_user_id")]
        public int FkUserId { get; set; }

        /// <summary>
        /// Gets or Sets the user.
        /// </summary>
        [ForeignKey(nameof(FkUserId))]
        [InverseProperty(nameof(User.Exercise))]
        public virtual User FkUser { get; set; }

        /// <summary>
        /// Gets or Sets the collection exercises that the exercise is part in.
        /// </summary>
        [InverseProperty("FkExercise")]
        public virtual ICollection<CollectionExercise> CollectionExercise { get; set; }

        /// <summary>
        /// Gets or Sets the comments on this exercise.
        /// </summary>
        [InverseProperty("FkExercise")]
        public virtual ICollection<Comment> Comment { get; set; }

        /// <summary>
        /// Gets or Sets the difficulty ratings of this exercise.
        /// </summary>
        [InverseProperty("FkExercise")]
        public virtual ICollection<Difficulty> Difficulty { get; set; }

        /// <summary>
        /// Gets or Sets the tags on this exercise.
        /// </summary>
        [InverseProperty("FkExercise")]
        public virtual ICollection<ExerciseTag> ExerciseTag { get; set; }

        /// <summary>
        /// Gets or Sets the different versions of the exercise.
        /// </summary>
        [InverseProperty("FkExercise")]
        public virtual ICollection<ExerciseVersion> ExerciseVersion { get; set; }

        /// <summary>
        /// Gets or Sets the rating of the exercise.
        /// </summary>
        [InverseProperty("FkExercise")]
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
