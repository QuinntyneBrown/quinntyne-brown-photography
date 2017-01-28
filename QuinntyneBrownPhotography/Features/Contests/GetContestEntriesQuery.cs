using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Contests
{
    public class GetContestEntriesQuery
    {
        public class GetContestEntrysRequest : IAsyncRequest<GetContestEntriesResponse> { }

        public class GetContestEntriesResponse
        {
            public ICollection<ContestEntryApiModel> ContestEntries { get; set; } = new HashSet<ContestEntryApiModel>();
        }

        public class GetContestEntriesHandler : IAsyncRequestHandler<GetContestEntrysRequest, GetContestEntriesResponse>
        {
            public GetContestEntriesHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetContestEntriesResponse> Handle(GetContestEntrysRequest request)
            {
                var contestEntries = await _dataContext.ContestEntries.ToListAsync();
                return new GetContestEntriesResponse()
                {
                    ContestEntries = contestEntries.Select(x => ContestEntryApiModel.FromContestEntry(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
