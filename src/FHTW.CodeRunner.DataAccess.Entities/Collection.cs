﻿// <copyright file="Collection.cs" company="FHTW CodeRunner">
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
    [Table("collection")]
    public partial class Collection : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Collection"/> class.
        /// </summary>
        public Collection()
        {
            this.CollectionLanguage = new HashSet<CollectionLanguage>();
            this.CollectionTag = new HashSet<CollectionTag>();
            this.CollectionExercise = new HashSet<CollectionExercise>();
        }

        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("created")]
        public DateTime Created { get; set; }

        [Column("fk_user_id")]
        public int FkUserId { get; set; }

        [ForeignKey(nameof(FkUserId))]
        [InverseProperty(nameof(User.Collection))]
        public virtual User FkUser { get; set; }

        [InverseProperty("FkCollection")]
        public virtual ICollection<CollectionLanguage> CollectionLanguage { get; set; }

        [InverseProperty("FkCollection")]
        public virtual ICollection<CollectionTag> CollectionTag { get; set; }

        [InverseProperty("FkCollection")]
        public virtual ICollection<CollectionExercise> CollectionExercise { get; set; }
    }
}
