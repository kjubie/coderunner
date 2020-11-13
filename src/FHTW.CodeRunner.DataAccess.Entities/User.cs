// <copyright file="User.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("benutzer")]
    public partial class User
    {
        public User()
        {
            this.Collection = new HashSet<Collection>();
            this.Comment = new HashSet<Comment>();
            this.Difficulty = new HashSet<Difficulty>();
            this.Exercise = new HashSet<Exercise>();
            this.ExerciseVersion = new HashSet<ExerciseVersion>();
            this.Rating = new HashSet<Rating>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty("FkUser")]
        public virtual ICollection<Collection> Collection { get; set; }

        [InverseProperty("FkUser")]
        public virtual ICollection<Comment> Comment { get; set; }

        [InverseProperty("FkUser")]
        public virtual ICollection<Difficulty> Difficulty { get; set; }

        [InverseProperty("FkUser")]
        public virtual ICollection<Exercise> Exercise { get; set; }

        [InverseProperty("FkUser")]
        public virtual ICollection<ExerciseVersion> ExerciseVersion { get; set; }

        [InverseProperty("FkUser")]
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
