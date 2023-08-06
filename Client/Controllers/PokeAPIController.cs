using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class PokeAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
