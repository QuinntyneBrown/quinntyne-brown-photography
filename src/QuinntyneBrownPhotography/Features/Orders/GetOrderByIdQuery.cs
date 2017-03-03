using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Orders
{
    public class GetOrderByIdQuery
    {
        public class GetOrderByIdRequest : IRequest<GetOrderByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetOrderByIdResponse
        {
            public OrderApiModel Order { get; set; } 
		}

        public class GetOrderByIdHandler : IAsyncRequestHandler<GetOrderByIdRequest, GetOrderByIdResponse>
        {
            public GetOrderByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request)
            {                
                return new GetOrderByIdResponse()
                {
                    Order = OrderApiModel.FromOrder(await _dataContext.Orders.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
