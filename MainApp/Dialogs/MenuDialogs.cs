using Business.Interfaces;
using MainApp.Factories;

namespace MainApp.Services;



public class MenuDialogs (IContactService ContactService)
{
    private readonly IContactService _contactService = ContactService;

    
    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("-------- Main Menu --------");
            Console.WriteLine($"{"1.",-5} Contact List");
            Console.WriteLine($"{"2.",-5} Create Contact");
            Console.WriteLine($"{"3.",-5} Exit");
            Console.WriteLine("----------------");
            Console.Write("Choose your menu option: ");
            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    ContactList();
                    break;

                case "2":
                    CreateContact();
                    break;

                case "3":
                    Exit();
                    break;

                default:
                    InvalidOption();
                    break;
            }
        }
    }


    private void ContactList()
    {


        var contacts = _contactService.GetAllContacts();


        Console.Clear();

        Console.WriteLine("Contact List:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{"Id:",-5} {contact.Id}");
            Console.WriteLine($"{"Full name:",-5} {contact.FirstName} {contact.LastName}");            
            Console.WriteLine($"{"Email:",-5} {contact.Email}");
            Console.WriteLine($"{"Phonenumber:",-5} {contact.Phone}");
            Console.WriteLine($"{"Adress:",-5} {contact.Address}");
            Console.WriteLine($"{"City:",-5} {contact.City}");
            Console.WriteLine($"{"Home adress:",-5} {contact.PostalCode}");
            Console.WriteLine("");
           
        }
        
        Console.ReadKey();
    }


    private void CreateContact()
    {
        var form = ContactFactories.Create();

        Console.Clear();

        Console.WriteLine("-------- Create new contact --------");

        Console.Write("Enter your first name: ");
        form.FirstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        form.LastName = Console.ReadLine()!;

        Console.Write("Enter your Email: ");
        form.Email = Console.ReadLine()!;

        Console.Write("Enter your phonenumber: ");
        form.Phone = Console.ReadLine()!;

        Console.Write("Enter your adress: ");
        form.Address = Console.ReadLine()!;

        Console.Write("Enter your postal code: ");
        form.PostalCode = Console.ReadLine()!;

        Console.Write("Enter your city: ");
        form.City = Console.ReadLine()!;


        bool result = _contactService.CreateContact(form);

        if (result)
            OutputDialog("User was successfully created!");
        else
            OutputDialog("User was not created");  
        
        Console.ReadKey();

        
    }

    private void Exit()
    {
        Console.Write("Do you want to exit this application (y/n)?");
        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }

    }

    private void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("You must pick an valid option");
        Console.ReadKey();

    }

    public void OutputDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();
    }
}
        
    
