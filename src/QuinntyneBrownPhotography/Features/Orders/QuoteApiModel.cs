using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Orders
{
    public class QuoteApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromQuote<TModel>(Quote quote) where
            TModel : QuoteApiModel, new()
        {
            var model = new TModel();
            model.Id = quote.Id;
            return model;
        }

        public static QuoteApiModel FromQuote(Quote quote)
            => FromQuote<QuoteApiModel>(quote);

    }
}
