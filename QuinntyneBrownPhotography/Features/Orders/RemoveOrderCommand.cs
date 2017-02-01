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
    public class RemoveOrderCommand
    {
        public class RemoveOrderRequest : IRequest<RemoveOrderResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveOrderResponse { }

        public class RemoveOrderHandler : IAsyncRequestHandler<RemoveOrderRequest, RemoveOrderResponse>
        {
            public RemoveOrderHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveOrderResponse> Handle(RemoveOrderRequest request)
            {
                var order = await _dataContext.Orders.FindAsync(request.Id);
                order.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveOrderResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
