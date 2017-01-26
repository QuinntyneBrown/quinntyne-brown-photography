using System.Collections.Generic;

namespace QuinntyneBrownPhotography.Data.Models
{
    public class PollAnswer
    {
        public int Id { get; set; }
        public int? PollRespondentId { get; set; }
        public int? PollQuestionOptionId { get; set; }
        public PollRespondent PollRespondent { get; set; }
        public PollQuestionOption PollQuestionOption { get; set; }
        public bool IsDeleted { get; set; }
    }
}
