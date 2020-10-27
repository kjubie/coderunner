using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("programming_language")]
    public partial class ProgrammingLanguage
    {
        public ProgrammingLanguage()
        {
            CollectionExercise = new HashSet<CollectionExercise>();
            ExerciseBody = new HashSet<ExerciseBody>();
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
}
