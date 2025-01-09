
using MainApp.Helper;

namespace Business.Tests.Helper;

public class IdentifierGenerator_Tests
{
    [Fact]
    public void GenerateUniqeId_ShouldReturnGuidAsString()
    {
        // act
        var result = IdentifierGenerator.GenerateUniqueId();

        //assert
        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out _));

    }


}
