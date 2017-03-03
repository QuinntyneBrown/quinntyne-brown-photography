using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Quizzes
{
    public class GetPollQuestionsQuery
    {
        public class GetPollQuestionsRequest : IRequest<GetPollQuestionsResponse> { }

        public class GetPollQuestionsResponse
        {
            public ICollection<PollQuestionApiModel> PollQuestions { get; set; } = new HashSet<PollQuestionApiModel>();
        }

        public class GetPollQuestionsHandler : IAsyncRequestHandler<GetPollQuestionsRequest, GetPollQuestionsResponse>
        {
            public GetPollQuestionsHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPollQuestionsResponse> Handle(GetPollQuestionsRequest request)
            {
                var pollQuestions = await _dataContext.PollQuestions.ToListAsync();
                return new GetPollQuestionsResponse()
                {
                    PollQuestions = pollQuestions.Select(x => PollQuestionApiModel.FromPollQuestion(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
