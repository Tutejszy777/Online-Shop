using Microsoft.AspNetCore.Mvc;

namespace MutipleStoreWebApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
