using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Contests
{
    public class RemoveContestEntryCommand
    {
        public class RemoveContestEntryRequest : IAsyncRequest<RemoveContestEntryResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveContestEntryResponse { }

        public class RemoveContestEntryHandler : IAsyncRequestHandler<RemoveContestEntryRequest, RemoveContestEntryResponse>
        {
            public RemoveContestEntryHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveContestEntryResponse> Handle(RemoveContestEntryRequest request)
            {
                var contestEntry = await _dataContext.ContestEntries.FindAsync(request.Id);
                contestEntry.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveContestEntryResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
