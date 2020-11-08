// <copyright file="Benutzer.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

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
            this.Collection = new HashSet<Collection>();
            this.Comment = new HashSet<Comment>();
            this.Difficulty = new HashSet<Difficulty>();
            this.Exercise = new HashSet<Exercise>();
            this.ExerciseVersion = new HashSet<ExerciseVersion>();
            this.Rating = new HashSet<Rating>();
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
