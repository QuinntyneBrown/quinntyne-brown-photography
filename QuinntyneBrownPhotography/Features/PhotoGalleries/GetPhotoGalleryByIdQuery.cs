using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class GetPhotoGalleryByIdQuery
    {
        public class GetPhotoGalleryByIdRequest : IRequest<GetPhotoGalleryByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetPhotoGalleryByIdResponse
        {
            public PhotoGalleryApiModel PhotoGallery { get; set; } 
		}

        public class GetPhotoGalleryByIdHandler : IAsyncRequestHandler<GetPhotoGalleryByIdRequest, GetPhotoGalleryByIdResponse>
        {
            public GetPhotoGalleryByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPhotoGalleryByIdResponse> Handle(GetPhotoGalleryByIdRequest request)
            {                
                return new GetPhotoGalleryByIdResponse()
                {
                    PhotoGallery = PhotoGalleryApiModel.FromPhotoGallery(await _dataContext.PhotoGalleries.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
