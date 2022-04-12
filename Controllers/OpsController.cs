using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsvHelper;
using System.Text;
using System.Xml;
using RL.Models;
using static System.Net.WebRequestMethods;
using System.IO;
using Microsoft.Ajax.Utilities;
using WebGrease.Css;
using System.Net;
using StarRezApi;


namespace RL.Controllers
{
    public class OpsController : Controller
    {
        // GET: Ops
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpdateBookingStatus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateBookingStatus(string username, string password, string bookingid, string entrystatus)
        {
            int bid = Convert.ToInt32(bookingid);
            int estat = Convert.ToInt32(entrystatus);
            string AUTHINFO = username + ":" + password;
            string url = Global.ProdBaseURL +"/update/Booking/" + bid;
            string method = "POST";
            HttpStatusCode sstatus;
            string RESULTS;


            string PostData = string.Format(@"<Booking>
                                                    <EntryStatusEnum>{0}</EntryStatusEnum>
                                               </Booking>",entrystatus);

            // Sub.DataRequest(PostData, AUTHINFO, method, url, out STATUS, out RESULTS);

           var STATUS =   Sub.PerformRequest(url, method, PostData, out RESULTS, AUTHINFO, out sstatus );


            ViewData["a"] = STATUS;


            if (STATUS == System.Net.HttpStatusCode.OK)
            {
               // ViewData["b"] = RESULTS;

                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(RESULTS);

                XmlNodeList elemEntryStatus = xmlDoc.GetElementsByTagName("EntryStatusEnum");

                string NewEntryStat = elemEntryStatus[0].InnerXml;

                ViewData["c"] = "BookingID:" + bid + "Has a status of " + NewEntryStat;
            }
            else
            {
               // ViewData["b"] = RESULTS;
                ViewData["C"] = "Error";
            }

            return View();
        }

      
        public ActionResult MoveInTimes()
        {
            return View(new List<RoomBase>());
        }

        [HttpPost]
        public ActionResult MoveInTimes(HttpPostedFileBase postedFile, string username, string password)
        {
            /*
             *      This application updates the Resident Move In Time on to the CustomString6 on
             *      the Roombase Custom Field. This data is uploaded via a CSV file that list the
             *      RoomBaseID, RoomBaseDescription, Move In Time, Room Location Description and Status.
             *      The status field will be blank and Move In Time is entered by the user. A template
             *      report is stored in StarRez.
             */


            // HTTP Post Variable declaration for user credentials provides
            // This Application will post data to the Database.
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            //Declaration of list to store intial file data
            List<RoomBase> _ListRoomBase = new List<RoomBase>();

            //Declaration of list to store final data
            List<RoomBase> ListRoomBase_ = new List<RoomBase>();

            using(var reader = new StreamReader(postedFile.InputStream))
            using( var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;
               
                while(csvReader.Read())
                {
                    RoomBase Record = csvReader.GetRecord<RoomBase>();
                    _ListRoomBase.Add(Record);
                }
            }

            
            foreach (RoomBase R in _ListRoomBase)
            {
                // Build the URL with Base Rest Services URL and the type of modification. CustomString6 on the 
                // The Roombase table is being updated

                URL =  Global.ProdBaseURL + "/update/RoomBase/" + R.RoomBaseID;

                // Build the Data String with the node for RoomBase. RoombaseID is the identifier for table
                PostData = string.Format(@"<RoomBase>
                                                    <CustomString6>{0}</CustomString6>
                                           </RoomBase>",R.CustomString6);


                // Sub program makes the request with the Data, required URL for operation, method type and returns the success
                Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                // Add the status to indicate if change was successful or failed
                R.Status = sstatus.ToString();

                // Add the new records to final data output.
                ListRoomBase_.Add(R);
            }
            
            return View (ListRoomBase_);
        }

            /*
             * 
             * 
             * 
             * 
             * 
             * 
             */


           

        public ActionResult EarlyArrival()
        {

            return View( new List<AddEA>());
        }

        [HttpPost]
        public ActionResult EarlyArrival(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            int RoomSpaceID = 0;
            int RoomLocationID = 0;
            int RoomTypeID = 0;


            string url = "https://lsuhousing.lsu.edu/starrezrest/";

            StarRezApiClient client = new StarRezApiClient(url, username, password);

            List<AddEA> _earlyarrival = new List<AddEA>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    AddEA Record = csvReader.GetRecord<AddEA>();
                    _earlyarrival.Add(Record);
                }

            }


            foreach (AddEA EA in _earlyarrival)
            {


                var room = client.Select("RoomSpaceSummary", Criteria.Equals("RoomSpace_Description", EA.Assignment));

                var str = client.LastRequest.ToString();

                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(str);

                XmlNodeList elemRoomSpaceID = xmlDoc.GetElementsByTagName("RoomSpaceID");
                string SRoomSpaceID = elemRoomSpaceID[0].InnerXml;
                RoomSpaceID = int.Parse(SRoomSpaceID);

                XmlNodeList elemRoomLocationID = xmlDoc.GetElementsByTagName("RoomLocationID");
                string SRoomLocationID = elemRoomLocationID[0].InnerXml;
                RoomLocationID = int.Parse(SRoomLocationID);

                XmlNodeList elemRoomTypeID = xmlDoc.GetElementsByTagName("RoomTypeID");
                string SRoomTypeID = elemRoomTypeID[0].InnerXml;
                RoomTypeID = int.Parse(SRoomTypeID);

                var booking = client.CreateDefault("Booking");
                booking.EntryID = EA.EntryID;
                booking.RoomSpaceID = RoomSpaceID;
                booking.RoomLocationID = RoomLocationID;
                booking.RoomTypeID = RoomTypeID;
                booking.ContractDateStart = EA.ActualCheckIn;
                booking.ContractDateEnd = EA.CheckOut;
                booking.CheckInDate = EA.ActualCheckIn;
                booking.CheckOutDate = EA.CheckOut;
                booking.TermSessionID = EA.TermID;
                booking.RateSessionID = EA.RateID;
                booking.EntryStatusEnum = 10;

                EA.BookingID = client.Create(booking);

            }
        
            return View(_earlyarrival);

        }
            

          




        public ActionResult HT()
        {
            return View();

        }

        [HttpPost]
        public ActionResult HT(HttpPostedFileBase postedFile, string username, string password)
        {
            return View();
        }

       

      
          



        public ActionResult UpdateAptTermLength()
        {
            return View(new List<AddAptTermLen>());
        }

        [HttpPost]
        public ActionResult UpdateAptTermLength(HttpPostedFileBase postedFile, string username, string password)
        {
            /*
             * This Application updates the Apartment Term Length on an application via a CSV File
             *  Residents living in NGW can live on campus for 9 months or 12 months. Sometimes
             *  the field is left blank on the Entry Application Custom Field. 
             *  The Customfield  Definition ID that correspond to this field is  159.
             *  It is a ValueString Type of data.
             *  
             *  
             */


            // HTTP Post Variable declaration for user credentials provides
            // This Application will post data to the Database.
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;


            // Declaration of list to store the intial data
            List<AddAptTermLen> _addAptTL = new List<AddAptTermLen>();

            // Declaration of list to store the data that has been proccessed.
            List<AddAptTermLen> addAptTL_ = new List<AddAptTermLen>();

            
            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";     // CSV format file data is being used
                csvReader.Configuration.MissingFieldFound = null; 
                csvReader.Configuration.ReadingExceptionOccurred = null;


                //Reading data into a record
                while (csvReader.Read())
                {
                    AddAptTermLen Record = csvReader.GetRecord<AddAptTermLen>();
                    _addAptTL.Add(Record);

                }
            }

            // 
            foreach (AddAptTermLen A in _addAptTL)
            {
                // Build the URL with the Base Rest Services URL and the type of modification. The EntryApplicationID is the primary key
                // for the Application that will be updated.
                URL = Global.ProdBaseURL + "/update/EntryApplication/" + A.EntryApplicationID;

                // Build the string to be updated with the DataType ValueString and the Customfield Definition ID
                // This identifies the unique customfield that stores the data. Data is on the EntryAppliation Customfield table
                // but this is linked to the EntryApplication of the student. The node must be built for the EntryApplication
                // with an internal node to the EntryApplication Customfield.

                PostData = string.Format(@"<EntryApplication>
                                            <EntryApplicationCustomfield CustomFieldDefinitionID='149'>
                                                                <ValueString>{0}</ValueString>
                                                </EntryApplicationCustomfield>
                                           </EntryApplication>
                                                ", A.TermLength);

                // Sub program makes the request with the Data, required URL for operation, method type and returns the success
                Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                // Add the status to indicate if change was successful or failed
                A.Status = sstatus.ToString();

                // Add the new records to final data output.
                addAptTL_.Add(A);
            }

            // Return processed output to web page
            return View(addAptTL_);
        }
    }

   
}