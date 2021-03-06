using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Blog.Authors
{
    public class AuthorApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromAuthor<TModel>(Author author) where
            TModel : AuthorApiModel, new()
        {
            var model = new TModel();
            model.Id = author.Id;
            return model;
        }

        public static AuthorApiModel FromAuthor(Author author)
            => FromAuthor<AuthorApiModel>(author);

    }
}
