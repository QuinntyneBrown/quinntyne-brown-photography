using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class GetPhotoGallerysQuery
    {
        public class GetPhotoGallerysRequest : IRequest<GetPhotoGallerysResponse> { }

        public class GetPhotoGallerysResponse
        {
            public ICollection<PhotoGalleryApiModel> PhotoGallerys { get; set; } = new HashSet<PhotoGalleryApiModel>();
        }

        public class GetPhotoGallerysHandler : IAsyncRequestHandler<GetPhotoGallerysRequest, GetPhotoGallerysResponse>
        {
            public GetPhotoGallerysHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPhotoGallerysResponse> Handle(GetPhotoGallerysRequest request)
            {
                var photoGallerys = await _dataContext.PhotoGalleries.ToListAsync();
                return new GetPhotoGallerysResponse()
                {
                    PhotoGallerys = photoGallerys.Select(x => PhotoGalleryApiModel.FromPhotoGallery(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
