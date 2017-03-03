using System;

namespace QuinntyneBrownPhotography.Data.Models
{
    public class PollAnswer: ILoggable
    {
        public int Id { get; set; }
        public int? PollRespondentId { get; set; }
        public int? PollQuestionOptionId { get; set; }
        public PollRespondent PollRespondent { get; set; }
        public PollQuestionOption PollQuestionOption { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
