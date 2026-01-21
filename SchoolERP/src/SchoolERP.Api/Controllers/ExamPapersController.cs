using SchoolERP.Application.Exams.Interfaces;
using SchoolERP.Application.Exams.Requests;

[Authorize]
[ApiController]
[Route("api/exam-papers")]
public sealed class ExamPapersController : ControllerBase
{
    private readonly IPaperBuilderService _service;
    public ExamPapersController(IPaperBuilderService service) => _service = service;

    [HttpPost("paper")]
    public async Task<IActionResult> Paper(CreatePaperRequest r, CancellationToken ct)
        => Ok(await _service.CreatePaperAsync(r, ct));

    [HttpPost("set")]
    public async Task<IActionResult> Set(CreatePaperSetRequest r, CancellationToken ct)
        => Ok(await _service.CreatePaperSetAsync(r, ct));

    [HttpPost("question")]
    public async Task<IActionResult> Add(AddQuestionToPaperRequest r, CancellationToken ct)
    { await _service.AddQuestionAsync(r, ct); return Ok(); }
}
