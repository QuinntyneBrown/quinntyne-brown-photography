using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Blog.Authors
{
    public class AddOrUpdateAuthorCommand
    {
        public class AddOrUpdateAuthorRequest : IAsyncRequest<AddOrUpdateAuthorResponse>
        {
            public AuthorApiModel Author { get; set; }
        }

        public class AddOrUpdateAuthorResponse
        {

        }

        public class AddOrUpdateAuthorHandler : IAsyncRequestHandler<AddOrUpdateAuthorRequest, AddOrUpdateAuthorResponse>
        {
            public AddOrUpdateAuthorHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateAuthorResponse> Handle(AddOrUpdateAuthorRequest request)
            {
                var entity = await _dataContext.Authors
                    .SingleOrDefaultAsync(x => x.Id == request.Author.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Authors.Add(entity = new Author());
                entity.Name = request.Author.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateAuthorResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
