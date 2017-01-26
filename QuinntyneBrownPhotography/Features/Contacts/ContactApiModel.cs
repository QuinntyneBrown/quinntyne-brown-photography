using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Contacts
{
    public class ContactApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromContact<TModel>(Contact contact) where
            TModel : ContactApiModel, new()
        {
            var model = new TModel();
            model.Id = contact.Id;
            return model;
        }

        public static ContactApiModel FromContact(Contact contact)
            => FromContact<ContactApiModel>(contact);

    }
}
