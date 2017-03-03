using MediatR;
using QuinntyneBrownPhotography.Features.DigitalAssets.UploadHandlers;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuinntyneBrownPhotography.Features.DigitalAssets
{
    [Authorize]
    [RoutePrefix("api/digitalasset")]
    public class DigitalAssetController : ApiController
    {
        public DigitalAssetController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [Route("update")]
        [HttpPut]
        public IHttpActionResult Update() { return Ok(); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get() { return Ok(); }

        [Route("getById")]
        [HttpGet]
        public IHttpActionResult GetById(int id) { return Ok(); }

        [Route("remove")]
        [HttpDelete]
        public IHttpActionResult Remove(int id) { return Ok(); }

        [Route("serve")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> Serve([FromUri]ServeQuery.ServeRequest request)
        {
            var response = await _mediator.Send(request);            
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            if (response == null)
                return result;
            result.Content = new ByteArrayContent(response.Bytes);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(response.ContentType);
            return result;
        }

        [AllowAnonymous]
        [Route("upload")]
        [HttpPost]
        public async Task<HttpResponseMessage> Upload(HttpRequestMessage request)
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());

            var response = await _mediator.Send(new UploadDigitalAssetCommand.UploadDigitalAssetRequest() { Provider = provider });

            return Request.CreateResponse(HttpStatusCode.OK, response);            
        }

        protected readonly IMediator _mediator;
    }
}
