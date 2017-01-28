using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Customers
{
    [Authorize]
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        public CustomerController(IMediator mediator) {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateCustomerCommand.AddOrUpdateCustomerResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateCustomerCommand.AddOrUpdateCustomerRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateCustomerCommand.AddOrUpdateCustomerResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateCustomerCommand.AddOrUpdateCustomerRequest request)
            => Ok(await _mediator.SendAsync(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetCustomersQuery.GetCustomersResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.SendAsync(new GetCustomersQuery.GetCustomersRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetCustomerByIdQuery.GetCustomerByIdResponse))]
        public async Task<IHttpActionResult> GetById(GetCustomerByIdQuery.GetCustomerByIdRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveCustomerCommand.RemoveCustomerResponse))]
        public async Task<IHttpActionResult> Remove(RemoveCustomerCommand.RemoveCustomerRequest request)
            => Ok(await _mediator.SendAsync(request));

        private IMediator _mediator;
    }
}
