using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Orders
{
    public class GetOrdersQuery
    {
        public class GetOrdersRequest : IAsyncRequest<GetOrdersResponse> { }

        public class GetOrdersResponse
        {
            public ICollection<OrderApiModel> Orders { get; set; } = new HashSet<OrderApiModel>();
        }

        public class GetOrdersHandler : IAsyncRequestHandler<GetOrdersRequest, GetOrdersResponse>
        {
            public GetOrdersHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetOrdersResponse> Handle(GetOrdersRequest request)
            {
                var orders = await _dataContext.Orders.ToListAsync();
                return new GetOrdersResponse()
                {
                    Orders = orders.Select(x => OrderApiModel.FromOrder(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
