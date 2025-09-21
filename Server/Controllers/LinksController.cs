using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

public class LinksController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}