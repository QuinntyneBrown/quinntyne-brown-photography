using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Quizzes
{
    public class GetPollRespondentByIdQuery
    {
        public class GetPollRespondentByIdRequest : IRequest<GetPollRespondentByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetPollRespondentByIdResponse
        {
            public PollRespondentApiModel PollRespondent { get; set; } 
		}

        public class GetPollRespondentByIdHandler : IAsyncRequestHandler<GetPollRespondentByIdRequest, GetPollRespondentByIdResponse>
        {
            public GetPollRespondentByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPollRespondentByIdResponse> Handle(GetPollRespondentByIdRequest request)
            {                
                return new GetPollRespondentByIdResponse()
                {
                    PollRespondent = PollRespondentApiModel.FromPollRespondent(await _dataContext.PollRespondents.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
