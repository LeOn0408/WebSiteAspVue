using System.ComponentModel.DataAnnotations.Schema;
using webapi.Model;

namespace webapi.Model.Blog;

[Table("ap_tags")]
public class Tag : Entity
{
    public List<Article>? Articles { get; set; }
    public List<ArticleTags>? ArticleTags { get; set; }

    public string? ColorCode { get; set; }

}
