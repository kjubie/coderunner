// <copyright file="User.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    /// <summary>
    /// The User entity.
    /// reg_user stands for registered user, user is a keyword in postgresql.
    /// </summary>
    [Table("reg_user")]
    public partial class User : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.Collection = new HashSet<Collection>();
            this.Comment = new HashSet<Comment>();
            this.Difficulty = new HashSet<Difficulty>();
            this.Exercise = new HashSet<Exercise>();
            this.ExerciseVersion = new HashSet<ExerciseVersion>();
            this.Rating = new HashSet<Rating>();
        }

        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the username of the user.
        /// </summary>
        [Required]
        [Column("name")]
        [StringLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the password hash.
        /// </summary>
        [Required]
        [Column("password")]
        [StringLength(128)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets the inverse property of <see cref="Entities.Collection"/>.
        /// </summary>
        [InverseProperty("FkUser")]
        public virtual ICollection<Collection> Collection { get; set; }

        /// <summary>
        /// Gets or Sets the inverse property of <see cref="Entities.Comment"/>.
        /// </summary>
        [InverseProperty("FkUser")]
        public virtual ICollection<Comment> Comment { get; set; }

        /// <summary>
        /// Gets or Sets the inverse property of <see cref="Entities.Difficulty"/>.
        /// </summary>
        [InverseProperty("FkUser")]
        public virtual ICollection<Difficulty> Difficulty { get; set; }

        /// <summary>
        /// Gets or Sets the inverse property of <see cref="Entities.Exercise"/>.
        /// </summary>
        [InverseProperty("FkUser")]
        public virtual ICollection<Exercise> Exercise { get; set; }

        /// <summary>
        /// Gets or Sets the inverse property of <see cref="Entities.ExerciseVersion"/>.
        /// </summary>
        [InverseProperty("FkUser")]
        public virtual ICollection<ExerciseVersion> ExerciseVersion { get; set; }

        /// <summary>
        /// Gets or Sets the inverse property of <see cref="Entities.Rating"/>.
        /// </summary>
        [InverseProperty("FkUser")]
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
