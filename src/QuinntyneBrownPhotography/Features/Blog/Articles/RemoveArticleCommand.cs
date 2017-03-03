using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Blog.Articles
{
    public class RemoveArticleCommand
    {
        public class RemoveArticleRequest : IRequest<RemoveArticleResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveArticleResponse { }

        public class RemoveArticleHandler : IAsyncRequestHandler<RemoveArticleRequest, RemoveArticleResponse>
        {
            public RemoveArticleHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveArticleResponse> Handle(RemoveArticleRequest request)
            {
                var article = await _dataContext.Articles.FindAsync(request.Id);
                article.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveArticleResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
