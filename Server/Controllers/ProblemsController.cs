using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

public class ProblemsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}