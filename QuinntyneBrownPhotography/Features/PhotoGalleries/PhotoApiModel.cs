using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class PhotoApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromPhoto<TModel>(Photo photo) where
            TModel : PhotoApiModel, new()
        {
            var model = new TModel();
            model.Id = photo.Id;
            return model;
        }

        public static PhotoApiModel FromPhoto(Photo photo)
            => FromPhoto<PhotoApiModel>(photo);

    }
}
