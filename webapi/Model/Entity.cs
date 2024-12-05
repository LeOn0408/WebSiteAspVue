using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.Model.Entities;

namespace webapi.Model
{
    public class Entity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime LastEditDate { get; set; }

        public int CreatedByUserId { get; set; }

        public int LastEditedByUserId { get; set; }

        [ForeignKey("CreatedByUserId")]
        public virtual UserEntity CreatedByUser { get; set; }

        [ForeignKey("LastEditedByUserId")]
        public virtual UserEntity LastEditedByUser { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
