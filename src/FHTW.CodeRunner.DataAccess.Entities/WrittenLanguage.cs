using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("written_language")]
    public partial class WrittenLanguage
    {
        public WrittenLanguage()
        {
            CollectionExercise = new HashSet<CollectionExercise>();
            ExerciseLanguage = new HashSet<ExerciseLanguage>();
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
