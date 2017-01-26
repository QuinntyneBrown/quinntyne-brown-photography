using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Polls
{
    public class PollRespondentApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromPollRespondent<TModel>(PollRespondent pollRespondent) where
            TModel : PollRespondentApiModel, new()
        {
            var model = new TModel();
            model.Id = pollRespondent.Id;
            return model;
        }

        public static PollRespondentApiModel FromPollRespondent(PollRespondent pollRespondent)
            => FromPollRespondent<PollRespondentApiModel>(pollRespondent);

    }
}
