using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuinntyneBrownPhotography.Data.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }
        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public DateTime? PublishedDate { get; set; }
        public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        public bool IsDeleted { get; set; }
    }
}
