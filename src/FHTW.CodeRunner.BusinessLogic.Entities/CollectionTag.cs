using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class CollectionTag
    {
        public int Id { get; set; }

        public int FkTagId { get; set; }

        public int FkCollectionId { get; set; }

        public Collection FkCollection { get; set; }

        public Tag FkTag { get; set; }
    }
}
