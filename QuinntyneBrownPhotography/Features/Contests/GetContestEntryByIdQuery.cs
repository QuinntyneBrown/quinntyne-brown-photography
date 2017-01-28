using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Contests
{
    public class GetContestEntryByIdQuery
    {
        public class GetContestEntryByIdRequest : IAsyncRequest<GetContestEntryByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetContestEntryByIdResponse
        {
            public ContestEntryApiModel ContestEntry { get; set; } 
		}

        public class GetContestEntryByIdHandler : IAsyncRequestHandler<GetContestEntryByIdRequest, GetContestEntryByIdResponse>
        {
            public GetContestEntryByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetContestEntryByIdResponse> Handle(GetContestEntryByIdRequest request)
            {                
                return new GetContestEntryByIdResponse()
                {
                    ContestEntry = ContestEntryApiModel.FromContestEntry(await _dataContext.ContestEntries.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
