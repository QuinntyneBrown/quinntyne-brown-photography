using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Customers
{
    public class AddOrUpdateCustomerCommand
    {
        public class AddOrUpdateCustomerRequest : IRequest<AddOrUpdateCustomerResponse>
        {
            public CustomerApiModel Customer { get; set; }
        }

        public class AddOrUpdateCustomerResponse
        {

        }

        public class AddOrUpdateCustomerHandler : IAsyncRequestHandler<AddOrUpdateCustomerRequest, AddOrUpdateCustomerResponse>
        {
            public AddOrUpdateCustomerHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateCustomerResponse> Handle(AddOrUpdateCustomerRequest request)
            {
                var entity = await _dataContext.Customers
                    .SingleOrDefaultAsync(x => x.Id == request.Customer.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Customers.Add(entity = new Customer());
                entity.Firstname = request.Customer.Firstname;
                entity.Lastname = request.Customer.Firstname;
                entity.EmailAddress = request.Customer.Firstname;
                entity.PhoneNumber = request.Customer.Firstname;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateCustomerResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
