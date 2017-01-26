using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Polls
{
    public class PollAnswerApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromPollAnswer<TModel>(PollAnswer pollAnswer) where
            TModel : PollAnswerApiModel, new()
        {
            var model = new TModel();
            model.Id = pollAnswer.Id;
            return model;
        }

        public static PollAnswerApiModel FromPollAnswer(PollAnswer pollAnswer)
            => FromPollAnswer<PollAnswerApiModel>(pollAnswer);

    }
}
