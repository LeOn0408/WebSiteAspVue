using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Model.Api;
using webapi.Model.Entities;
using webapi.Services.Blog;

namespace webapi.Controllers;

[ApiController]
[Route("api/blog")]
public class BlogController : ControllerBase
{
    private readonly ILogger<BlogController> _logger;
    private readonly IBlogService _blogService;

    public BlogController(ILogger<BlogController> logger, IBlogService blogService)
    {
        _logger = logger;
        _blogService = blogService;
    }

    [HttpGet][Route("get")]
    public Article Get(int id)
    {
        return _blogService.Get(id);
    }

    [Authorize]
    [HttpPost][Route("add")]
    public int Add(Article news)
    {
        int newsId = _blogService.Add(news);
        return newsId;
    }

    //TODO: переделать на фильтр
    [HttpGet]
    [Route("list")]
    public Response<Article> List(int page, int pageSize) 
    {
        var paginatedArticles = _blogService.GetArticlesPaginated(page, pageSize);
        PaginatedArticleResponse response = new ()
        {
            Items = paginatedArticles.Items, // Список статей
            CurrentPage = page, // Текущая страница
            PageSize = pageSize, // Размер страницы
            TotalCount = paginatedArticles.TotalCount, // Общее количество статей
            TotalPages = (int)Math.Ceiling((double)paginatedArticles.TotalCount / pageSize) // Общее количество страниц
        };

        return response;
    }
    //[HttpGet(Name = "GetNewsList")]
    //public IEnumerable<ArticleDto> GetList()
    //{
    //    // Здесь вы можете получить список новостей из базы данных или из другого источника данных
    //    var newsList = new List<ArticleDto>();

    //    return newsList;
    //}
}

