using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebService.UI.WebUI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using WebService.UI.WebUI.Models.Product;
using RestSharp;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;

namespace WebService.UI.WebUI.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IGetProductApi api;
        private readonly IWebHostEnvironment web;

        public HomeController(IGetProductApi api,IWebHostEnvironment web)
        {
            this.api = api;
            this.web = web;
        }

        public IActionResult Index()
        {
           
            return View();
        }

       
        public IActionResult Gallery(GetAllProductViewModel model)
        {
            ViewBag.TotalPage = api.TotalPage(new TotalPageProductViewModel { CountOnPage = model.CountOnPage });
            return View(api.GetAll(model));

        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }



        [Route("404")]
        public IActionResult Page404()
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
            System.IO.File.AppendAllLines(web.ContentRootPath + "\\Error.txt",new List<string> { Activity.Current?.Id + ":" + HttpContext.TraceIdentifier });
            return BadRequest("Error System, Try Again");
        }
    }
}
