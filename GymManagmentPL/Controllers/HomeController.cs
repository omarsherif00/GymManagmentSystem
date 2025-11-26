using GymManagmentBLL.BusinessServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnalyticsService _analyticsService;

        public HomeController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }
        public IActionResult Index()
        {
            var data = _analyticsService.GetHomeAnalyticsService();
            return View(data);
        }
    }
}
