// <copyright file="ProgrammingLanguage.cs" company="FHTW CodeRunner">
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
    [Table("programming_language")]
    public partial class ProgrammingLanguage : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgrammingLanguage"/> class.
        /// </summary>
        public ProgrammingLanguage()
        {
            this.CollectionExercise = new HashSet<CollectionExercise>();
            this.ExerciseBody = new HashSet<ExerciseBody>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty("FkProgrammingLanguage")]
        public virtual ICollection<CollectionExercise> CollectionExercise { get; set; }

        [InverseProperty("FkProgrammingLanguage")]
        public virtual ICollection<ExerciseBody> ExerciseBody { get; set; }
    }

    [NotMapped]
    public class ProgrammingLanguageComparator : IEqualityComparer<ProgrammingLanguage>
    {
        public bool Equals(ProgrammingLanguage x, ProgrammingLanguage y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }
            else if (x.Id == y.Id && x.Name == y.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(ProgrammingLanguage obj)
        {
            int hash = obj.Id ^ obj.Name.GetHashCode();
            return hash.GetHashCode();
        }
    }
}
