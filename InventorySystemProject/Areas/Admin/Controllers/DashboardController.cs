using Microsoft.AspNetCore.Mvc;

namespace InventorySystemProject.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
