using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Model.Entities;

[Table("ap_article")]
public class Article : Entity
{
    [Required]
    public required string Description { get; set; }

    public required Image Image { get; set; }

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

    public DateTime LastEditDate { get; set; } = DateTime.Now;
}