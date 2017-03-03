using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuinntyneBrownPhotography.Data.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("PhotoGallery")]
        public int? PhotoGalleryId { get; set; }
        public PhotoGallery PhotoGallery { get; set; }
        public bool IsDeleted { get; set; }
    }
}
