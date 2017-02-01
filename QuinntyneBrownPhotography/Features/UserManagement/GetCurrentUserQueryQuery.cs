using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Threading.Tasks;

namespace QuinntyneBrownPhotography.Features.UserManagement
{
    public class GetCurrentUserQueryQuery
    {
        public class GetCurrentUserQueryRequest : IRequest<GetCurrentUserQueryResponse>
        {
            public GetCurrentUserQueryRequest()
            {

            }
        }

        public class GetCurrentUserQueryResponse
        {
            public GetCurrentUserQueryResponse()
            {

            }
        }

        public class GetCurrentUserQueryHandler : IAsyncRequestHandler<GetCurrentUserQueryRequest, GetCurrentUserQueryResponse>
        {
            public GetCurrentUserQueryHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetCurrentUserQueryResponse> Handle(GetCurrentUserQueryRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
