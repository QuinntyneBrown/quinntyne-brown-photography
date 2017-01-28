using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Orders
{
    public class GetQuotesQuery
    {
        public class GetQuotesRequest : IAsyncRequest<GetQuotesResponse> { }

        public class GetQuotesResponse
        {
            public ICollection<QuoteApiModel> Quotes { get; set; } = new HashSet<QuoteApiModel>();
        }

        public class GetQuotesHandler : IAsyncRequestHandler<GetQuotesRequest, GetQuotesResponse>
        {
            public GetQuotesHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetQuotesResponse> Handle(GetQuotesRequest request)
            {
                var quotes = await _dataContext.Quotes.ToListAsync();
                return new GetQuotesResponse()
                {
                    Quotes = quotes.Select(x => QuoteApiModel.FromQuote(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
