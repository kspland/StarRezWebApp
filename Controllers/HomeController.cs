using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsvHelper;
using RL.Models;

/*  This Web Application is currently used to upload data into StarRez  via Res Services.
    It is MVC and based on .net framework.
*/
namespace RL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Upload()
        {
            //  return View( new List<Traffic>());
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase postedFile)
        {
           // List<Traffic> ListTraffic = new List<Traffic>();

                

          
            using(var reader = new StreamReader(postedFile.InputStream))
            using( var csvReader = new CsvReader(reader))
            {
                ViewData["100"] = reader;
                ViewData["200"] = csvReader;
                csvReader.Configuration.Delimiter = ";";
                csvReader.Configuration.MissingFieldFound = null;
                while(csvReader.Read())
                {
                //    Traffic Record = csvReader.GetRecord<Traffic>();
                 //   ListTraffic.Add(Record);
                }
            }

            // return View(ListTraffic);

            return View();
        }
    }
}