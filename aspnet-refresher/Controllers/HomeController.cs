using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnet_refresher.Models;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using aspnetrefresher.Models;
using Newtonsoft.Json.Linq;

namespace aspnet_refresher.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Project()
        {
            const String APILOC = "http://services.runescape.com/m=itemdb_oldschool/";
            String apiReq = "api/catalogue/detail.json?item=4151";

            WebRequest req = WebRequest.Create(APILOC + apiReq);
            WebResponse response = req.GetResponse();
            Debug.WriteLine("response here" + response);

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            JObject result = JObject.Parse(reader.ReadToEnd());
            ViewData["result"] = result["item"]["name"] + "";

            ViewData["ProjectTitle"] = "OSRS Grand Exchange";

            return View();
        }






        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Developer"] = "Collin Vossman";
            ViewData["Message"] = "Contact the Dev.";
            ViewData["DeveloperName"] = "Collin Vossman";

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
