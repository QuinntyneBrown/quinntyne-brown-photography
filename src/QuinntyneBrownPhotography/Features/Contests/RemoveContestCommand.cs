using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Contests
{
    public class RemoveContestCommand
    {
        public class RemoveContestRequest : IRequest<RemoveContestResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveContestResponse { }

        public class RemoveContestHandler : IAsyncRequestHandler<RemoveContestRequest, RemoveContestResponse>
        {
            public RemoveContestHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveContestResponse> Handle(RemoveContestRequest request)
            {
                var contest = await _dataContext.Contests.FindAsync(request.Id);
                contest.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveContestResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
