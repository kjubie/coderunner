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
            CollectionExercise = new HashSet<CollectionExercise>();
            Comment = new HashSet<Comment>();
            Difficulty = new HashSet<Difficulty>();
            ExerciseTag = new HashSet<ExerciseTag>();
            ExerciseVersion = new HashSet<ExerciseVersion>();
            Rating = new HashSet<Rating>();
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
        [InverseProperty(nameof(Benutzer.Exercise))]
        public virtual Benutzer FkUser { get; set; }
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
