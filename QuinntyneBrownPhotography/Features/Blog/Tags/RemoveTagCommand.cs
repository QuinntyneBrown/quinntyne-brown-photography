using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Blog.Tags
{
    public class RemoveTagCommand
    {
        public class RemoveTagRequest : IRequest<RemoveTagResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveTagResponse { }

        public class RemoveTagHandler : IAsyncRequestHandler<RemoveTagRequest, RemoveTagResponse>
        {
            public RemoveTagHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveTagResponse> Handle(RemoveTagRequest request)
            {
                var tag = await _dataContext.Tags.FindAsync(request.Id);
                tag.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveTagResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
