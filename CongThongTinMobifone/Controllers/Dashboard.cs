using Microsoft.AspNetCore.Mvc;

namespace CongThongTinMobifone.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
