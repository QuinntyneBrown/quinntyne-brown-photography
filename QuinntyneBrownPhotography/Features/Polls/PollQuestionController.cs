using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuinntyneBrownPhotography.Features.Polls
{
    [Authorize]
    [RoutePrefix("api/pollQuestion")]
    public class PollQuestionController : ApiController
    {
        public PollQuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdatePollQuestionCommand.AddOrUpdatePollQuestionResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdatePollQuestionCommand.AddOrUpdatePollQuestionRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdatePollQuestionCommand.AddOrUpdatePollQuestionResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdatePollQuestionCommand.AddOrUpdatePollQuestionRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetPollQuestionsQuery.GetPollQuestionsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetPollQuestionsQuery.GetPollQuestionsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetPollQuestionByIdQuery.GetPollQuestionByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetPollQuestionByIdQuery.GetPollQuestionByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemovePollQuestionCommand.RemovePollQuestionResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemovePollQuestionCommand.RemovePollQuestionRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
