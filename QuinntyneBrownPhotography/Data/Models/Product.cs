using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuinntyneBrownPhotography.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        [ForeignKey("ProductCategory")]
        public int? ProductCategoryId { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public bool IsDeleted { get; set; }
    }
}
