using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace BusinessClockApi.ContractTestsPlaywright.GettingStatus;

public class OpenFixture : PlaywrightWebApplicationFactory
{
    protected override void ConfigureServices(IServiceCollection serviceProvider)
    {
        var openClock = Substitute.For<IProvideTheBusinessClock>();
        openClock.IsOpen().Returns(true);
        serviceProvider.AddScoped(sp => openClock);
    }
}