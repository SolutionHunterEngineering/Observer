using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

public class ServersController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}