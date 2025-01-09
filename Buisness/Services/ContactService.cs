using System.Diagnostics;
using Business.Dtos;
using Business.Interfaces;
using MainApp.Factories;
using MainApp.Models;

namespace MainApp.Services;

public class ContactService(IContactRespository contactRespository) : IContactService
{
    
    private readonly IContactRespository _contactRespository = contactRespository;
    private List<Contact> _contacts = [];



    public IEnumerable<Contact> GetAllContacts()
    {
        _contacts = _contactRespository.GetContacts()!;
        return _contacts;


    }

    public bool CreateContact(ContactRegistrationForm form)
    {
        

        try
        {
            var contact = ContactFactories.Create(form);
            _contacts.Add(contact);

            var result = _contactRespository.SaveContacts(_contacts);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    //public bool UpdateContact(ContactRegistrationForm updatedform)
    //{
    //    try
    //    {
    //        updateDetail.FirstName = updatedForm.FirstName;
    //        updateDetail.LastName = updatedContact.LastName;
    //        updateDetail.Email = updatedContact.Email;
    //        updateDetail.Phone = updatedContact.Phone;
    //        updateDetail.Address = updatedContact.Address;
    //        updateDetail.City = updatedContact.City;
    //        updateDetail.PostalCode = updatedContact.PostalCode;


    //        var result = _contactRespository.SaveContacts(_contacts);
    //        return result;
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex.Message);
    //        return false;
    //    }
    //}
}

   
