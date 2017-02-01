using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.UserManagement
{
    public class GetCurrentUserQuery
    {
        public class GetCurrentUserRequest : IRequest<GetCurrentUserResponse>
        {
            public GetCurrentUserRequest(string username)
            {
                Username = username;
            }

            public string Username { get; set; }
        }

        public class GetCurrentUserResponse
        {
            public string Username { get; set; }
            public ICollection<RoleApiModel> Roles { get; set; }
        }

        public class GetCurrentUserHandler : IAsyncRequestHandler<GetCurrentUserRequest, GetCurrentUserResponse>
        {
            public GetCurrentUserHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetCurrentUserResponse> Handle(GetCurrentUserRequest request)
            {
                var user = await _dataContext.Users.SingleAsync(x => x.Username == request.Username);
                return new GetCurrentUserResponse()
                {
                    Username = user.Username,
                    Roles = user.Roles.Select(x=> RoleApiModel.FromRole(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
