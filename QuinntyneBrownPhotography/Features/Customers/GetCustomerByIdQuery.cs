using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Customers
{
    public class GetCustomerByIdQuery
    {
        public class GetCustomerByIdRequest : IAsyncRequest<GetCustomerByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetCustomerByIdResponse
        {
            public CustomerApiModel Customer { get; set; } 
		}

        public class GetCustomerByIdHandler : IAsyncRequestHandler<GetCustomerByIdRequest, GetCustomerByIdResponse>
        {
            public GetCustomerByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdRequest request)
            {                
                return new GetCustomerByIdResponse()
                {
                    Customer = CustomerApiModel.FromCustomer(await _dataContext.Customers.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
