using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Model.Blog;
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
    public Article Get()
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpPost][Route("add")]
    public int Add(Article news)
    {
        int newsId = _blogService.Add(news);
        return newsId;
    }

    [HttpGet]
    [Route("list")]
    public List<Article> List(int page, int pageSize) 
    {
        List<Article> articles = _blogService.GetArticlesPaginated(page, pageSize).ToList();
        return articles;
    }
    //[HttpGet(Name = "GetNewsList")]
    //public IEnumerable<ArticleDto> GetList()
    //{
    //    // ����� �� ������ �������� ������ �������� �� ���� ������ ��� �� ������� ��������� ������
    //    var newsList = new List<ArticleDto>();

    //    return newsList;
    //}
}

