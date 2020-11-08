// <copyright file="Collection.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class Collection
    {
        public Collection()
        {
            this.CollectionLanguage = new HashSet<CollectionLanguage>();
            this.CollectionTag = new HashSet<CollectionTag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Created { get; set; }

        public int FkUserId { get; set; }

        public Benutzer FkUser { get; set; }

        public ICollection<CollectionLanguage> CollectionLanguage { get; set; }

        public ICollection<CollectionTag> CollectionTag { get; set; }
    }
}
