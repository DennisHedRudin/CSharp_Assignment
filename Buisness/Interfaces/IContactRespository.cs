using MainApp.Models;

namespace Business.Interfaces;

public interface IContactRespository
{
    List<Contact> GetContacts();
    bool SaveContacts(List<Contact> contacts);
}
