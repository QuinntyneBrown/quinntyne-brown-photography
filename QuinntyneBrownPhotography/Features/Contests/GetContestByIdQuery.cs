using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Contests
{
    public class GetContestByIdQuery
    {
        public class GetContestByIdRequest : IAsyncRequest<GetContestByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetContestByIdResponse
        {
            public ContestApiModel Contest { get; set; } 
		}

        public class GetContestByIdHandler : IAsyncRequestHandler<GetContestByIdRequest, GetContestByIdResponse>
        {
            public GetContestByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetContestByIdResponse> Handle(GetContestByIdRequest request)
            {                
                return new GetContestByIdResponse()
                {
                    Contest = ContestApiModel.FromContest(await _dataContext.Contests.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
