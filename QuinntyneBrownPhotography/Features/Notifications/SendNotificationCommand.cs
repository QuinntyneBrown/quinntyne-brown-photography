using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Notifications
{
    public class SendNotificationCommand
    {
        public class SendNotificationRequest : IRequest<SendNotificationResponse>
        {
            public SendNotificationRequest()
            {

            }
        }

        public class SendNotificationResponse
        {
            public SendNotificationResponse()
            {

            }
        }

        public class SendNotificationHandler : IAsyncRequestHandler<SendNotificationRequest, SendNotificationResponse>
        {
            public SendNotificationHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<SendNotificationResponse> Handle(SendNotificationRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
