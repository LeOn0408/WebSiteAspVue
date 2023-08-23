using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Dto.News
{
    [Table("ap_news")]
    public class NewsDto : EntityDto
    {
        [Required]
        public required string Description { get; set; }

        public required ImageDto Image { get; set; }

        public required NewsSectionDto Section { get; set; }

        public required NewsTagDto Tag { get; set; }

    }
}