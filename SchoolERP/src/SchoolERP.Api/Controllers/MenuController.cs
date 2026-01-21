[Authorize]
[Route("api/menus")]
public sealed class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMyMenus(CancellationToken ct)
    {
        return Ok(await _menuService.GetMyMenusAsync(ct));
    }
}
