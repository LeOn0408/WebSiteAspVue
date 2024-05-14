using webapi.Data.Dto.Article;

namespace webapi.Data.Blog
{
    public class BlogService : IBlogService
    {
        private DataContext _context;

        public BlogService(DataContext context)
        {
            _context = context;
        }

        public int Add(ArticleDto news)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<ArticleDto> res = _context.News.Add(news);
            _context.SaveChanges();
            return res.Entity.Id;
        }

        public bool Delete(ArticleDto news)
        {
            throw new NotImplementedException();
        }

        public ArticleDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleDto> GetAllForPeriod(DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public bool Update(ArticleDto news)
        {
            throw new NotImplementedException();
        }
    }
}
