// <copyright file="Benutzer.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class Benutzer
    {
        public Benutzer()
        {
            this.Collection = new HashSet<Collection>();
            this.Exercise = new HashSet<Exercise>();
            this.ExerciseVersion = new HashSet<ExerciseVersion>();
            this.Rating = new HashSet<Rating>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Collection> Collection { get; set; }

        public ICollection<Exercise> Exercise { get; set; }

        public ICollection<ExerciseVersion> ExerciseVersion { get; set; }

        public ICollection<Rating> Rating { get; set; }
    }
}
