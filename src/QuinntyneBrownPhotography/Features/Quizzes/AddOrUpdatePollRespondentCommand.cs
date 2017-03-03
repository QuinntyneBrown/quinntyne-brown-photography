using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Quizzes
{
    public class AddOrUpdatePollRespondentCommand
    {
        public class AddOrUpdatePollRespondentRequest : IRequest<AddOrUpdatePollRespondentResponse>
        {
            public PollRespondentApiModel PollRespondent { get; set; }
        }

        public class AddOrUpdatePollRespondentResponse
        {

        }

        public class AddOrUpdatePollRespondentHandler : IAsyncRequestHandler<AddOrUpdatePollRespondentRequest, AddOrUpdatePollRespondentResponse>
        {
            public AddOrUpdatePollRespondentHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdatePollRespondentResponse> Handle(AddOrUpdatePollRespondentRequest request)
            {
                var entity = await _dataContext.PollRespondents
                    .SingleOrDefaultAsync(x => x.Id == request.PollRespondent.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.PollRespondents.Add(entity = new PollRespondent());
                entity.Name = request.PollRespondent.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdatePollRespondentResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
