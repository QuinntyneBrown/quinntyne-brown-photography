using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Utilities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Blog.Authors
{
    public class AddOrUpdateCommand
    {
        public class AddOrUpdateRequest : IAsyncRequest<AddOrUpdateResponse>
        {
            public AuthorApiModel Author { get; set; }
        }

        public class AddOrUpdateResponse
        {

        }

        public class AddOrUpdateHandler : IAsyncRequestHandler<AddOrUpdateRequest, AddOrUpdateResponse>
        {
            public AddOrUpdateHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateResponse> Handle(AddOrUpdateRequest request)
            {
                var entity = await _dataContext.Authors
                    .SingleOrDefaultAsync(x => x.Id == request.Author.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Authors.Add(entity = new Author());
                entity.Name = request.Author.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
