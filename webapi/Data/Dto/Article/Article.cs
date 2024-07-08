using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.Data.Dto.News;

namespace webapi.Data.Dto.Article
{
    [Table("ap_article")]
    public class Article : EntityDto
    {
        [Required]
        public required string Description { get; set; }

        public required ImageDto Image { get; set; }

        public required Section Section { get; set; }

        public List<Tag>? Tags { get; set; }

        public List<ArticleTags>? ArticleTags { get; set; }

    }

    [Table("ap_article_tag_relation")]
    public class ArticleTags
    {
        public int ArticleId { get; set; }
        public Article? Article { get; set; }

        public int TagId { get; set; }
        public Tag? Tag { get; set; }

        public DateTime LastEditDate { get; set; }= DateTime.Now;
    }
}