using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuinntyneBrownPhotography.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<ContactMessage> Messages { get; set; } = new HashSet<ContactMessage>();
        public bool IsDeleted { get; set; }
    }

    public class ContactMessage
    {
        public int Id { get; set; }
        [ForeignKey("Contact")]
        public int? ContactId { get; set; }
        public string Body { get; set; }
    }
}
