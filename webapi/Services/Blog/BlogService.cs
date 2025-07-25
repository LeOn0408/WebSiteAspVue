﻿using Microsoft.EntityFrameworkCore;
using webapi.Model;
using webapi.Model.Entities;

namespace webapi.Services.Blog
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
            var article = _context.Articles
                .OrderByDescending(a => a.CreationDate)//Реализовать сортировку фильтром
                .Where(a=>a.Id==id)
                .Include(a => a.Section)
                .Include(a => a.Tags)
                .Include(a => a.Image)
                .Include(a => a.CreatedByUser)
                .Include(a => a.LastEditedByUser)
                .FirstOrDefault();
            return article;
        }

        public CollectionResult<Article> GetAll()
        {
            throw new NotImplementedException();
        }

        public CollectionResult<Article> GetAllForPeriod(DateTime begin, DateTime end)
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
        public CollectionResult<Article> GetArticlesPaginated(int page, int pageSize)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(page);

            int skip = (page-1) * pageSize;

            IQueryable<Article> article = _context.Articles
                .OrderByDescending(a => a.CreationDate)//Реализовать сортировку фильтром
                .Skip(skip).Take(pageSize)
                .Include(a => a.Section)
                .Include(a => a.Tags)
                .Include(a => a.Image)
                .Include(a => a.CreatedByUser)
                .Include(a => a.LastEditedByUser);
            return new CollectionResult<Article>()
            {
                Items = [.. article],
                TotalCount = _context.Articles.Count()
            };
        }

        public bool Update(Article news)
        {
            throw new NotImplementedException();
        }
    }
}
