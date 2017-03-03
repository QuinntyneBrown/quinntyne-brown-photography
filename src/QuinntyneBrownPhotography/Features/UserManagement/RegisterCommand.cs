using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Features.UserManagement
{
    public class RegisterCommand
    {
        public class RegisterRequest : IRequest<RegisterResponse>
        {
            public RegisterRequest()
            {

            }
        }

        public class RegisterResponse
        {
            public RegisterResponse()
            {

            }
        }

        public class RegisterHandler : IAsyncRequestHandler<RegisterRequest, RegisterResponse>
        {
            public RegisterHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RegisterResponse> Handle(RegisterRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
