using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class RemovePhotoCommand
    {
        public class RemovePhotoRequest : IRequest<RemovePhotoResponse>
        {
            public int Id { get; set; }
        }

        public class RemovePhotoResponse { }

        public class RemovePhotoHandler : IAsyncRequestHandler<RemovePhotoRequest, RemovePhotoResponse>
        {
            public RemovePhotoHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemovePhotoResponse> Handle(RemovePhotoRequest request)
            {
                var photo = await _dataContext.Photos.FindAsync(request.Id);
                photo.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemovePhotoResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
