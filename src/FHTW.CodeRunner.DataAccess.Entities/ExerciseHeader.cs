// <copyright file="ExerciseHeader.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("exercise_header")]
    public partial class ExerciseHeader
    {
        public ExerciseHeader()
        {
            this.ExerciseLanguage = new HashSet<ExerciseLanguage>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("full_title")]
        [StringLength(255)]
        public string FullTitle { get; set; }

        [Required]
        [Column("short_title")]
        [StringLength(255)]
        public string ShortTitle { get; set; }

        [Column("introduction")]
        public string Introduction { get; set; }

        [InverseProperty("FkExerciseHeader")]
        public virtual ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
