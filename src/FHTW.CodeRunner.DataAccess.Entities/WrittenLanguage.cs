// <copyright file="WrittenLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("written_language")]
    public partial class WrittenLanguage : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrittenLanguage"/> class.
        /// </summary>
        public WrittenLanguage()
        {
            this.CollectionExercise = new HashSet<CollectionExercise>();
            this.ExerciseLanguage = new HashSet<ExerciseLanguage>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty("FkWrittenLanguage")]
        public virtual ICollection<CollectionExercise> CollectionExercise { get; set; }

        [InverseProperty("FkWrittenLanguage")]
        public virtual ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
