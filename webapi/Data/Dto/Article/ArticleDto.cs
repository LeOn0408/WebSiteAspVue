using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.Data.Dto.News;

namespace webapi.Data.Dto.Article
{
    [Table("ap_article")]
    public class ArticleDto : EntityDto
    {
        [Required]
        public required string Description { get; set; }

        public required ImageDto Image { get; set; }

        public required Section Section { get; set; }

        public required Tag Tag { get; set; }

    }
}