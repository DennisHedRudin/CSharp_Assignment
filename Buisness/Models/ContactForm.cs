namespace MainApp.Models;

public class ContactForm
{

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;    
    
    public string FullName => $"{FirstName} {LastName}";

    public string Home => $"{Address} {PostalCode} {City}"; 
}
