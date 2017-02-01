using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class PhotoGalleryApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromPhotoGallery<TModel>(PhotoGallery photoGallery) where
            TModel : PhotoGalleryApiModel, new()
        {
            var model = new TModel();
            model.Id = photoGallery.Id;
            return model;
        }

        public static PhotoGalleryApiModel FromPhotoGallery(PhotoGallery photoGallery)
            => FromPhotoGallery<PhotoGalleryApiModel>(photoGallery);

    }
}
