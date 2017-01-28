using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Blog.Articles
{
    public class GetArticleByIdQuery
    {
        public class GetArticleByIdRequest : IAsyncRequest<GetArticleByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetArticleByIdResponse
        {
            public ArticleApiModel Article { get; set; } 
		}

        public class GetArticleByIdHandler : IAsyncRequestHandler<GetArticleByIdRequest, GetArticleByIdResponse>
        {
            public GetArticleByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetArticleByIdResponse> Handle(GetArticleByIdRequest request)
            {                
                return new GetArticleByIdResponse()
                {
                    Article = ArticleApiModel.FromArticle(await _dataContext.Articles.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
