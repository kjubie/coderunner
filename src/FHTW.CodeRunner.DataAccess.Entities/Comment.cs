using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("comment")]
    public partial class Comment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("message")]
        public string Message { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("fk_exercise_id")]
        public int FkExerciseId { get; set; }
        [Column("fk_user_id")]
        public int FkUserId { get; set; }

        [ForeignKey(nameof(FkExerciseId))]
        [InverseProperty(nameof(Exercise.Comment))]
        public virtual Exercise FkExercise { get; set; }
        [ForeignKey(nameof(FkUserId))]
        [InverseProperty(nameof(Benutzer.Comment))]
        public virtual Benutzer FkUser { get; set; }
    }
}
