using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class RemovePhotoGalleryCommand
    {
        public class RemovePhotoGalleryRequest : IRequest<RemovePhotoGalleryResponse>
        {
            public int Id { get; set; }
        }

        public class RemovePhotoGalleryResponse { }

        public class RemovePhotoGalleryHandler : IAsyncRequestHandler<RemovePhotoGalleryRequest, RemovePhotoGalleryResponse>
        {
            public RemovePhotoGalleryHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemovePhotoGalleryResponse> Handle(RemovePhotoGalleryRequest request)
            {
                var photoGallery = await _dataContext.PhotoGalleries.FindAsync(request.Id);
                photoGallery.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemovePhotoGalleryResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
