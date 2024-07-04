using Microsoft.AspNetCore.Mvc;

namespace BudgetManagerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController:ControllerBase
{
   [HttpGet]
   public async Task<IActionResult> Index()
   {
      return Ok(new { message = "It's fine, I swear!" });
   }
}