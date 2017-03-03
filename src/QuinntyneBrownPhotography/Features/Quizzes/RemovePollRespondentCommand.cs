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
    public class RemovePollRespondentCommand
    {
        public class RemovePollRespondentRequest : IRequest<RemovePollRespondentResponse>
        {
            public int Id { get; set; }
        }

        public class RemovePollRespondentResponse { }

        public class RemovePollRespondentHandler : IAsyncRequestHandler<RemovePollRespondentRequest, RemovePollRespondentResponse>
        {
            public RemovePollRespondentHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemovePollRespondentResponse> Handle(RemovePollRespondentRequest request)
            {
                var pollRespondent = await _dataContext.PollRespondents.FindAsync(request.Id);
                pollRespondent.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemovePollRespondentResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
