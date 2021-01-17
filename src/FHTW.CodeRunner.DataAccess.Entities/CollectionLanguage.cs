// <copyright file="CollectionLanguage.cs" company="FHTW CodeRunner">
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
    /// The collection language contains all written language specific data about the collection.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Table("collection_language")]
    public partial class CollectionLanguage : IEntity
    {
        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the full title of the collection.
        /// The full title is the main heading of the collection.
        /// </summary>
        [Required]
        [Column("full_title")]
        [StringLength(255)]
        public string FullTitle { get; set; }

        /// <summary>
        /// Gets or Sets the short title.
        /// TODO do we need this ?.
        /// </summary>
        [Required]
        [Column("short_title")]
        [StringLength(255)]
        public string ShortTitle { get; set; }

        /// <summary>
        /// Gets or Sets the introduction of the collection.
        /// </summary>
        [Column("introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// Gets or sets the foreign key id of the written language in which the text is written in.
        /// </summary>
        [Column("fk_written_language_id")]
        public int FkWrittenLanguageId { get; set; }

        /// <summary>
        /// Gets or sets the written language in which the text is written in.
        /// </summary>
        [ForeignKey(nameof(FkWrittenLanguageId))]
        public WrittenLanguage FkWrittenLanguage { get; set; }

        /// <summary>
        /// Gets or sets the foreign key id of the collection.
        /// </summary>
        [Column("fk_collection_id")]
        public int FkCollectionId { get; set; }

        [ForeignKey(nameof(FkCollectionId))]
        [InverseProperty(nameof(Collection.CollectionLanguage))]
        public virtual Collection FkCollection { get; set; }
    }
}
