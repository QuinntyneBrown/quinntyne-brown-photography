using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.Blog.Authors
{
    public class GetAuthorByIdQuery
    {
        public class GetAuthorByIdRequest : IRequest<GetAuthorByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetAuthorByIdResponse
        {
            public AuthorApiModel Author { get; set; } 
		}

        public class GetAuthorByIdHandler : IAsyncRequestHandler<GetAuthorByIdRequest, GetAuthorByIdResponse>
        {
            public GetAuthorByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetAuthorByIdResponse> Handle(GetAuthorByIdRequest request)
            {                
                return new GetAuthorByIdResponse()
                {
                    Author = AuthorApiModel.FromAuthor(await _dataContext.Authors.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
