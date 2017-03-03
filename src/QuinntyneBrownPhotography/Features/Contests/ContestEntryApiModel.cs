using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Contests
{
    public class ContestEntryApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromContestEntry<TModel>(ContestEntry contestEntry) where
            TModel : ContestEntryApiModel, new()
        {
            var model = new TModel();
            model.Id = contestEntry.Id;
            return model;
        }

        public static ContestEntryApiModel FromContestEntry(ContestEntry contestEntry)
            => FromContestEntry<ContestEntryApiModel>(contestEntry);

    }
}
