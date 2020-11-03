using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class Rating
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }

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
