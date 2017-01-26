using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Polls
{
    public class PollQuestionApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromPollQuestion<TModel>(PollQuestion pollQuestion) where
            TModel : PollQuestionApiModel, new()
        {
            var model = new TModel();
            model.Id = pollQuestion.Id;
            return model;
        }

        public static PollQuestionApiModel FromPollQuestion(PollQuestion pollQuestion)
            => FromPollQuestion<PollQuestionApiModel>(pollQuestion);

    }
}
