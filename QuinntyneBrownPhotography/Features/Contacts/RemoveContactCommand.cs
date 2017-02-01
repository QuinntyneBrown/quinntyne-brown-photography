using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Contacts
{
    public class RemoveContactCommand
    {
        public class RemoveContactRequest : IRequest<RemoveContactResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveContactResponse { }

        public class RemoveContactHandler : IAsyncRequestHandler<RemoveContactRequest, RemoveContactResponse>
        {
            public RemoveContactHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveContactResponse> Handle(RemoveContactRequest request)
            {
                var contact = await _dataContext.Contacts.FindAsync(request.Id);
                contact.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveContactResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
