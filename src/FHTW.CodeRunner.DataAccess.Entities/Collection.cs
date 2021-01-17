// <copyright file="Collection.cs" company="FHTW CodeRunner">
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
    /// A collection is a collection of exercises.
    /// It also contains tags and a written language specific part, containing title, introduction and so forth.
    /// </summary>
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

        /// <summary>
        /// Gets or Sets the internal title of the collection.
        /// The internal title is used as an identifier by the user similar to a file name.
        /// </summary>
        [Required]
        [Column("title")]
        [StringLength(255)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets the creation date of the collection.
        /// </summary>
        [Column("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or Sets the user id of the user that created the collection.
        /// </summary>
        [Column("fk_user_id")]
        public int FkUserId { get; set; }

        /// <summary>
        /// Gets or Sets the user that created the collection.
        /// Inverse Property.
        /// </summary>
        [ForeignKey(nameof(FkUserId))]
        [InverseProperty(nameof(User.Collection))]
        public virtual User FkUser { get; set; }

        /// <summary>
        /// Gets or Sets the collection languages.
        /// Contains language specific information about the collection.
        /// </summary>
        [InverseProperty("FkCollection")]
        public virtual ICollection<CollectionLanguage> CollectionLanguage { get; set; }

        /// <summary>
        /// Gets or Sets the collection tags.
        /// </summary>
        [InverseProperty("FkCollection")]
        public virtual ICollection<CollectionTag> CollectionTag { get; set; }

        /// <summary>
        /// Gets or Sets the collection exercises.
        /// </summary>
        [InverseProperty("FkCollection")]
        public virtual ICollection<CollectionExercise> CollectionExercise { get; set; }
    }
}
