using System.Diagnostics;
using MainApp.Factories;
using MainApp.Helper;
using MainApp.Models;

namespace MainApp.Services;

public class ContactService
{
    private readonly List<ContactEntity> _contacts = [];
    public bool Create(ContactForm form)
    {
        try
        {
            ContactEntity contactEntity = ContactFactories.Create(form);

            contactEntity.Id = IdentifierGenerator.GenerateUniqueID();

            _contacts.Add(contactEntity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }

    }

    public IEnumerable<Contact> GetAll()
    {
              

        return _contacts.Select(ContactFactories.Create);
    }

}
