using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Blog.Articles
{
    public class GetArticlesQuery
    {
        public class GetArticlesRequest : IAsyncRequest<GetArticlesResponse> { }

        public class GetArticlesResponse
        {
            public ICollection<ArticleApiModel> Articles { get; set; } = new HashSet<ArticleApiModel>();
        }

        public class GetArticlesHandler : IAsyncRequestHandler<GetArticlesRequest, GetArticlesResponse>
        {
            public GetArticlesHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetArticlesResponse> Handle(GetArticlesRequest request)
            {
                var articles = await _dataContext.Articles.ToListAsync();
                return new GetArticlesResponse()
                {
                    Articles = articles.Select(x => ArticleApiModel.FromArticle(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
