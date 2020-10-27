using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("collection")]
    public partial class Collection
    {
        public Collection()
        {
            CollectionLanguage = new HashSet<CollectionLanguage>();
            CollectionTag = new HashSet<CollectionTag>();
        }

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
        [InverseProperty(nameof(Benutzer.Collection))]
        public virtual Benutzer FkUser { get; set; }
        [InverseProperty("FkCollection")]
        public virtual ICollection<CollectionLanguage> CollectionLanguage { get; set; }
        [InverseProperty("FkCollection")]
        public virtual ICollection<CollectionTag> CollectionTag { get; set; }
    }
}
