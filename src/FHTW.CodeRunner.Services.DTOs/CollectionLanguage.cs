using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class CollectionLanguage
    {
        public CollectionLanguage()
        {
            CollectionExercise = new HashSet<CollectionExercise>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "fullTitle")]
        public string FullTitle { get; set; }

        [DataMember(Name = "shortTitle")]
        public string ShortTitle { get; set; }

        [DataMember(Name = "introduction")]
        public string Introduction { get; set; }

        [DataMember(Name = "collectionId")]
        public int FkCollectionId { get; set; }

        [DataMember(Name = "collection")]
        public Collection FkCollection { get; set; }

        [DataMember(Name = "collectionExerciseList")]
        public ICollection<CollectionExercise> CollectionExercise { get; set; }
    }
}
