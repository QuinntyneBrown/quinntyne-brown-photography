using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Customers
{
    public class RemoveCustomerCommand
    {
        public class RemoveCustomerRequest : IAsyncRequest<RemoveCustomerResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveCustomerResponse { }

        public class RemoveCustomerHandler : IAsyncRequestHandler<RemoveCustomerRequest, RemoveCustomerResponse>
        {
            public RemoveCustomerHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveCustomerResponse> Handle(RemoveCustomerRequest request)
            {
                var customer = await _dataContext.Customers.FindAsync(request.Id);
                customer.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveCustomerResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
