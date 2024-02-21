
using BusinessClockApi.Services;
using NSubstitute;

namespace BusinessClockApi.UnitTests;
public class AdvancedBusinessClockTests
{
    [Fact]
    public void ClosedOnSaturday()
    {
        var fakeClock = Substitute.For<ISystemTime>();
        fakeClock.GetCurrent().Returns(new DateTime(2024, 2, 17, 10, 00, 00));
        var clock = new AdvancedBusinessClock(fakeClock);

        Assert.False(clock.IsOpen());
    }

    [Fact]
    public void ClosedOnChristmas()
    {
        var fakeClock = Substitute.For<ISystemTime>();
        fakeClock.GetCurrent().Returns(new DateTime(2023, 12, 25, 10, 00, 00));
        var clock = new AdvancedBusinessClock(fakeClock);

        Assert.False(clock.IsOpen());
    }
}
