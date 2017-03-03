using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Blog.Avatars
{
    public class GetAvatarsQuery
    {
        public class GetAvatarsRequest : IRequest<GetAvatarsResponse> { }

        public class GetAvatarsResponse
        {
            public ICollection<AvatarApiModel> Avatars { get; set; } = new HashSet<AvatarApiModel>();
        }

        public class GetAvatarsHandler : IAsyncRequestHandler<GetAvatarsRequest, GetAvatarsResponse>
        {
            public GetAvatarsHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetAvatarsResponse> Handle(GetAvatarsRequest request)
            {
                var avatars = await _dataContext.Avatars.ToListAsync();
                return new GetAvatarsResponse()
                {
                    Avatars = avatars.Select(x => AvatarApiModel.FromAvatar(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
