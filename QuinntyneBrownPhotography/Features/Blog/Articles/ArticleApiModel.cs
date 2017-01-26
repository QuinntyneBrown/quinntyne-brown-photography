using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Blog.Articles
{
    public class ArticleApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromArticle<TModel>(Article article) where
            TModel : ArticleApiModel, new()
        {
            var model = new TModel();
            model.Id = article.Id;
            return model;
        }

        public static ArticleApiModel FromArticle(Article article)
            => FromArticle<ArticleApiModel>(article);

    }
}
