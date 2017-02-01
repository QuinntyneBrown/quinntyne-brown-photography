using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Orders
{
    public class AddOrUpdateQuoteCommand
    {
        public class AddOrUpdateQuoteRequest : IRequest<AddOrUpdateQuoteResponse>
        {
            public QuoteApiModel Quote { get; set; }
        }

        public class AddOrUpdateQuoteResponse
        {

        }

        public class AddOrUpdateQuoteHandler : IAsyncRequestHandler<AddOrUpdateQuoteRequest, AddOrUpdateQuoteResponse>
        {
            public AddOrUpdateQuoteHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateQuoteResponse> Handle(AddOrUpdateQuoteRequest request)
            {
                var entity = await _dataContext.Quotes
                    .SingleOrDefaultAsync(x => x.Id == request.Quote.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Quotes.Add(entity = new Quote());
                entity.Name = request.Quote.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateQuoteResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
