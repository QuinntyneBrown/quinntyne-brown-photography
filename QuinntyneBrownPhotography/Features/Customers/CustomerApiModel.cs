using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Customers
{
    public class CustomerApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromCustomer<TModel>(Customer customer) where
            TModel : CustomerApiModel, new()
        {
            var model = new TModel();
            model.Id = customer.Id;
            return model;
        }
    }
}
