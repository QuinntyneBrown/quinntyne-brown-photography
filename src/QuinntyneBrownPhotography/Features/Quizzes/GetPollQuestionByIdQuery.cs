using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Quizzes
{
    public class GetPollQuestionByIdQuery
    {
        public class GetPollQuestionByIdRequest : IRequest<GetPollQuestionByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetPollQuestionByIdResponse
        {
            public PollQuestionApiModel PollQuestion { get; set; } 
		}

        public class GetPollQuestionByIdHandler : IAsyncRequestHandler<GetPollQuestionByIdRequest, GetPollQuestionByIdResponse>
        {
            public GetPollQuestionByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPollQuestionByIdResponse> Handle(GetPollQuestionByIdRequest request)
            {                
                return new GetPollQuestionByIdResponse()
                {
                    PollQuestion = PollQuestionApiModel.FromPollQuestion(await _dataContext.PollQuestions.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
