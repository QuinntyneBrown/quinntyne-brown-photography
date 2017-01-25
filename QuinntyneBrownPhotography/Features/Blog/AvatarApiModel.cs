using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Blog
{
    public class AvatarApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromAvatar<TModel>(Avatar avatar) where
            TModel : AvatarApiModel, new()
        {
            var model = new TModel();
            model.Id = avatar.Id;
            return model;
        }

        public static AvatarApiModel FromAvatar(Avatar avatar)
            => FromAvatar<AvatarApiModel>(avatar);

    }
}
