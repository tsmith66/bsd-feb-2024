using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace BusinessClockApi.ContractTestsPlaywright.GettingStatus;

public class ClosedFixture : PlaywrightWebApplicationFactory
{
    protected override void ConfigureServices(IServiceCollection serviceProvider)
    {
        var openClock = Substitute.For<IProvideTheBusinessClock>();
        openClock.IsOpen().Returns(false);
        serviceProvider.AddScoped(sp => openClock);
    }
}