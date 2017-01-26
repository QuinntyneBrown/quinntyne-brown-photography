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
    public class AddOrUpdatePollQuestionCommand
    {
        public class AddOrUpdatePollQuestionRequest : IAsyncRequest<AddOrUpdatePollQuestionResponse>
        {
            public PollQuestionApiModel PollQuestion { get; set; }
        }

        public class AddOrUpdatePollQuestionResponse
        {

        }

        public class AddOrUpdatePollQuestionHandler : IAsyncRequestHandler<AddOrUpdatePollQuestionRequest, AddOrUpdatePollQuestionResponse>
        {
            public AddOrUpdatePollQuestionHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdatePollQuestionResponse> Handle(AddOrUpdatePollQuestionRequest request)
            {
                var entity = await _dataContext.PollQuestions
                    .SingleOrDefaultAsync(x => x.Id == request.PollQuestion.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.PollQuestions.Add(entity = new PollQuestion());
                entity.Name = request.PollQuestion.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdatePollQuestionResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
