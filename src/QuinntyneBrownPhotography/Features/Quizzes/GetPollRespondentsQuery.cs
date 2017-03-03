using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Quizzes
{
    public class GetPollRespondentsQuery
    {
        public class GetPollRespondentsRequest : IRequest<GetPollRespondentsResponse> { }

        public class GetPollRespondentsResponse
        {
            public ICollection<PollRespondentApiModel> PollRespondents { get; set; } = new HashSet<PollRespondentApiModel>();
        }

        public class GetPollRespondentsHandler : IAsyncRequestHandler<GetPollRespondentsRequest, GetPollRespondentsResponse>
        {
            public GetPollRespondentsHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPollRespondentsResponse> Handle(GetPollRespondentsRequest request)
            {
                var pollRespondents = await _dataContext.PollRespondents.ToListAsync();
                return new GetPollRespondentsResponse()
                {
                    PollRespondents = pollRespondents.Select(x => PollRespondentApiModel.FromPollRespondent(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
