using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using theFoodCampus.Models;

namespace theFoodCampus.Controllers
{
    public class WeatherController : Controller
    {
        // GET: WeatherController1cs
        public ActionResult Index()
        {
            var CurrentModel = new WeatherAdapter();// this gets the string from the gateway. 
            //gateway has to be running in order for this to work.
            //var port = this.HttpContext.Connection.LocalPort;
            var result = CurrentModel.Check();// if you have parameters  you put the parameters in check, best ot have it in models as an object the parameters you need
            ViewBag.result = result;
            return View();
        }

        // GET: WeatherController1cs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeatherController1cs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeatherController1cs/Create
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

        // GET: WeatherController1cs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeatherController1cs/Edit/5
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

        // GET: WeatherController1cs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeatherController1cs/Delete/5
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
