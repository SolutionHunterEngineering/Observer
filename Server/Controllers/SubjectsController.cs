using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

public class SubjectsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}