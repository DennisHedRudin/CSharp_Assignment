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

    public bool UpdateContact(Contact updatedForm)
    {

        
        try
        {
            var contactToUpdate = _contacts.FirstOrDefault(x => x.Id == updatedForm.Id);

            if (contactToUpdate == null) 
            {
            return false;
            }


            contactToUpdate.FirstName = updatedForm.FirstName;
            contactToUpdate.LastName = updatedForm.LastName;
            contactToUpdate.Email = updatedForm.Email;
            contactToUpdate.Phone = updatedForm.Phone;
            contactToUpdate.Address = updatedForm.Address;
            contactToUpdate.City = updatedForm.City;
            contactToUpdate.PostalCode = updatedForm.PostalCode;


            var result = _contactRespository.SaveContacts(_contacts);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool DeleteContactFromList(string id)
    {
        try
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);

            if (contact != null)
            {

                _contacts.Remove(contact);
                var result = _contactRespository.SaveContacts(_contacts);
                return result;
            }

            return false;

        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}

   


   
