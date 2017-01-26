using System.ComponentModel.DataAnnotations.Schema;

namespace QuinntyneBrownPhotography.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Avatar")]
        public int? AvatarId { get; set; }
        public Avatar Avatar { get; set; }
        public bool IsDeleted { get; set; }
    }
}
