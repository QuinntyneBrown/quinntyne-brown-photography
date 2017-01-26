using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Polls
{
    public class PollApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromPoll<TModel>(Poll poll) where
            TModel : PollApiModel, new()
        {
            var model = new TModel();
            model.Id = poll.Id;
            return model;
        }

        public static PollApiModel FromPoll(Poll poll)
            => FromPoll<PollApiModel>(poll);

    }
}
