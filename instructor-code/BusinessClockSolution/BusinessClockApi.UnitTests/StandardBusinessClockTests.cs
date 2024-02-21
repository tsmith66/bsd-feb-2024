
namespace BusinessClockApi.UnitTests;
public class StandardBusinessClockTests
{
    [Fact]
    public void ClosedOnSaturday()
    {
        Assert.Fail("Not Written Yet");
    }

    [Fact]
    public void ClosedOnSunday()
    {
        Assert.Fail("Not Written Yet");
    }

    [Theory]
    [InlineData("2/20/2023 16:25:00")]
    [InlineData("2/20/2023 9:00:00")]
    public void WeAreOpen(string dateTime)
    {
        Assert.Fail("Not Written Yet");
    }

    [Theory]
    [InlineData("2/20/2023 17:00:00")]
    [InlineData("2/20/2023 8:59:59")]
    public void WeAreClosed(string dateTime)
    {
        Assert.Fail("Not Written Yet"); // fix this
    }
}
