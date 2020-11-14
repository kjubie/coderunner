// <copyright file="Exercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("exercise")]
    public partial class Exercise
    {
        public Exercise()
        {
            this.CollectionExercise = new HashSet<CollectionExercise>();
            this.Comment = new HashSet<Comment>();
            this.Difficulty = new HashSet<Difficulty>();
            this.ExerciseTag = new HashSet<ExerciseTag>();
            this.ExerciseVersion = new HashSet<ExerciseVersion>();
            this.Rating = new HashSet<Rating>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("created")]
        public DateTime Created { get; set; }

        [Column("fk_user_id")]
        public int FkUserId { get; set; }

        [ForeignKey(nameof(FkUserId))]
        [InverseProperty(nameof(User.Exercise))]
        public virtual User FkUser { get; set; }

        [InverseProperty("FkExercise")]
        public virtual ICollection<CollectionExercise> CollectionExercise { get; set; }

        [InverseProperty("FkExercise")]
        public virtual ICollection<Comment> Comment { get; set; }

        [InverseProperty("FkExercise")]
        public virtual ICollection<Difficulty> Difficulty { get; set; }

        [InverseProperty("FkExercise")]
        public virtual ICollection<ExerciseTag> ExerciseTag { get; set; }

        [InverseProperty("FkExercise")]
        public virtual ICollection<ExerciseVersion> ExerciseVersion { get; set; }

        [InverseProperty("FkExercise")]
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
