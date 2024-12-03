using MainApp.Models;

namespace MainApp.Factories;

 public static class ContactFactories 
{
    public static ContactForm Create()
    {
        return new ContactForm();
    }

    public static ContactEntity Create(ContactForm form)
    {
        return new ContactEntity()
        {    
            
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            Phone = form.Phone,
            Address = form.Address,
            City = form.City,
            PostalCode = form.PostalCode,
        };
    }

    public static Contact Create(ContactEntity entity)
    {
        return new Contact()
        {
            Id = entity.Id,            
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Phone = entity.Phone,
            Address = entity.Address,
            City = entity.City,
            PostalCode = entity.PostalCode,
        };
    }
}
