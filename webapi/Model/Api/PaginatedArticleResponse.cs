using webapi.Model.Entities;

namespace webapi.Model.Api
{
    public class PaginatedArticleResponse:Response<Article>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}
