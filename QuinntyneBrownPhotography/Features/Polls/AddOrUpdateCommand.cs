using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Polls
{
    public class AddOrUpdateCommand
    {
        public class AddOrUpdateRequest : IAsyncRequest<AddOrUpdateResponse>
        {
            public PollApiModel Poll { get; set; }
        }

        public class AddOrUpdateResponse
        {

        }

        public class AddOrUpdateHandler : IAsyncRequestHandler<AddOrUpdateRequest, AddOrUpdateResponse>
        {
            public AddOrUpdateHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateResponse> Handle(AddOrUpdateRequest request)
            {
                var entity = await _dataContext.Polls
                    .SingleOrDefaultAsync(x => x.Id == request.Poll.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Polls.Add(entity = new Poll());
                entity.Name = request.Poll.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
