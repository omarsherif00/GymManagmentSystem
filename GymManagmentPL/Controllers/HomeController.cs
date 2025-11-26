using Microsoft.AspNetCore.Mvc;

namespace GymManagmentPL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
