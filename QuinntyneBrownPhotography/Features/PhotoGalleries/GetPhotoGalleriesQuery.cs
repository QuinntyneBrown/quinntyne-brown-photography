using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class GetPhotoGalleriesQuery
    {
        public class GetPhotoGalleriesRequest : IRequest<GetPhotoGalleriesResponse> { }

        public class GetPhotoGalleriesResponse
        {
            public ICollection<PhotoGalleryApiModel> PhotoGalleries { get; set; } = new HashSet<PhotoGalleryApiModel>();
        }

        public class GetPhotoGalleriesHandler : IAsyncRequestHandler<GetPhotoGalleriesRequest, GetPhotoGalleriesResponse>
        {
            public GetPhotoGalleriesHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPhotoGalleriesResponse> Handle(GetPhotoGalleriesRequest request)
            {
                var photoGalleries = await _dataContext.PhotoGalleries.ToListAsync();
                return new GetPhotoGalleriesResponse()
                {
                    PhotoGalleries = photoGalleries.Select(x => PhotoGalleryApiModel.FromPhotoGallery(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
