using Microsoft.EntityFrameworkCore;
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

        public int Add(Article news)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Article> res = _context.Articles.Add(news);
            _context.SaveChanges();
            return res.Entity.Id;
        }

        public bool Delete(Article news)
        {
            throw new NotImplementedException();
        }

        public Article Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAllForPeriod(DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page">Number page</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Page number less than 0</exception>
        public IEnumerable<Article> GetArticlesPaginated(int page, int pageSize)
        {
            if (page < 0) {  throw new ArgumentOutOfRangeException(); }

            int skip = page == 0 ? page : page -1;

            IQueryable<Article> article = _context.Articles
                .OrderByDescending(a => a.CreationDate)//Реализовать сортировку фильтром
                .Skip(skip).Take(pageSize)
                .Include(a=> a.Section)
                .Include(a=> a.Tags)
                .Include(a=> a.Image)
                .Include(a=> a.CreatedByUser)
                .Include(a=> a.LastEditedByUser);
            return article;
        }

        public bool Update(Article news)
        {
            throw new NotImplementedException();
        }
    }
}
