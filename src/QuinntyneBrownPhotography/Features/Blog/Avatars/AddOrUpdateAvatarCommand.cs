using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Blog.Avatars
{
    public class AddOrUpdateAvatarCommand
    {
        public class AddOrUpdateAvatarRequest : IRequest<AddOrUpdateAvatarResponse>
        {
            public AvatarApiModel Avatar { get; set; }
        }

        public class AddOrUpdateAvatarResponse
        {

        }

        public class AddOrUpdateAvatarHandler : IAsyncRequestHandler<AddOrUpdateAvatarRequest, AddOrUpdateAvatarResponse>
        {
            public AddOrUpdateAvatarHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateAvatarResponse> Handle(AddOrUpdateAvatarRequest request)
            {
                var entity = await _dataContext.Avatars
                    .SingleOrDefaultAsync(x => x.Id == request.Avatar.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Avatars.Add(entity = new Avatar());
                entity.Name = request.Avatar.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateAvatarResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
