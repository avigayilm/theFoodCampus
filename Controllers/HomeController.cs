﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using theFoodCampus.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using theFoodCampus.Models;


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
            var HebCalModel = new HebCalAdapter();// this gets the string from the gateway. 
            var WeatherModel = new WeatherAdapter();
            //gateway has to be running in order for this to work.
            //var port = this.HttpContext.Connection.LocalPort;
            var holiday = HebCalModel.Check();// if you have parameters  you put the parameters in check, best ot have it in models as an object the parameters you need
            var weather = WeatherModel.Check();// if you have parameters  you put the parameters in check, best ot have it in models as an object the parameters you need
            ViewBag.holiday=holiday;
            ViewBag.weather=weather;
            return View();
        }
        //public IActionResult about()
        //{
        //    return View();
        //}
        public async Task<ActionResult> about()
        {
            //Simulate test user data and login timestamp
            var userId = "12345";
            var currentLoginTime = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss");

            //Save non identifying data to Firebase
            var currentUserLogin = new LoginData() { TimestampUtc = currentLoginTime };
            var firebaseClient = new FirebaseClient("https://fir-mvc-2aa4f-default-rtdb.firebaseio.com");
            var result = await firebaseClient
              .Child("Users/" + userId + "/Logins")
              .PostAsync(currentUserLogin);

            //Retrieve data from Firebase
            var dbLogins = await firebaseClient
              .Child("Users")
              .Child(userId)
              .Child("Logins")
              .OnceAsync<LoginData>();

            var timestampList = new List<DateTime>();

            //Convert JSON data to original datatype
            foreach (var login in dbLogins)
            {
                timestampList.Add(Convert.ToDateTime(login.Object.TimestampUtc).ToLocalTime());
            }

            //Pass data to the view
            ViewBag.CurrentUser = userId;
            ViewBag.Logins = timestampList.OrderByDescending(x => x);
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