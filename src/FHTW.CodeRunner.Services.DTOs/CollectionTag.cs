// <copyright file="CollectionTag.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class CollectionTag
    {
        [DataMember(Name = "collection")]
        public Collection FkCollection { get; set; }

        [DataMember(Name = "tag")]
        public Tag FkTag { get; set; }
    }
}
