using webapi.Data.Dto.News;

namespace webapi.Data.News
{
    public interface INewsService:IEntityService<NewsDto>
    {
        IEnumerable<NewsDto> GetAllForPeriod(DateTime begin, DateTime end);
    }
}
