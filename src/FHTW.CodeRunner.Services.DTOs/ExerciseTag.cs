// <copyright file="ExerciseTag.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class ExerciseTag
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "tag")]
        public Tag FkTag { get; set; }
    }
}
