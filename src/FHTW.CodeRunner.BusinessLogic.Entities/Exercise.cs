using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class Exercise
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

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Created { get; set; }

        public int FkUserId { get; set; }

        public Benutzer FkUser { get; set; }

        public ICollection<CollectionExercise> CollectionExercise { get; set; }

        public ICollection<Comment> Comment { get; set; }

        public ICollection<Difficulty> Difficulty { get; set; }

        public ICollection<ExerciseTag> ExerciseTag { get; set; }

        public ICollection<ExerciseVersion> ExerciseVersion { get; set; }

        public ICollection<Rating> Rating { get; set; }
    }
}
