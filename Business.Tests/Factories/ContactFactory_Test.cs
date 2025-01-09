using Business.Dtos;
using MainApp.Factories;
using MainApp.Models;

namespace Business.Tests.Factories;

public class ContactFactory_Test
{
    [Fact]

    public void Create_ShouldReturnContactRegistrationForm()
    {
        // act
        var result = ContactFactories.Create();

        // assert
        Assert.NotNull(result);
        Assert.IsType<ContactRegistrationForm>(result);       
         
        
    }

    [Fact]

    public void Create_ShouldReturnContact_WhenContactRegistrationFormIsProvided()
    {
        // Arrange
        var contactRegistrationForm = new ContactRegistrationForm()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "Test",
            Phone = "04715474",
            Address = "Test",
            City = "Test",
            PostalCode = "05474",
        };

        // act
        var result = ContactFactories.Create(contactRegistrationForm);

        // assert
        Assert.NotNull(result);
        Assert.IsType<Contact>(result);
        Assert.Equal(contactRegistrationForm.FirstName, result.FirstName);
        Assert.Equal(contactRegistrationForm.LastName, result.LastName);
        Assert.Equal(contactRegistrationForm.Email, result.Email);
        Assert.Equal(contactRegistrationForm.Phone, result.Phone);
        Assert.Equal(contactRegistrationForm.Address, result.Address);
        Assert.Equal(contactRegistrationForm.City, result.City);
        Assert.Equal(contactRegistrationForm.PostalCode, result.PostalCode);

    }
}
