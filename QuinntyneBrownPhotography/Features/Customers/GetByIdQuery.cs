using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Customers
{
    public class GetByIdQuery
    {
        public class GetByIdRequest : IAsyncRequest<GetByIdResponse>
        {
            public GetByIdRequest()
            {

            }
        }

        public class GetByIdResponse
        {
            public GetByIdResponse()
            {

            }
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
				throw new System.NotImplementedException();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
