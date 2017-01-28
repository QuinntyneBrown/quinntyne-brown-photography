using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Threading.Tasks;

namespace QuinntyneBrownPhotography.Features.Blog.Authors
{
    public class RemoveAuthorCommand
    {
        public class RemoveAuthorRequest : IAsyncRequest<RemoveAuthorResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveAuthorResponse { }

        public class RemoveAuthorHandler : IAsyncRequestHandler<RemoveAuthorRequest, RemoveAuthorResponse>
        {
            public RemoveAuthorHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveAuthorResponse> Handle(RemoveAuthorRequest request)
            {
                var author = await _dataContext.Authors.FindAsync(request.Id);
                author.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveAuthorResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
