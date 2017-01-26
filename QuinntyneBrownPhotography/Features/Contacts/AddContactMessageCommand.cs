using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Contacts
{
    public class AddContactMessageCommand
    {
        public class AddContactMessageRequest : IAsyncRequest<AddContactMessageResponse>
        {
            public AddContactMessageRequest()
            {

            }
        }

        public class AddContactMessageResponse
        {
            public AddContactMessageResponse()
            {

            }
        }

        public class AddContactMessageHandler : IAsyncRequestHandler<AddContactMessageRequest, AddContactMessageResponse>
        {
            public AddContactMessageHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddContactMessageResponse> Handle(AddContactMessageRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
