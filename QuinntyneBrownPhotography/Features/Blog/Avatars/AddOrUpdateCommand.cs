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
    public class AddOrUpdateCommand
    {
        public class AddOrUpdateRequest : IAsyncRequest<AddOrUpdateResponse>
        {
            public AvatarApiModel Avatar { get; set; }
        }

        public class AddOrUpdateResponse
        {
            public AddOrUpdateResponse()
            {

            }
        }

        public class AddOrUpdateHandler : IAsyncRequestHandler<AddOrUpdateRequest, AddOrUpdateResponse>
        {
            public AddOrUpdateHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateResponse> Handle(AddOrUpdateRequest request)
            {
                var entity = await _dataContext.Avatars
                    .SingleOrDefaultAsync(x => x.Id == request.Avatar.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Avatars.Add(entity = new Avatar());
                entity.Name = request.Avatar.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
