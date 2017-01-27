using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.RSS
{
    public class GetFeedQuery
    {
        public class GetFeedRequest : IAsyncRequest<GetFeedResponse>
        {
            public GetFeedRequest()
            {

            }
        }

        public class GetFeedResponse
        {
            public GetFeedResponse()
            {

            }
        }

        public class GetFeedHandler : IAsyncRequestHandler<GetFeedRequest, GetFeedResponse>
        {
            public GetFeedHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetFeedResponse> Handle(GetFeedRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
