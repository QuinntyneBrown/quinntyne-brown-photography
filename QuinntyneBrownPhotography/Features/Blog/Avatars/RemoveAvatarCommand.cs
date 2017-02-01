using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Blog.Avatars
{
    public class RemoveAvatarCommand
    {
        public class RemoveAvatarRequest : IRequest<RemoveAvatarResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveAvatarResponse { }

        public class RemoveAvatarHandler : IAsyncRequestHandler<RemoveAvatarRequest, RemoveAvatarResponse>
        {
            public RemoveAvatarHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveAvatarResponse> Handle(RemoveAvatarRequest request)
            {
                var avatar = await _dataContext.Avatars.FindAsync(request.Id);
                avatar.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveAvatarResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
