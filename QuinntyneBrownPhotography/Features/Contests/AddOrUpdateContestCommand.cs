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
    public class AddOrUpdateContestCommand
    {
        public class AddOrUpdateContestRequest : IAsyncRequest<AddOrUpdateContestResponse>
        {
            public ContestApiModel Contest { get; set; }
        }

        public class AddOrUpdateContestResponse
        {

        }

        public class AddOrUpdateContestHandler : IAsyncRequestHandler<AddOrUpdateContestRequest, AddOrUpdateContestResponse>
        {
            public AddOrUpdateContestHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateContestResponse> Handle(AddOrUpdateContestRequest request)
            {
                var entity = await _dataContext.Contests
                    .SingleOrDefaultAsync(x => x.Id == request.Contest.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Contests.Add(entity = new Contest());
                entity.Name = request.Contest.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateContestResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
