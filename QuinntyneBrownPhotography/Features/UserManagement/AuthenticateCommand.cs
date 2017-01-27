using System;
using System.Threading.Tasks;
using MediatR;
using QuinntyneBrownPhotography.Security;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Utilities;

namespace Slackish.Features.Profiles
{
    public class AuthenticateCommand
    {
        public class AuthenticateCommandHandler : IAsyncRequestHandler<AuthenticateRequest, AuthenticateResponse>
        {
            public AuthenticateCommandHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public Task<AuthenticateResponse> Handle(AuthenticateRequest message)
            {
                throw new NotImplementedException();
            }

            protected QuinntyneBrownPhotographyDataContext _dataContext { get; set; }
            protected ICache _cache { get; set; }
        }
    }
}
