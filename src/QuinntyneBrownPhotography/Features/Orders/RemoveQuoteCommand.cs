using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Orders
{
    public class RemoveQuoteCommand
    {
        public class RemoveQuoteRequest : IRequest<RemoveQuoteResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveQuoteResponse { }

        public class RemoveQuoteHandler : IAsyncRequestHandler<RemoveQuoteRequest, RemoveQuoteResponse>
        {
            public RemoveQuoteHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveQuoteResponse> Handle(RemoveQuoteRequest request)
            {
                var quote = await _dataContext.Quotes.FindAsync(request.Id);
                quote.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveQuoteResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
