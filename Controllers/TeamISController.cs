using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RL.Models;
using System.Net;
using System.Text;
using CsvHelper;
using System.IO;

namespace RL.Controllers
{
    public class TeamISController : Controller
    {
        // GET: TeamIS
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UpdatePins()
        {
            return View(new List<Pins>());
        }

        [HttpPost]
        public ActionResult UpdatePins(HttpPostedFileBase postedFile, string username, string password)
        {

            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            int num = 0;

            List<Pins> _updatepin = new List<Pins>();
            List<Pins> updatepin_ = new List<Pins>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    Pins Record = csvReader.GetRecord<Pins>();
                    _updatepin.Add(Record);
                }

                foreach (Pins p in _updatepin)
                {
                    num = new Random().Next(1000, 9999);

                    p.NewPin = num.ToString();

                    URL =  Global.ProdBaseURL + "/update/Entry/" + p.EntryID;

                    PostData = string.Format(@"<Entry>
                                                    <EntryCustomField CustomFieldDefinitionID='108'>
                                                            <ValueString>{0}</ValueString>
                                                    </EntryCustomField>
                                           </Entry>
                                                ", p.NewPin);

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    p.Status = sstatus.ToString();

                    updatepin_.Add(p);

                    ViewData["A"] = PostData;


                }



                return View(updatepin_);
            }



        }

        public ActionResult UpdateBookingCheckInDate()
        {
            return View(new List<UpdateBookingCIDate>());

        }

        [HttpPost]
        public ActionResult UpdateBookingCheckInDate(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;



            List<UpdateBookingCIDate> _updatebookingCIn = new List<UpdateBookingCIDate>();
            List<UpdateBookingCIDate> updatebookingCIn_ = new List<UpdateBookingCIDate>();

            DateTime checkin;

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    UpdateBookingCIDate Record = csvReader.GetRecord<UpdateBookingCIDate>();
                    _updatebookingCIn.Add(Record);
                }

                foreach (UpdateBookingCIDate B in _updatebookingCIn)
                {
                    checkin = DateTime.Parse(B.NewCheckInDate);

                    URL = Global.ProdBaseURL +  "/update/Booking/" + B.BookingID;

                    PostData = string.Format(@"<Booking>
                                                 <CheckInDate>{0}</CheckInDate>       
                                              </Booking>", checkin);


                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    ViewData["a"] = PostData;
                    ViewData["b"] = results;
                    ViewData["c"] = checkin;

                    B.Status = sstatus.ToString();

                    updatebookingCIn_.Add(B);

                   
                }

                
            }
            return View(updatebookingCIn_);

        }

        public ActionResult UpdateBookingCheckOutDate()
        {
            return View(new List<UpdateBookingCODate>());
        }

        [HttpPost]
        public ActionResult UpdateBookingCheckOutDate(HttpPostedFileBase postedFile, string username, string password)
        {

            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;



            List<UpdateBookingCODate> _updatebookingCOn = new List<UpdateBookingCODate>();
            List<UpdateBookingCODate> updatebookingCOn_ = new List<UpdateBookingCODate>();

            DateTime checkout;

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    UpdateBookingCODate Record = csvReader.GetRecord<UpdateBookingCODate>();
                    _updatebookingCOn.Add(Record);
                }

                foreach (UpdateBookingCODate B in _updatebookingCOn)
                {
                    checkout = DateTime.Parse(B.NewCheckOutDate);

                    URL = Global.ProdBaseURL + "/update/Booking/" + B.BookingID;

                    PostData = string.Format(@"<Booking>
                                                 <CheckOutDate>{0}</CheckOutDate>       
                                              </Booking>", checkout);


                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    ViewData["a"] = PostData;
                    ViewData["b"] = results;
                    ViewData["c"] = checkout;

                    B.Status = sstatus.ToString();

                    updatebookingCOn_.Add(B);


                }

            }

            return View(updatebookingCOn_);
        }
    }
}