using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Features.Contacts
{
    public class ContactMessageApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromContactMessage<TModel>(ContactMessage contactMessage) where
            TModel : ContactMessageApiModel, new()
        {
            var model = new TModel();
            model.Id = contactMessage.Id;
            return model;
        }

        public static ContactMessageApiModel FromContactMessage(ContactMessage contactMessage)
            => FromContactMessage<ContactMessageApiModel>(contactMessage);

    }
}
