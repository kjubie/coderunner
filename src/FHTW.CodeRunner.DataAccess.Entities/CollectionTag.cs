// <copyright file="CollectionTag.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("collection_tag")]
    public partial class CollectionTag
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("fk_tag_id")]
        public int FkTagId { get; set; }

        [Column("fk_collection_id")]
        public int FkCollectionId { get; set; }

        [ForeignKey(nameof(FkCollectionId))]
        [InverseProperty(nameof(Collection.CollectionTag))]
        public virtual Collection FkCollection { get; set; }

        [ForeignKey(nameof(FkTagId))]
        [InverseProperty(nameof(Tag.CollectionTag))]
        public virtual Tag FkTag { get; set; }
    }
}
