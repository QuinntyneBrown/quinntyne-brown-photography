using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Customers
{
    public class GetCustomersQuery
    {
        public class GetCustomersRequest : IRequest<GetCustomersResponse> { }

        public class GetCustomersResponse
        {
            public ICollection<CustomerApiModel> Customers { get; set; } = new HashSet<CustomerApiModel>();
        }

        public class GetCustomersHandler : IAsyncRequestHandler<GetCustomersRequest, GetCustomersResponse>
        {
            public GetCustomersHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetCustomersResponse> Handle(GetCustomersRequest request)
            {
                var customers = await _dataContext.Customers.ToListAsync();
                return new GetCustomersResponse()
                {
                    Customers = customers.Select(x => CustomerApiModel.FromCustomer(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
