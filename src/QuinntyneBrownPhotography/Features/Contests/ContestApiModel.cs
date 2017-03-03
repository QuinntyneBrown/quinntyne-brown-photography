using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Contests
{
    public class ContestApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromContest<TModel>(Contest contest) where
            TModel : ContestApiModel, new()
        {
            var model = new TModel();
            model.Id = contest.Id;
            return model;
        }

        public static ContestApiModel FromContest(Contest contest)
            => FromContest<ContestApiModel>(contest);

    }
}
