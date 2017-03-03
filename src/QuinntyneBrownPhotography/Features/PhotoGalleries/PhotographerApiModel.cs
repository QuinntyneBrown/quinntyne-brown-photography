using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.PhotoGalleries
{
    public class PhotographerApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromPhotographer<TModel>(Photographer photographer) where
            TModel : PhotographerApiModel, new()
        {
            var model = new TModel();
            model.Id = photographer.Id;
            return model;
        }

        public static PhotographerApiModel FromPhotographer(Photographer photographer)
            => FromPhotographer<PhotographerApiModel>(photographer);

    }
}
