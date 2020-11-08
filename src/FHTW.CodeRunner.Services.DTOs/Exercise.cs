// <copyright file="Exercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class Exercise
    {
        public Exercise()
        {
            this.CollectionExercise = new HashSet<CollectionExercise>();
            this.Comment = new HashSet<Comment>();
            this.Difficulty = new HashSet<Difficulty>();
            this.ExerciseTag = new HashSet<ExerciseTag>();
            this.ExerciseVersion = new HashSet<ExerciseVersion>();
            this.Rating = new HashSet<Rating>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        [DataMember(Name = "userId")]
        public int FkUserId { get; set; }

        [DataMember(Name = "user")]
        public Benutzer FkUser { get; set; }

        [DataMember(Name = "collectionExerciseList")]
        public ICollection<CollectionExercise> CollectionExercise { get; set; }

        [DataMember(Name = "commentList")]
        public ICollection<Comment> Comment { get; set; }

        [DataMember(Name = "difficultyList")]
        public ICollection<Difficulty> Difficulty { get; set; }

        [DataMember(Name = "exerciseTagList")]
        public ICollection<ExerciseTag> ExerciseTag { get; set; }

        [DataMember(Name = "exerciseVersionList")]
        public ICollection<ExerciseVersion> ExerciseVersion { get; set; }

        [DataMember(Name = "ratingList")]
        public ICollection<Rating> Rating { get; set; }
    }
}
