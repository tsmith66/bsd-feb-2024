using Microsoft.AspNetCore.Mvc;

namespace IssueTrackerApi.Controllers;

public class WelcomeController : ControllerBase
{

    [HttpGet("/welcome")]
    public string ShowWelcome()
    {
        return "Hey! Nice To See You";
    }
}
