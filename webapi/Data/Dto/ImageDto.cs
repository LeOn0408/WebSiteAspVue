using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Dto
{
    [Table("ap_images")]
    public class ImageDto : EntityDto
    {
        [Required]
        public string Path { get; set; }
    }
}