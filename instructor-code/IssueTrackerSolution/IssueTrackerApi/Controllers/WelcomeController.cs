using Microsoft.AspNetCore.Mvc;

namespace IssueTrackerApi.Controllers;

public class WelcomeController : ControllerBase
{

    [HttpGet("/welcome")]
    public string ShowWelcome()
    {
        return "Hey! Nice To See You";
    }


    [HttpGet("/demo/{month:int:min(1):max(12)}/{day:int}/{year:int}")]
    public ActionResult Demo(int month, int day, int year)
    {
        return Ok($"You said Month {month} day {day} and year {year}");
    }
}
