using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace theFoodCampus.Controllers
{
    public class ImaggaController : Controller
    {
        // GET: ImaggaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ImaggaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImaggaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImaggaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImaggaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ImaggaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImaggaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImaggaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
