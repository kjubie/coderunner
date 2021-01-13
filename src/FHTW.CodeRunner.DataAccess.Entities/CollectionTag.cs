// <copyright file="CollectionTag.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    /// <summary>
    /// Collection tag is the entity that holds the m:n relationship of the collections and tags.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Table("collection_tag")]
    public partial class CollectionTag : IEntity
    {
        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id for the tag.
        /// </summary>
        [Column("fk_tag_id")]
        public int FkTagId { get; set; }

        /// <summary>
        /// Gets or Sets the foreign key id for the collection.
        /// </summary>
        [Column("fk_collection_id")]
        public int FkCollectionId { get; set; }

        /// <summary>
        /// Gets or Sets the collection.
        /// Inverse property.
        /// </summary>
        [ForeignKey(nameof(FkCollectionId))]
        [InverseProperty(nameof(Collection.CollectionTag))]
        public virtual Collection FkCollection { get; set; }

        /// <summary>
        /// Gets or Sets the tag.
        /// Inverse property.
        /// </summary>
        [ForeignKey(nameof(FkTagId))]
        [InverseProperty(nameof(Tag.CollectionTag))]
        public virtual Tag FkTag { get; set; }
    }
}
