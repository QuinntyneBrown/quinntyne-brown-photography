using System.Collections.Generic;

namespace QuinntyneBrownPhotography.Data.Models
{
    public class Contest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ContestEntry> ContestEntries { get; set; }
        public bool IsDeleted { get; set; }
    }
}
