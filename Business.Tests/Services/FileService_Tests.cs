using Business.Interfaces;
using Moq;

namespace Business.Tests.Services;

public class FileService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IFileService _fileService;
    

    
    public FileService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _fileService = _fileServiceMock.Object;

    }

    [Fact]

    public void SaveContentToFile_ShouldReturnTrue()
    {
        // arrange
        _fileServiceMock.Setup(fs => fs.SaveContentToFile(It.IsAny<string>())).Returns(true);

        // act
        var result = _fileService.SaveContentToFile("");

        // assert
        Assert.True(result);
    }

    [Fact]

    public void LoadContentFromFile_ShouldReturnTrue()
    {
        // arrange
        _fileServiceMock.Setup(fs => fs.LoadContentFromFile()).Returns("test");

        // act
        var result = _fileService.LoadContentFromFile();

        //assert
        Assert.Equal("test", result);
    }


}
