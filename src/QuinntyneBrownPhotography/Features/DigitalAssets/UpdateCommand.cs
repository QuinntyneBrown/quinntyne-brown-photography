using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.DigitalAssets
{
    public class UpdateCommand
    {
        public class UpdateRequest : IRequest<UpdateResponse>
        {
            public UpdateRequest()
            {

            }
        }

        public class UpdateResponse
        {
            public UpdateResponse()
            {

            }
        }

        public class UpdateHandler : IAsyncRequestHandler<UpdateRequest, UpdateResponse>
        {
            public UpdateHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<UpdateResponse> Handle(UpdateRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
