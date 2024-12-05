using webapi.Model.Blog;
using webapi.Services;

namespace webapi.Services.Blog
{
    public interface IBlogService : IEntityService<Article>
    {
        IEnumerable<Article> GetAllForPeriod(DateTime begin, DateTime end);
        IEnumerable<Article> GetArticlesPaginated(int page, int pageSize);
    }
}
