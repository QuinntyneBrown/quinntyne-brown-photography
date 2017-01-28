using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Blog.Tags
{
    public class AddOrUpdateTagCommand
    {
        public class AddOrUpdateTagRequest : IAsyncRequest<AddOrUpdateTagResponse>
        {
            public TagApiModel Tag { get; set; }
        }

        public class AddOrUpdateTagResponse
        {

        }

        public class AddOrUpdateTagHandler : IAsyncRequestHandler<AddOrUpdateTagRequest, AddOrUpdateTagResponse>
        {
            public AddOrUpdateTagHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateTagResponse> Handle(AddOrUpdateTagRequest request)
            {
                var entity = await _dataContext.Tags
                    .SingleOrDefaultAsync(x => x.Id == request.Tag.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Tags.Add(entity = new Tag());
                entity.Name = request.Tag.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateTagResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
