using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
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

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "collectionList")]
        public ICollection<Collection> Collection { get; set; }

        [DataMember(Name = "commentList")]
        public ICollection<Comment> Comment { get; set; }

        [DataMember(Name = "difficultyList")]
        public ICollection<Difficulty> Difficulty { get; set; }

        [DataMember(Name = "exerciseList")]
        public ICollection<Exercise> Exercise { get; set; }

        [DataMember(Name = "exerciseVerionList")]
        public ICollection<ExerciseVersion> ExerciseVersion { get; set; }

        [DataMember(Name = "ratingList")]
        public ICollection<Rating> Rating { get; set; }
    }
}
