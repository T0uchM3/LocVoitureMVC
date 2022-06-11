using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
//using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult click(String name)
        {

            ViewBag.x = "********";
            if (name == "signin")
                Console.WriteLine("red1");
            else
                meth();
            return View("/Views/Home/_Page2.cshtml");
        }
        async void meth()
        {
            await RunAsync();
        }
        async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://loc-voiture.herokuapp.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Voiture");
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.x = "fffff";
                    //ViewBag.x = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    Console.WriteLine("**************");

                    Console.WriteLine(response.StatusCode.ToString());
                }
                else
                    Console.WriteLine("AAAAAAAAA");
            }
        }
        [HttpPost]
        public IActionResult DoWorkTwo()
        {
            return View("_Page2");
        }

        public IActionResult OnGetPartial()
        {
            return new PartialViewResult
            {
                ViewName = "_Part",
                ViewData = this.ViewData
            };
        }
        public IActionResult testMeth()
        {
            return PartialView("_Part");
        }
    }
}