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
    [ExcludeFromCodeCoverage]
    [Table("collection_language")]
    public partial class CollectionLanguage
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("full_title")]
        [StringLength(255)]
        public string FullTitle { get; set; }

        [Required]
        [Column("short_title")]
        [StringLength(255)]
        public string ShortTitle { get; set; }

        [Column("introduction")]
        public string Introduction { get; set; }

        [Column("fk_written_language_id")]
        public int FkWrittenLanguageId { get; set; }

        [ForeignKey(nameof(FkWrittenLanguageId))]
        public WrittenLanguage FkWrittenLanguage { get; set; }

        [Column("fk_collection_id")]
        public int FkCollectionId { get; set; }

        [ForeignKey(nameof(FkCollectionId))]
        [InverseProperty(nameof(Collection.CollectionLanguage))]
        public virtual Collection FkCollection { get; set; }
    }
}
