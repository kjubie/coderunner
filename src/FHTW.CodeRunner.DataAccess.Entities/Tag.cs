// <copyright file="Tag.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    /// <summary>
    /// A tag for an exercise or collection.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Table("tag")]
    public partial class Tag : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tag"/> class.
        /// </summary>
        public Tag()
        {
            this.CollectionTag = new HashSet<CollectionTag>();
            this.ExerciseTag = new HashSet<ExerciseTag>();
        }

        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the name of the tag.
        /// </summary>
        [Required]
        [Column("name")]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty("FkTag")]
        public virtual ICollection<CollectionTag> CollectionTag { get; set; }

        [InverseProperty("FkTag")]
        public virtual ICollection<ExerciseTag> ExerciseTag { get; set; }
    }
}
