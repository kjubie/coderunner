// <copyright file="Collection.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    [ExcludeFromCodeCoverage]
    public class Collection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Collection"/> class.
        /// </summary>
        public Collection()
        {
            this.CollectionLanguage = new HashSet<CollectionLanguage>();
            this.CollectionTag = new HashSet<CollectionTag>();
        }

        public string Title { get; set; }

        public DateTime Created { get; set; }

        public User FkUser { get; set; }

        public ICollection<CollectionLanguage> CollectionLanguage { get; set; }

        public ICollection<CollectionTag> CollectionTag { get; set; }
    }
}
