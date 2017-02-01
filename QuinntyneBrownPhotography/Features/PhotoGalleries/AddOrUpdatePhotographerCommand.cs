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
    public class AddOrUpdatePhotographerCommand
    {
        public class AddOrUpdatePhotographerRequest : IRequest<AddOrUpdatePhotographerResponse>
        {
            public PhotographerApiModel Photographer { get; set; }
        }

        public class AddOrUpdatePhotographerResponse
        {

        }

        public class AddOrUpdatePhotographerHandler : IAsyncRequestHandler<AddOrUpdatePhotographerRequest, AddOrUpdatePhotographerResponse>
        {
            public AddOrUpdatePhotographerHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdatePhotographerResponse> Handle(AddOrUpdatePhotographerRequest request)
            {
                var entity = await _dataContext.Photographers
                    .SingleOrDefaultAsync(x => x.Id == request.Photographer.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Photographers.Add(entity = new Photographer());
                entity.Name = request.Photographer.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdatePhotographerResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
