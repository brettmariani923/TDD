using Microsoft.AspNetCore.Mvc;

namespace TDD.Api.Controllers
{
    public class N64Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
