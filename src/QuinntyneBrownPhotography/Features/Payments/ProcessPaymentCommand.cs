using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Payments
{
    public class ProcessPaymentCommand
    {
        public class ProcessPaymentRequest : IRequest<ProcessPaymentResponse>
        {
            public ProcessPaymentRequest()
            {

            }
        }

        public class ProcessPaymentResponse
        {
            public ProcessPaymentResponse()
            {

            }
        }

        public class ProcessPaymentHandler : IAsyncRequestHandler<ProcessPaymentRequest, ProcessPaymentResponse>
        {
            public ProcessPaymentHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<ProcessPaymentResponse> Handle(ProcessPaymentRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
