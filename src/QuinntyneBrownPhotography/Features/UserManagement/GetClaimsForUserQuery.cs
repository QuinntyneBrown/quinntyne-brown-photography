using MediatR;
using QuinntyneBrownPhotography.Security;
using System;
using System.Threading.Tasks;

namespace QuinntyneBrownPhotography.Features.UserManagement
{
    public class GetClaimsForUserQuery : IAsyncRequestHandler<GetClaimsForUserRequest, GetClaimsForUserResponse>
    {
        public Task<GetClaimsForUserResponse> Handle(GetClaimsForUserRequest message)
        {
            throw new NotImplementedException();
        }
    }
}
