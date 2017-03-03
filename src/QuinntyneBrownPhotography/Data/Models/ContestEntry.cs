using System.ComponentModel.DataAnnotations.Schema;

namespace QuinntyneBrownPhotography.Data.Models
{
    public class ContestEntry
    {
        public int Id { get; set; }
        [ForeignKey("Contest")]
        public int? ContestId { get; set; }
        public Contest Contest { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
