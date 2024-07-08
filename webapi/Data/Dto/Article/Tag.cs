using System.ComponentModel.DataAnnotations.Schema;
using webapi.Data.Dto.Article;

namespace webapi.Data.Dto.News
{
    [Table("ap_tags")]
    public class Tag:EntityDto
    {
        public List<Article.Article>? Articles { get; set; }
        public List<ArticleTags>? ArticleTags { get; set; }

        public string? ColorCode { get; set; }

    }
}
