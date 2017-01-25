using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Blog
{
    public class TagApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromTag<TModel>(Tag tag) where
            TModel : TagApiModel, new()
        {
            var model = new TModel();
            model.Id = tag.Id;
            return model;
        }

        public static TagApiModel FromTag(Tag tag)
            => FromTag<TagApiModel>(tag);

    }
}
