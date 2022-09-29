using Microsoft.AspNetCore.Mvc;

namespace theFoodCampus.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
