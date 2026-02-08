using Microsoft.AspNetCore.Mvc;

namespace TDD.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
