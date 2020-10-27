using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("tag")]
    public partial class Tag
    {
        public Tag()
        {
            CollectionTag = new HashSet<CollectionTag>();
            ExerciseTag = new HashSet<ExerciseTag>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty("FkTag")]
        public virtual ICollection<CollectionTag> CollectionTag { get; set; }
        [InverseProperty("FkTag")]
        public virtual ICollection<ExerciseTag> ExerciseTag { get; set; }
    }
}
