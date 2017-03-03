using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Quizzes
{
    public class AddOrUpdatePollCommand
    {
        public class AddOrUpdatePollRequest : IRequest<AddOrUpdatePollResponse>
        {
            public PollApiModel Poll { get; set; }
        }

        public class AddOrUpdatePollResponse { }

        public class AddOrUpdatePollHandler : IAsyncRequestHandler<AddOrUpdatePollRequest, AddOrUpdatePollResponse>
        {
            public AddOrUpdatePollHandler(QuinntyneBrownPhotographyDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<AddOrUpdatePollResponse> Handle(AddOrUpdatePollRequest request)
            {
                var entity = await _dataContext.Polls
                    .SingleOrDefaultAsync(x => x.Id == request.Poll.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Polls.Add(entity = new Poll());
                entity.Name = request.Poll.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdatePollResponse() { };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
        }

    }

}
