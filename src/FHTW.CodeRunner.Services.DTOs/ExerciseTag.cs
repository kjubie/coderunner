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

        [DataMember(Name = "tagId")]
        public int FkTagId { get; set; }

        [DataMember(Name = "exerciseId")]
        public int FkExerciseId { get; set; }

        [DataMember(Name = "exercise")]
        public Exercise FkExercise { get; set; }

        [DataMember(Name = "tag")]
        public Tag FkTag { get; set; }
    }
}
