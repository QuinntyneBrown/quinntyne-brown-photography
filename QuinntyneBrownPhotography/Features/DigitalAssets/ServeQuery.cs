using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.DigitalAssets
{
    public class ServeQuery
    {
        public class ServeRequest : IAsyncRequest<ServeResponse> { }

        public class ServeResponse
        {
            public byte[] Bytes { get; set; }
            public string ContentType { get; set; }
        }

        public class ServeHandler : IAsyncRequestHandler<ServeRequest, ServeResponse>
        {
            public ServeHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<ServeResponse> Handle(ServeRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
