using Microsoft.AspNetCore.Mvc;

namespace GymManagmentPL.Controllers
{
    public class MemberController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToRoute("Trainers",new { action="GetTrainer"});
        }
        public ActionResult GetMembers(int id)
        {
            return View();
        }
        public ActionResult Create(string name)
        {
            return View();
        }



    }
}
