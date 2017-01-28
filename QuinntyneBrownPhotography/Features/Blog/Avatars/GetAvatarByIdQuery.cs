using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Blog.Avatars
{
    public class GetAvatarByIdQuery
    {
        public class GetAvatarByIdRequest : IAsyncRequest<GetAvatarByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetAvatarByIdResponse
        {
            public AvatarApiModel Avatar { get; set; } 
		}

        public class GetAvatarByIdHandler : IAsyncRequestHandler<GetAvatarByIdRequest, GetAvatarByIdResponse>
        {
            public GetAvatarByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetAvatarByIdResponse> Handle(GetAvatarByIdRequest request)
            {                
                return new GetAvatarByIdResponse()
                {
                    Avatar = AvatarApiModel.FromAvatar(await _dataContext.Avatars.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
