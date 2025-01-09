using System.Text.Json;
using Business.Interfaces;
using Business.Repositories;
using MainApp.Models;
using Moq;

namespace Business.Tests.Repositories;

public class ContactRespository_Test
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IContactRespository _contactRespositoryMock;

    public ContactRespository_Test()
    {
        _fileServiceMock = new Mock<IFileService>();
        _contactRespositoryMock = new ContactRepository(_fileServiceMock.Object);
    }

    [Fact]
    public void SaveContacts_ShloudSaveContactTFile()
    {
        // Arrange

        var contacts = new List<Contact>
        {
            new Contact  { Id = "1", FirstName = "Test", LastName = "Test", Email = "Test", Phone = "04715474", Address = "Test", City = "Test", PostalCode = "05474", }
        };

        _fileServiceMock.Setup(x => x.SaveContentToFile(It.IsAny<string>())).Returns(true);

        // Act
        var result = _contactRespositoryMock.SaveContacts(contacts);

        // Assert
        _fileServiceMock.Verify(x => x.SaveContentToFile(It.IsAny<string>()), Times.Once);
        Assert.True(result);
    }
    

    [Fact]
    public void GetContacts_ShouldReturnListOfContacts()
    {
        // Arrange
        List<Contact> expected = [new Contact { Id = "1", FirstName = "Test", LastName = "Test", Email = "Test", Phone = "04715474", Address = "Test", City = "Test", PostalCode = "05474", }];
        var json = JsonSerializer.Serialize(expected);

        _fileServiceMock.Setup(f => f.LoadContentFromFile()).Returns(json);

        // Act
        var result = _contactRespositoryMock.GetContacts();

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

}
