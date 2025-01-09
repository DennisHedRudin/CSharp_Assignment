using Business.Dtos;
using MainApp.Helper;
using MainApp.Models;

namespace MainApp.Factories;

 public static class ContactFactories 
{
    public static ContactRegistrationForm Create() => new();

    public static Contact Create(ContactRegistrationForm form) => new()
    {   
        Id = IdentifierGenerator.GenerateUniqueId(),
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
        Phone = form.Phone,
        Address = form.Address,
        City = form.City,
        PostalCode = form.PostalCode,
    };
    
}
