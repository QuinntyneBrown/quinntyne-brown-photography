using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class AddOrUpdatePhotoCommand
    {
        public class AddOrUpdatePhotoRequest : IRequest<AddOrUpdatePhotoResponse>
        {
            public PhotoApiModel Photo { get; set; }
        }

        public class AddOrUpdatePhotoResponse
        {

        }

        public class AddOrUpdatePhotoHandler : IAsyncRequestHandler<AddOrUpdatePhotoRequest, AddOrUpdatePhotoResponse>
        {
            public AddOrUpdatePhotoHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdatePhotoResponse> Handle(AddOrUpdatePhotoRequest request)
            {
                var entity = await _dataContext.Photos
                    .SingleOrDefaultAsync(x => x.Id == request.Photo.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Photos.Add(entity = new Photo());
                entity.Name = request.Photo.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdatePhotoResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
