using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[Route("orders")]
[Authorize]
public class Orders : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    [Route("ordersasadmin")]
    public IActionResult GetAsAdmin()
    {
        return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }
}