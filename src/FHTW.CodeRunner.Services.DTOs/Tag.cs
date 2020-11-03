using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class Tag
    {
        public Tag()
        {
            CollectionTag = new HashSet<CollectionTag>();
            ExerciseTag = new HashSet<ExerciseTag>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "collectionTagList")]
        public ICollection<CollectionTag> CollectionTag { get; set; }

        [DataMember(Name = "exerciseTagList")]
        public ICollection<ExerciseTag> ExerciseTag { get; set; }
    }
}
