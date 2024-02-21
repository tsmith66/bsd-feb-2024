using Marten;
using Microsoft.AspNetCore.Mvc;

namespace IssueTrackerApi.Controllers;

public class IssuesController(IDocumentSession session) : ControllerBase
{


    [HttpPost("/issues")]
    public async Task<ActionResult> AddIssueAsync([FromBody] IssueRequest request)
    {
        var response = new IssueResponse(Guid.NewGuid(), request.Software,
            request.Description, DateTimeOffset.Now, IssueStatus.Pending);
        session.Insert(response);
        await session.SaveChangesAsync();
        return Ok(response);
    }

    [HttpGet("/issues")]
    public async Task<ActionResult> GetAllIssues()
    {
        var response = await session.Query<IssueResponse>().ToListAsync();

        return Ok(new IssuesResponseCollection(response));
    }

    [HttpGet("/issues/{id:guid}")]
    public async Task<ActionResult> GetIssueById(Guid id)
    {
        var response = await session.Query<IssueResponse>().Where(issue => issue.Id == id).SingleOrDefaultAsync();
        if (response is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(response);
        }
    }
}

public record IssueRequest(string Software, string Description);

public record IssueResponse(
    Guid Id,
    string Software, string Description, DateTimeOffset Logged, IssueStatus Status);


public enum IssueStatus { Pending };

public record IssuesResponseCollection(IReadOnlyList<IssueResponse> Data);