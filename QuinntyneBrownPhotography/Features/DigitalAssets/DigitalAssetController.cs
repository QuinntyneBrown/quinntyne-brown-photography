using MediatR;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using QuinntyneBrownPhotography.Features.DigitalAssets.UploadHandlers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.OutputCache.V2;

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
            var response = await _mediator.SendAsync(request);            
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

            var response = await _mediator.SendAsync(new UploadDigitalAssetCommand.UploadDigitalAssetRequest() { Provider = provider });

            return Request.CreateResponse(HttpStatusCode.OK, response);            
        }

        protected readonly QuinntyneBrownPhotographyDataContext _dataContext;
        protected readonly IMediator _mediator;
    }
}
