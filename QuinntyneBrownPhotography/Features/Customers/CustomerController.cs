using System.Web.Http;

namespace QuinntyneBrownPhotography.Features.Customers
{
    [Authorize]
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        public CustomerController() { }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get() => Ok();
    }
}
