using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Model.Entities;

[Table("ap_tags")]
public class Tag : Entity
{
    public List<Article>? Articles { get; set; }
    public List<ArticleTags>? ArticleTags { get; set; }

    public string? ColorCode { get; set; }

}
