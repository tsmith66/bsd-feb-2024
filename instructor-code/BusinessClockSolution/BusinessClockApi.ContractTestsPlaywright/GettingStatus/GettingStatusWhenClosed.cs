using System.Text.Json;
using Microsoft.Playwright.NUnit;

namespace BusinessClockApi.ContractTestsPlaywright.GettingStatus;

public class GettingStatusWhenClosed(ClosedFixture fixture) : PageTest, IClassFixture<ClosedFixture>
{
    private readonly string _serverAddress = fixture.ServerAddress;

    [Fact]
    public async Task ReturnsContractedSupport()
    {
        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        var apiRequest = await playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = _serverAddress
        });

        var response = await apiRequest.GetAsync("support-info");
        Assert.True(response.Ok);
        var expected = new SupportInfoResponse("TechSupportPros", "800-STUF-BROKE");
        
        var actual = await response.JsonAsync<SupportInfoResponse>(new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        Assert.Equal(expected, actual);
    }
    
}