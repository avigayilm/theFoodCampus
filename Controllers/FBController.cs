using FireSharp.Config;
using FireSharp.EventStreaming;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using theFoodCampus.Models;

namespace theFoodCampus.Controllers
{
    public class RecipeController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "yWpKfxrTZJsHPaXGyB8ivbwXrVNHRjraZNkATyVB",
            BasePath = "https://fir-mvc-2aa4f-default-rtdb.firebaseio.com\r\n\r\n"
        };
        IFirebaseClient client;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            try
            {
                AddRecipeToFirebase(recipe);
                ModelState.AddModelError(string.Empty, "Added Succesfully");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }

            return View();
        }

        private void AddRecipeToFirebase(Recipe recipe)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = recipe;
            PushResponse response = client.Push("Recipes/", data);
            int num;
            int.TryParse(response.Result.name, out num);
            data.Id = num;
            SetResponse setResponse = client.Set("Recipes/" + data.Id, data);

        }
    }
}
