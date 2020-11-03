using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class Collection
    {
        public Collection()
        {
            CollectionLanguage = new HashSet<CollectionLanguage>();
            CollectionTag = new HashSet<CollectionTag>();
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

        [DataMember(Name = "collectionLanguageList")]
        public ICollection<CollectionLanguage> CollectionLanguage { get; set; }

        [DataMember(Name = "collectionTagList")]
        public ICollection<CollectionTag> CollectionTag { get; set; }
    }
}
