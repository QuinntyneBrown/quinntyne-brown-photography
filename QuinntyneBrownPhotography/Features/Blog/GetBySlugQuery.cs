using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Blog
{
    public class GetBySlugQuery
    {
        public class GetBySlugRequest : IAsyncRequest<GetBySlugResponse>
        {
            public string Slug { get; set; }
        }

        public class GetBySlugResponse
        {
            public ArticleApiModel Article { get; set; }
        }

        public class GetBySlugHandler : IAsyncRequestHandler<GetBySlugRequest, GetBySlugResponse>
        {
            public GetBySlugHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetBySlugResponse> Handle(GetBySlugRequest request)
            {
                return new GetBySlugResponse()
                {
                    Article = ArticleApiModel.FromArticle(
                        await _dataContext.Articles
                        .Include(x=>x.Author)
                        .Include("Author.Avatar")
                        .SingleAsync(x => x.Slug == request.Slug))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
