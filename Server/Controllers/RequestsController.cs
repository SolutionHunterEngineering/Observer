using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

public class RequestsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}