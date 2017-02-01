using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class GetPhotoByIdQuery
    {
        public class GetPhotoByIdRequest : IRequest<GetPhotoByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetPhotoByIdResponse
        {
            public PhotoApiModel Photo { get; set; } 
		}

        public class GetPhotoByIdHandler : IAsyncRequestHandler<GetPhotoByIdRequest, GetPhotoByIdResponse>
        {
            public GetPhotoByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPhotoByIdResponse> Handle(GetPhotoByIdRequest request)
            {                
                return new GetPhotoByIdResponse()
                {
                    Photo = PhotoApiModel.FromPhoto(await _dataContext.Photos.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
