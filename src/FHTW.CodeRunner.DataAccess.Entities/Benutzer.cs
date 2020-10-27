using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("benutzer")]
    public partial class Benutzer
    {
        public Benutzer()
        {
            Collection = new HashSet<Collection>();
            Comment = new HashSet<Comment>();
            Difficulty = new HashSet<Difficulty>();
            Exercise = new HashSet<Exercise>();
            ExerciseVersion = new HashSet<ExerciseVersion>();
            Rating = new HashSet<Rating>();
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
