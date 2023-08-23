using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.Data.Dto.User;

namespace webapi.Data.Dto
{
    public class EntityDto
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
        public virtual UserDto CreatedByUser { get; set; }

        [ForeignKey("LastEditedByUserId")]
        public virtual UserDto LastEditedByUser { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
