// <copyright file="Comment.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class Comment
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        [DataMember(Name = "exerciseId")]
        public int FkExerciseId { get; set; }

        [DataMember(Name = "userId")]
        public int FkUserId { get; set; }

        [DataMember(Name = "exercise")]
        public Exercise FkExercise { get; set; }

        [DataMember(Name = "user")]
        public Benutzer FkUser { get; set; }
    }
}
