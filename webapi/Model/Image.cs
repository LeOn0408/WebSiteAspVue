using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Model
{
    [Table("ap_images")]
    public class Image : Entity
    {
        [Required]
        public string Path { get; set; }
    }
}