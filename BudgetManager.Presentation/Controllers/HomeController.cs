using Microsoft.AspNetCore.Mvc;

namespace BudgetManager.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController:ControllerBase
{
   [HttpGet]
   public IActionResult Index()
   {
      return Ok(new { message = "It's fine, I swear!" });
   }
}