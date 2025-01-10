using Business.Dtos;
using MainApp.Models;

namespace Business.Interfaces;

public interface IContactService
{
  
    bool CreateContact(ContactRegistrationForm form);
    IEnumerable<Contact> GetAllContacts();
    bool UpdateContact(Contact updatedForm);

    bool DeleteContactFromList(string id);


}
