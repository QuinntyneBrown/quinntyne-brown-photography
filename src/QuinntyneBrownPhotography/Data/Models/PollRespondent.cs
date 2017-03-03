using System.Collections.Generic;

namespace QuinntyneBrownPhotography.Data.Models
{
    public class PollRespondent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PollAnswer> PollAnswers { get; set; }
        public bool IsDeleted { get; set; }
    }
}
