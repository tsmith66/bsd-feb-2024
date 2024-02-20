namespace BusinessClockApi.ContractTests;

public class UnitTest1
{

    [Fact]
    public void WeCanAddTenAndTwenty()
    {
        int a = 10, b = 20;
        int answer;
        answer = a + b;

        Assert.Equal(30, answer);
    }

    [Theory]
    [InlineData(10, 20, 30)]
    [InlineData(2, 2, 4)]
    [InlineData(8, 2, 10)]
    public void CanAddAnyTwoIntegers(int a, int b, int expected)
    {
        var answer = a + b;

        Assert.Equal(expected, answer);
    }
}