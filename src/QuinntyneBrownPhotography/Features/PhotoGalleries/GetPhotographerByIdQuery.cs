using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class GetPhotographerByIdQuery
    {
        public class GetPhotographerByIdRequest : IRequest<GetPhotographerByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetPhotographerByIdResponse
        {
            public PhotographerApiModel Photographer { get; set; } 
		}

        public class GetPhotographerByIdHandler : IAsyncRequestHandler<GetPhotographerByIdRequest, GetPhotographerByIdResponse>
        {
            public GetPhotographerByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPhotographerByIdResponse> Handle(GetPhotographerByIdRequest request)
            {                
                return new GetPhotographerByIdResponse()
                {
                    Photographer = PhotographerApiModel.FromPhotographer(await _dataContext.Photographers.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
