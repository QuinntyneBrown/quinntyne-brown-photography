using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.DigitalAssets
{
    public class GetQuery
    {
        public class GetRequest : IAsyncRequest<GetResponse>
        {
            public GetRequest()
            {

            }
        }

        public class GetResponse
        {
            public GetResponse()
            {

            }
        }

        public class GetHandler : IAsyncRequestHandler<GetRequest, GetResponse>
        {
            public GetHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetResponse> Handle(GetRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
