using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using theFoodCampus.Models;
//using FireBase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;

namespace theFoodCampus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()// if youu read from html file you write in the parameter of index[] HebData The Data
        {
            var CurrentModel = new HebCalAdapter();// this gets the string from the gateway. 
            //gateway has to be running in order for this to work.
            var result = CurrentModel.Check();// if you have parameters  you put the parameters in check, best ot have it in models as an object the parameters you need

            ViewBag.result=result;
            return View();
        }

        /// <summary>
        /// This function sends to the gateway,
        /// and there it uses the Imagga server that returns data about the image,
        /// using logic the function will return whether the image is appropriate or not
        /// </summary>
        /// <param name="data">from the web</param>
        /// <returns>whether the image is appropriate or not</returns>
        public IActionResult CheckImage(ImaggaData data)
        {
            //for try
            //ImaggaData data = new ImaggaData { ImageUrl = "https://imagga.com/static/images/tagging/wind-farm-538576_640.jpg", Title = "turbine" };
            var currentModel = new ImaggaAdapter();
            var ImaggaResult = currentModel.Check(data);
            if (ImaggaResult == "true")
                return View("ImaggaSuccess", ImaggaSuccess);
            return View("ImaggaFail", ImaggaFail);
            //return View("Index", Index);


        }
        public IActionResult ImaggaSuccess()
        {
            return View();
        }

        public IActionResult ImaggaFail()
        {
            return View();
        }
        public IActionResult about()
        {
            return View();
        }

        public IActionResult Blogpost()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Elements()
        {
            return View();
        }


        public IActionResult Recipepost ()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


/* for the recipes controller we need the following
 * HebHolidayAdapter Hadapter=new HebHolidayAdapter()
 * string Message= Hadapter.Check();
 * ViewData["HolidayMessage"]= Message
 * WeatherAdapter Wadapter=new Weatheradapter
 * string Message1= Wadapter.Check();
 * ViewData[|WEatherMessage"]=Messsage;
 * */