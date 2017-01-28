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
    public class AddOrUpdateOrderCommand
    {
        public class AddOrUpdateOrderRequest : IAsyncRequest<AddOrUpdateOrderResponse>
        {
            public OrderApiModel Order { get; set; }
        }

        public class AddOrUpdateOrderResponse
        {

        }

        public class AddOrUpdateOrderHandler : IAsyncRequestHandler<AddOrUpdateOrderRequest, AddOrUpdateOrderResponse>
        {
            public AddOrUpdateOrderHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateOrderResponse> Handle(AddOrUpdateOrderRequest request)
            {
                var entity = await _dataContext.Orders
                    .SingleOrDefaultAsync(x => x.Id == request.Order.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Orders.Add(entity = new Order());
                entity.Name = request.Order.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateOrderResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
