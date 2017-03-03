using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuinntyneBrownPhotography.Data.Models
{
    public class PollQuestionOption
    {
        public int Id { get; set; }
        [ForeignKey("PollQuestion")]
        public int? PollQuestionId { get; set; }
        public PollQuestion PollQuestion { get; set; }
        public string ImageUrl { get; set; }
        public string Body { get; set; }
        public bool IsDeleted { get; set; }
    }
}
