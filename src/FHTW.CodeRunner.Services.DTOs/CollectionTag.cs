﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class CollectionTag
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "tagId")]
        public int FkTagId { get; set; }

        [DataMember(Name = "collectionId")]
        public int FkCollectionId { get; set; }

        [DataMember(Name = "collection")]
        public Collection FkCollection { get; set; }

        [DataMember(Name = "tag")]
        public Tag FkTag { get; set; }
    }
}
