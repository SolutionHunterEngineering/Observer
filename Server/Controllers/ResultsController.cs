using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

public class ResultsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}