using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.DigitalAssets
{
    public class GetByNameQuery
    {
        public class GetByNameRequest : IRequest<GetByNameResponse>
        {
            public GetByNameRequest()
            {

            }
        }

        public class GetByNameResponse
        {
            public GetByNameResponse()
            {

            }
        }

        public class GetByNameHandler : IAsyncRequestHandler<GetByNameRequest, GetByNameResponse>
        {
            public GetByNameHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetByNameResponse> Handle(GetByNameRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
