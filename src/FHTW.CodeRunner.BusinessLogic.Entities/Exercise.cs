// <copyright file="Exercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
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

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Created { get; set; }

        public Benutzer FkUser { get; set; }

        public ICollection<CollectionExercise> CollectionExercise { get; set; }

        public ICollection<Comment> Comment { get; set; }

        public ICollection<Difficulty> Difficulty { get; set; }

        public ICollection<ExerciseTag> ExerciseTag { get; set; }

        public ICollection<ExerciseVersion> ExerciseVersion { get; set; }

        public ICollection<Rating> Rating { get; set; }
    }
}
