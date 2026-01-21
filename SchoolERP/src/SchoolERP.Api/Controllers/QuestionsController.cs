using SchoolERP.Application.Exams.Interfaces;
using SchoolERP.Application.Exams.Requests;

[Authorize]
[ApiController]
[Route("api/questions")]
public sealed class QuestionsController : ControllerBase
{
    private readonly IQuestionService _service;
    public QuestionsController(IQuestionService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> Create(CreateQuestionRequest r, CancellationToken ct)
        => Ok(await _service.CreateAsync(r, ct));

    [HttpGet]
    public async Task<IActionResult> Get(string classId, string subjectId, CancellationToken ct)
        => Ok(await _service.GetAsync(classId, subjectId, ct));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    { await _service.DeleteAsync(id, ct); return Ok(); }
}
