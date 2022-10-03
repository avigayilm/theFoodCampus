using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using theFoodCampus.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
//
using Microsoft.AspNetCore.Mvc;
using Firebase.Auth;
using System.Drawing;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Firebase.Storage;
using System.Net;
using System.Security.Authentication;


namespace theFoodCampus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       // [HttpPost]
        public async Task<ActionResult> Index()// if youu read from html file you write in the parameter of index[] HebData The Data
        {

            var HebCalModel = new HebCalAdapter();// this gets the string from the gateway. 
            var WeatherModel = new WeatherAdapter();
            //gateway has to be running in order for this to work.
            //var port = this.HttpContext.Connection.LocalPort;
            var holiday = HebCalModel.Check();// if you have parameters  you put the parameters in check, best ot have it in models as an object the parameters you need
            var weather = WeatherModel.Check();// if you have parameters  you put the parameters in check, best ot have it in models as an object the parameters you need


            //FileStream stream = new FileStream(@"img//bg - img//about.png", FileMode.Open);
            var stream = new MemoryStream(Encoding.ASCII.GetBytes("Hello world!"));
            await Task.Run(() => Upload(stream));
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
            var firebaseClient = new FirebaseClient("https://fir-mvc-2aa4f-default-rtdb.firebaseio.com\r\n\r\n");
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


        private static string ApiKey = "AIzaSyBtF7Bh71_Jkgsph6OhhjYGz6kGhA81xIE";
        private static string Bucket = "gs://fir-foodcampus.appspot.com";
        private static string AuthEmail = "103shira@gmail.com";
        private static string AuthPassword = "123456";

        private static async Task Upload(MemoryStream stream)
        {
            // FirebaseStorage.Put method accepts any type of stream.
            //Image newImage = Image.FromFile(@"C:\Users\שירה סגל\Source\Repos\avigayilm\theFoodCampus\img\bg-img\about.png");
            //ImageConverter _imageConverter = new ImageConverter();
            //byte[] paramFileStream = (byte[])_imageConverter.ConvertTo(newImage, typeof(byte[]));
            //var stream = new MemoryStream(Encoding.ASCII.GetBytes("Hello world!")/paramFileStream/);
            //var stream = File(@"C:\Users\שירה סגל\Source\Repos\avigayilm\theFoodCampus\img\bg-img\about.png", "FileMode.Open");
            // of course you can login using other method, not just email+password
            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;

            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                })
                //.Child("image")
                //.Child("test")
                .Child("about.png")
                .PutAsync(stream, cancellation.Token);

            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // cancel the upload
            // cancellation.Cancel();

            try
            {
                // error during upload will be thrown when you await the task
                Console.WriteLine("Download link:\n" + await task);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception was thrown: {0}", ex);
            }
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