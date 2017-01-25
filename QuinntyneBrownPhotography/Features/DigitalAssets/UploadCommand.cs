using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.DigitalAssets
{
    public class UploadCommand
    {
        public class UploadRequest : IAsyncRequest<UploadResponse>
        {
            public UploadRequest()
            {

            }
        }

        public class UploadResponse
        {
            public UploadResponse()
            {

            }
        }

        public class UploadHandler : IAsyncRequestHandler<UploadRequest, UploadResponse>
        {
            public UploadHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<UploadResponse> Handle(UploadRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
