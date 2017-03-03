namespace QuinntyneBrownPhotography.Data.Models
{
    public class Photographer: LoggableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsDeleted { get; set; }
    }
}
