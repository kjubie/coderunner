using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class Collection
    {
        public Collection()
        {
            CollectionLanguage = new HashSet<CollectionLanguage>();
            CollectionTag = new HashSet<CollectionTag>();
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
