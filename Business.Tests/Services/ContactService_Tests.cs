using Business.Dtos;
using Business.Interfaces;
using MainApp.Models;
using MainApp.Services;
using Moq;

namespace Business.Tests.Services;

public class ContactService_Tests
{
    private readonly Mock<IContactRespository> _contactRespositoryMock;
    private readonly IContactService _contactService;
    private readonly Mock<IFileService> _fileServiceMock;
    

    public ContactService_Tests()
    {
        _contactRespositoryMock = new Mock<IContactRespository>();
        _contactService = new ContactService(_contactRespositoryMock.Object);        
        _fileServiceMock = new Mock<IFileService>();       


    }

   

    [Fact]

    public void CreateContact_ShouldReturnTrue_WhenCreatingContact()
    {
        // arrange
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
        _contactRespositoryMock.Setup(cr => cr.SaveContacts(It.IsAny<List<Contact>>())).Returns(true);

        // act
        var result= _contactService.CreateContact(contactRegistrationForm);

        // assert
        Assert.True(result);        
        _contactRespositoryMock.Verify(x => x.SaveContacts(It.IsAny<List<Contact>>()), Times.Once);
    }

    [Fact]

    public void GetAllContacts_ShouldReturnListOfContacts()
    {
        // arrange
        List<Contact> expected = [new Contact { Id = "1", FirstName = "Test", LastName = "Test", Email = "Test", Phone = "04715474", Address = "Test", City = "Test", PostalCode = "05474", }];
        

        _contactRespositoryMock.Setup(x => x.GetContacts()).Returns(expected);

        // act
        var result = _contactService.GetAllContacts();

        // assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(expected[0].Id, result.First().Id);
        Assert.Equal(expected[0].FirstName, result.First().FirstName);
        Assert.Equal(expected[0].LastName, result.First().LastName);
        Assert.Equal(expected[0].Email, result.First().Email);
        Assert.Equal(expected[0].Phone, result.First().Phone);
        Assert.Equal(expected[0].Address, result.First().Address);
        Assert.Equal(expected[0].City, result.First().City);
        Assert.Equal(expected[0].PostalCode, result.First().PostalCode);
    }

    [Fact]

    public void UpdateContact_ShouldUpdateDetails()
    {
        // arrange        
        var updatedForm = new Contact
        {
            Id = "1",
            FirstName = "Test2",
            LastName = "Test",
            Email = "Test",
            Phone = "Test",
            Address = "Test",
            City = "Test",
            PostalCode = "Test",
        };

        _contactRespositoryMock.Setup(cr => cr.SaveContacts(It.IsAny<List<Contact>>())).Returns(true);

        // act
        var result = _contactService.UpdateContact(updatedForm);

        //assert
        Assert.True(result);        

    }

    [Fact]
    public void DeleteContact_ShouldRemoveContactFromList()
    {
        // Arrange
        List<Contact> expected = [new Contact { Id = "1", FirstName = "Test", LastName = "Test", Email = "Test", Phone = "04715474", Address = "Test", City = "Test", PostalCode = "05474", }];
        var contactIdToDelete = "1";


        _contactRespositoryMock.Setup(r => r.SaveContacts(It.IsAny<List<Contact>>())).Returns(true);

        // Act
        var result = _contactService.DeleteContactFromList(contactIdToDelete);

        // Assert
        Assert.True(result);       
    }



}
