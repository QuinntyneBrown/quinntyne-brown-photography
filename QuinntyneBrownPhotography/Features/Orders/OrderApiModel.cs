using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Orders
{
    public class OrderApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromOrder<TModel>(Order order) where
            TModel : OrderApiModel, new()
        {
            var model = new TModel();
            model.Id = order.Id;
            return model;
        }

        public static OrderApiModel FromOrder(Order order)
            => FromOrder<OrderApiModel>(order);

    }
}
