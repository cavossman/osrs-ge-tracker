using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using aspnetrefresher.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// https://www.reddit.com/r/2007scape/comments/3g06rq/guide_using_the_old_school_ge_page_api/

namespace aspnetrefresher.Controllers
{
    public class GrandExchange : Controller
    {
        public IActionResult Index()
        {
            // http://services.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=4151
            const String APILOC = "http://services.runescape.com/m=itemdb_oldschool/";
            String apiReq = "api/catalogue/detail.json?item=4151";

            WebRequest req = WebRequest.Create(APILOC + apiReq);
            WebResponse response = req.GetResponse();
            Debug.WriteLine("response here" + response);

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            JObject result = JObject.Parse(reader.ReadToEnd());
            Item item = new Item((JObject)result["item"]);
            ViewData["itemName"] = item.Name;
            ViewData["itemDescription"] = item.Description;
            ViewData["itemPrice"] = item.Current.Change;
            ViewData["imageIcon"] = item.Icon;

            ViewData["ProjectTitle"] = "OSRS Grand Exchange";

            return View();
        }


        // CREATE SEARCH
        // Can cahnge alpha into any string and it shows results with that to start
        // /api/catalogue/items.json?category=1&alpha=y&page=z

        // GRAB RELEVANT INFORMATION PER ITEM TO DISPLAY WITH GRAPH
        // /api/catalogue/detail.json?item=ITEM_ID


        // DISPLAY GRAPH OF ITEM PRICES
        // @key = epoch time
        // @value = price value
        // /api/graph/ITEM_ID.json  
    }
}
