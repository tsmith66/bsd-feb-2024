using Alba;
using BusinessClockApi.Services;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace BusinessClockApi.ContractTests;
public class GettingSupportInfo
{
    [Fact]
    public async Task Ready()
    {
        var host = await AlbaHost.For<Program>();
        var response = await host.Scenario(api =>
        {
            api.Get.Url("/support-info");
            api.StatusCodeShouldBeOk();
        });
    }

    [Fact]
    public async Task HasCorrectServicesRegistered()
    {
        var host = await AlbaHost.For<Program>();
        Assert.IsType<AdvancedBusinessClock>(host.Services.GetRequiredService<IProvideTheBusinessClock>());
        Assert.IsType<SystemTime>(host.Services.GetRequiredService<ISystemTime>());
    }

    [Fact]
    public async Task WhenWeAreOpen()
    {
        var host = await AlbaHost.For<Program>(config =>
        {
            config.ConfigureServices(sp =>
            {
                var fakeOpenClock = Substitute.For<IProvideTheBusinessClock>();
                fakeOpenClock.IsOpen().Returns(true);
                sp.AddScoped<IProvideTheBusinessClock>(sp => fakeOpenClock);
            });
        });

        var response = await host.Scenario(api =>
        {
            api.Get.Url("/support-info");
            api.StatusCodeShouldBeOk();
        });

        var expected = new SupportInfoResponse("Diane", "555-1212");

        var actualResponse = response.ReadAsJson<SupportInfoResponse>();

        Assert.Equal(expected, actualResponse);
    }

    [Fact]
    public async Task WhenWeAreClosed()
    {
        var host = await AlbaHost.For<Program>(config =>
        {
            config.ConfigureServices(sp =>
            {
                var fakeClosedClock = Substitute.For<IProvideTheBusinessClock>();
                fakeClosedClock.IsOpen().Returns(false);
                sp.AddScoped<IProvideTheBusinessClock>(sp => fakeClosedClock);
            });
        });

        var response = await host.Scenario(api =>
        {
            api.Get.Url("/support-info");
            api.StatusCodeShouldBeOk();
        });

        var expected = new SupportInfoResponse("TechSupportPros", "800-STUF-BROKE");

        var actualResponse = response.ReadAsJson<SupportInfoResponse>();

        Assert.Equal(expected, actualResponse);
    }

}
