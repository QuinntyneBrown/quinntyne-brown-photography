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
    public class AddOrUpdateContestEntryCommand
    {
        public class AddOrUpdateContestEntryRequest : IRequest<AddOrUpdateContestEntryResponse>
        {
            public ContestEntryApiModel ContestEntry { get; set; }
        }

        public class AddOrUpdateContestEntryResponse
        {

        }

        public class AddOrUpdateContestEntryHandler : IAsyncRequestHandler<AddOrUpdateContestEntryRequest, AddOrUpdateContestEntryResponse>
        {
            public AddOrUpdateContestEntryHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateContestEntryResponse> Handle(AddOrUpdateContestEntryRequest request)
            {
                var entity = await _dataContext.ContestEntries
                    .SingleOrDefaultAsync(x => x.Id == request.ContestEntry.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.ContestEntries.Add(entity = new ContestEntry());
                entity.Name = request.ContestEntry.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateContestEntryResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
