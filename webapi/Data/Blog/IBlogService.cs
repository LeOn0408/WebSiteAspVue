using webapi.Data.Dto.Article;

namespace webapi.Data.Blog
{
    public interface IBlogService : IEntityService<Article>
    {
        IEnumerable<Article> GetAllForPeriod(DateTime begin, DateTime end);
        IEnumerable<Article> GetArticlesPaginated(int page, int pageSize);
    }
}
