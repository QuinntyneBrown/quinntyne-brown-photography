using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Customers
{
    public class CustomerApiModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public static TModel FromCustomer<TModel>(Customer customer) where
            TModel : CustomerApiModel, new()
        {
            var model = new TModel();
            model.Firstname = customer.Firstname;
            model.Lastname = customer.Firstname;
            model.EmailAddress = customer.Firstname;
            model.PhoneNumber = customer.Firstname;
            return model;
        }
    }
}
