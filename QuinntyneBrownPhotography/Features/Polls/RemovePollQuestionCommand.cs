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
    public class RemovePollQuestionCommand
    {
        public class RemovePollQuestionRequest : IRequest<RemovePollQuestionResponse>
        {
            public int Id { get; set; }
        }

        public class RemovePollQuestionResponse { }

        public class RemovePollQuestionHandler : IAsyncRequestHandler<RemovePollQuestionRequest, RemovePollQuestionResponse>
        {
            public RemovePollQuestionHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemovePollQuestionResponse> Handle(RemovePollQuestionRequest request)
            {
                var pollQuestion = await _dataContext.PollQuestions.FindAsync(request.Id);
                pollQuestion.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemovePollQuestionResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
