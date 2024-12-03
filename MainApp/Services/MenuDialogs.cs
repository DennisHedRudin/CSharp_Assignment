using MainApp.Factories;
using MainApp.Models;

namespace MainApp.Services;



public class MenuDialogs
{
    private readonly ContactService _contactService = new ContactService();

    public void Show()
    {
        while (true)
        {
            MainMenu();            
        }
    }
    private void MainMenu()
    {
        Console.Clear();
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

    private void ContactList()
    {
        var contacts = _contactService.GetAll();


        Console.Clear();

        Console.WriteLine("Contact List:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{"Id:",-5} {contact.Id}");
            Console.WriteLine($"{"Full name:",-5} {contact.FullName}");
            Console.WriteLine($"{"Email:",-5} {contact.Email}");
            Console.WriteLine($"{"Phonenumber:",-5} {contact.Phone}");
            Console.WriteLine($"{"Home adress:",-5} {contact.Home}");
            Console.WriteLine("");
           
        }
        


        Console.ReadKey();
    }

    private void CreateContact()
    {
        ContactForm contact = ContactFactories.Create();

        Console.Clear();

        Console.Write("Enter your first name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Enter your Email: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Enter your phonenumber: ");
        contact.Phone = Console.ReadLine()!;

        Console.Write("Enter your adress: ");
        contact.Address = Console.ReadLine()!;

        Console.Write("Enter your postal code: ");
        contact.PostalCode = Console.ReadLine()!;

        Console.Write("Enter your city: ");
        contact.City = Console.ReadLine()!;


        bool result = _contactService.Create(contact);

        if (result)
            OutputDialog("User was seccessfully created!");
        else
            OutputDialog("User was not created");     

        
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
        
    
