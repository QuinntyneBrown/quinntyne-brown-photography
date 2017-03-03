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
    public class AddOrUpdatePhotoGalleryCommand
    {
        public class AddOrUpdatePhotoGalleryRequest : IRequest<AddOrUpdatePhotoGalleryResponse>
        {
            public PhotoGalleryApiModel PhotoGallery { get; set; }
        }

        public class AddOrUpdatePhotoGalleryResponse
        {

        }

        public class AddOrUpdatePhotoGalleryHandler : IAsyncRequestHandler<AddOrUpdatePhotoGalleryRequest, AddOrUpdatePhotoGalleryResponse>
        {
            public AddOrUpdatePhotoGalleryHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdatePhotoGalleryResponse> Handle(AddOrUpdatePhotoGalleryRequest request)
            {
                var entity = await _dataContext.PhotoGalleries
                    .SingleOrDefaultAsync(x => x.Id == request.PhotoGallery.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.PhotoGalleries.Add(entity = new PhotoGallery());
                entity.Name = request.PhotoGallery.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdatePhotoGalleryResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
