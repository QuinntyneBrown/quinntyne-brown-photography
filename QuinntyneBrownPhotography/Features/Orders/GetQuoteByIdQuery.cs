using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Orders
{
    public class GetQuoteByIdQuery
    {
        public class GetQuoteByIdRequest : IRequest<GetQuoteByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetQuoteByIdResponse
        {
            public QuoteApiModel Quote { get; set; } 
		}

        public class GetQuoteByIdHandler : IAsyncRequestHandler<GetQuoteByIdRequest, GetQuoteByIdResponse>
        {
            public GetQuoteByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetQuoteByIdResponse> Handle(GetQuoteByIdRequest request)
            {                
                return new GetQuoteByIdResponse()
                {
                    Quote = QuoteApiModel.FromQuote(await _dataContext.Quotes.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
