using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.DigitalAssets
{
    public class GetByIdQuery
    {
        public class GetByIdRequest : IRequest<GetByIdResponse>
        {
            public int Id { get; set; }
        }

        public class GetByIdResponse
        {
            public DigitalAssetApiModel DigitalAsset { get; set; }
        }

        public class GetByIdHandler : IAsyncRequestHandler<GetByIdRequest, GetByIdResponse>
        {
            public GetByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetByIdResponse> Handle(GetByIdRequest request)
            {
                return new GetByIdResponse() {
                    DigitalAsset = DigitalAssetApiModel
                    .FromDigitalAsset(await _dataContext.DigitalAssets.Where(x => x.Id == request.Id).SingleAsync())
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
