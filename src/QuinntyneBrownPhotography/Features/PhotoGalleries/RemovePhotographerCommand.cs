using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class RemovePhotographerCommand
    {
        public class RemovePhotographerRequest : IRequest<RemovePhotographerResponse>
        {
            public int Id { get; set; }
        }

        public class RemovePhotographerResponse { }

        public class RemovePhotographerHandler : IAsyncRequestHandler<RemovePhotographerRequest, RemovePhotographerResponse>
        {
            public RemovePhotographerHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemovePhotographerResponse> Handle(RemovePhotographerRequest request)
            {
                var photographer = await _dataContext.Photographers.FindAsync(request.Id);
                photographer.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemovePhotographerResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
