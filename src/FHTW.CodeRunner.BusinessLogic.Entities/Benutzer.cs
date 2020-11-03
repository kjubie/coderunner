using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class Benutzer
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

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Collection> Collection { get; set; }

        public ICollection<Comment> Comment { get; set; }

        public ICollection<Difficulty> Difficulty { get; set; }

        public ICollection<Exercise> Exercise { get; set; }

        public ICollection<ExerciseVersion> ExerciseVersion { get; set; }

        public ICollection<Rating> Rating { get; set; }
    }
}
