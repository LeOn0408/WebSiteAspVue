using webapi.Data.Dto.Article;

namespace webapi.Data.Blog
{
    public interface IBlogService : IEntityService<ArticleDto>
    {
        IEnumerable<ArticleDto> GetAllForPeriod(DateTime begin, DateTime end);
    }
}
