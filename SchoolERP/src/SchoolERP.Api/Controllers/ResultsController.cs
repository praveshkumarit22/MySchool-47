using SchoolERP.Application.Exams.Interfaces;
using SchoolERP.Application.Exams.Requests;

[Authorize]
[ApiController]
[Route("api/results")]
public sealed class ResultsController : ControllerBase
{
    private readonly IResultService _results;
    private readonly IMarksheetService _marksheets;

    public ResultsController(IResultService results, IMarksheetService marksheets)
    {
        _results = results;
        _marksheets = marksheets;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> Generate(GenerateResultRequest r, CancellationToken ct)
    {
        await _results.GenerateAsync(r, ct);
        return Ok();
    }

    [HttpGet("marksheet")]
    public async Task<IActionResult> Marksheet(string examId, string studentId, CancellationToken ct)
        => Ok(await _results.GetAsync(examId, studentId, ct));

    [HttpGet("marksheet/pdf")]
    public async Task<IActionResult> MarksheetPdf(string examId, string studentId, CancellationToken ct)
    {
        var bytes = await _marksheets.GeneratePdfAsync(examId, studentId, ct);
        return File(bytes, "application/pdf", "marksheet.pdf");
    }
}
