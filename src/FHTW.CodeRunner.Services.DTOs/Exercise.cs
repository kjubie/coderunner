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
            this.ExerciseTag = new HashSet<ExerciseTag>();
            this.ExerciseVersion = new HashSet<ExerciseVersion>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        [DataMember(Name = "user")]
        public User FkUser { get; set; }

        [DataMember(Name = "exerciseTagList")]
        public ICollection<ExerciseTag> ExerciseTag { get; set; }

        [DataMember(Name = "exerciseVersionList")]
        public ICollection<ExerciseVersion> ExerciseVersion { get; set; }
    }
}
