using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Data.Dto.News;
using webapi.Data.News;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsController : ControllerBase
{
    private readonly ILogger<NewsController> _logger;
    private readonly INewsService _newsService;

    public NewsController(ILogger<NewsController> logger, INewsService newsService)
    {
        _logger = logger;
        _newsService = newsService;
    }

    [HttpGet(Name = "GetNews")]
    public NewsDto Get()
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpPost(Name = "AddNews")]
    public int Add(NewsDto news)
    {
        int newsId = _newsService.Add(news);
        return newsId;
    }

    //[HttpGet(Name = "GetNewsList")]
    //public IEnumerable<NewsDto> GetList()
    //{
    //    // Здесь вы можете получить список новостей из базы данных или из другого источника данных
    //    var newsList = new List<NewsDto>();

    //    return newsList;
    //}
}
