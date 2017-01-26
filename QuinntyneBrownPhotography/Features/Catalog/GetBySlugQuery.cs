using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Catalog
{
    public class GetBySlugQuery
    {
        public class GetBySlugRequest : IAsyncRequest<GetBySlugResponse>
        {
            public GetBySlugRequest()
            {

            }
        }

        public class GetBySlugResponse
        {
            public GetBySlugResponse()
            {

            }
        }

        public class GetBySlugHandler : IAsyncRequestHandler<GetBySlugRequest, GetBySlugResponse>
        {
            public GetBySlugHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetBySlugResponse> Handle(GetBySlugRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
