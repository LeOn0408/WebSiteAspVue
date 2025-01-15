using webapi.Model;
using webapi.Model.Entities;
using webapi.Services;

namespace webapi.Services.Blog
{
    public interface IBlogService : IEntityService<Article>
    {
        CollectionResult<Article> GetAllForPeriod(DateTime begin, DateTime end);
        CollectionResult<Article> GetArticlesPaginated(int page, int pageSize);
    }
}
