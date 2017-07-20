using Microsoft.AspNetCore.Mvc;

namespace Fiver.Security.Bearer.Controllers
{
    public class JQueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
