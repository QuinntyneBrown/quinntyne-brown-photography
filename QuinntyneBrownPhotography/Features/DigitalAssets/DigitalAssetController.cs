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

        //[AllowAnonymous]
        //[Route("upload")]
        //[HttpPost]
        //public async Task<HttpResponseMessage> Upload(HttpRequestMessage request)
        //{
        //    var digitalAssets = new List<DigitalAsset>();
        //    try
        //    {
        //        if (!Request.Content.IsMimeMultipartContent("form-data"))
        //            throw new HttpResponseException(HttpStatusCode.BadRequest);

        //        var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());

        //        NameValueCollection formData = provider.FormData;
        //        IList<HttpContent> files = provider.Files;

        //        foreach (var file in files)
        //        {
        //            var filename = new FileInfo(file.Headers.ContentDisposition.FileName.Trim(new char[] { '"' })
        //                .Replace("&", "and")).Name;
        //            Stream stream = await file.ReadAsStreamAsync();
        //            var bytes = StreamHelper.ReadToEnd(stream);
        //            var digitalAsset = new DigitalAsset();
        //            digitalAsset.FileName = filename;
        //            digitalAsset.Bytes = bytes;
        //            digitalAsset.ContentType = System.Convert.ToString(file.Headers.ContentType);
        //            _repository.Add(digitalAsset);
        //            digitalAssets.Add(digitalAsset);
        //        }

        //        _uow.SaveChanges();
        //    }
        //    catch (Exception exception)
        //    {
        //        var e = exception;
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, new DigitalAssetUploadResponseDto(digitalAssets));
        //}

        protected readonly QuinntyneBrownPhotographyDataContext _dataContext;
        protected readonly IMediator _mediator;
    }
}
