using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class GetPhotographersQuery
    {
        public class GetPhotographersRequest : IRequest<GetPhotographersResponse> { }

        public class GetPhotographersResponse
        {
            public ICollection<PhotographerApiModel> Photographers { get; set; } = new HashSet<PhotographerApiModel>();
        }

        public class GetPhotographersHandler : IAsyncRequestHandler<GetPhotographersRequest, GetPhotographersResponse>
        {
            public GetPhotographersHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPhotographersResponse> Handle(GetPhotographersRequest request)
            {
                var photographers = await _dataContext.Photographers.ToListAsync();
                return new GetPhotographersResponse()
                {
                    Photographers = photographers.Select(x => PhotographerApiModel.FromPhotographer(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
