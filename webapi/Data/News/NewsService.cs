using webapi.Data.Dto.News;

namespace webapi.Data.News
{
    public class NewsService : INewsService
    {
        private DataContext _context;

        public NewsService(DataContext context)
        {
            _context=context;
        }

        public int Add(NewsDto news)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<NewsDto> res = _context.News.Add(news);
            _context.SaveChanges();
            return res.Entity.Id;
        }

        public bool Delete(NewsDto news)
        {
            throw new NotImplementedException();
        }

        public NewsDto Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NewsDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NewsDto> GetAllForPeriod(DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public bool Update(NewsDto news)
        {
            throw new NotImplementedException();
        }
    }
}
