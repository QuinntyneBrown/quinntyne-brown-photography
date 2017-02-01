using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class GetPhotosQuery
    {
        public class GetPhotosRequest : IRequest<GetPhotosResponse> { }

        public class GetPhotosResponse
        {
            public ICollection<PhotoApiModel> Photos { get; set; } = new HashSet<PhotoApiModel>();
        }

        public class GetPhotosHandler : IAsyncRequestHandler<GetPhotosRequest, GetPhotosResponse>
        {
            public GetPhotosHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPhotosResponse> Handle(GetPhotosRequest request)
            {
                var photos = await _dataContext.Photos.ToListAsync();
                return new GetPhotosResponse()
                {
                    Photos = photos.Select(x => PhotoApiModel.FromPhoto(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
