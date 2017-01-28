using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Contests
{
    public class GetContestsQuery
    {
        public class GetContestsRequest : IAsyncRequest<GetContestsResponse> { }

        public class GetContestsResponse
        {
            public ICollection<ContestApiModel> Contests { get; set; } = new HashSet<ContestApiModel>();
        }

        public class GetContestsHandler : IAsyncRequestHandler<GetContestsRequest, GetContestsResponse>
        {
            public GetContestsHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetContestsResponse> Handle(GetContestsRequest request)
            {
                var contests = await _dataContext.Contests.ToListAsync();
                return new GetContestsResponse()
                {
                    Contests = contests.Select(x => ContestApiModel.FromContest(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
