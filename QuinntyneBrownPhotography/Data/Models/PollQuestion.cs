using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuinntyneBrownPhotography.Data.Models
{
    public class PollQuestion
    {
        public int Id { get; set; }
        [ForeignKey("Poll")]
        public int? PollId { get; set; }
        public Poll Poll { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public ICollection<PollQuestionOption> Options { get; set; }
        public bool IsDeleted { get; set; }
    }
}
