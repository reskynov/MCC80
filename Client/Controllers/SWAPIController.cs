using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class SWAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
