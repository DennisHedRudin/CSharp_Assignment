using System.Diagnostics;
using System.Text.Json;
using Business.Interfaces;
using MainApp.Models;

namespace Business.Repositories;

public class ContactRepository(IFileService fileService) : IContactRespository
{
    private readonly IFileService _fileService = fileService;

    public bool SaveContacts(List<Contact> contacts)
    {
        try
        {
            var json = JsonSerializer.Serialize(contacts);
            _fileService.SaveContentToFile(json);
            return true;           
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }

    }



    public List<Contact> GetContacts()
    {
        try
        {
            var json = _fileService.LoadContentFromFile();
            var contacts = JsonSerializer.Deserialize<List<Contact>>(json);
            return contacts;
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }
}
