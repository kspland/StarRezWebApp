using CsvHelper;
using RL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RL.Controllers
{
    public class ResEdController : Controller
    {
        // GET: ResEd
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpdateMoveInRoomSpace()
        {
            return View( new List<UpdateMoveInR>());
        }

        [HttpPost]
        public ActionResult UpdateMoveInRoomSpace(HttpPostedFileBase postedFile, string username, string password)
        {

            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<UpdateMoveInR> _updatemoveinr = new List<UpdateMoveInR>();
            List<UpdateMoveInR> updatemoveinr_ = new List<UpdateMoveInR>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    UpdateMoveInR Record = csvReader.GetRecord<UpdateMoveInR>();
                    _updatemoveinr.Add(Record);
                }

                foreach (UpdateMoveInR M in _updatemoveinr)
                {
                    URL = Global.ProdBaseURL + "/update/RoomSpaceDetail/" + M.RoomSpaceID;

                    PostData = string.Format(@"<RoomSpaceDetail>
                                            <CustomString5>{0}</CustomString5>
                                           </RoomSpaceDetail>
                                                ", M.MoveInTime);

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    M.Status = sstatus.ToString();

                    updatemoveinr_.Add(M);

                }

            }

            return View(updatemoveinr_);
        }

        public ActionResult UpdateFloorNameRoomBase()
        {
            return View( new List<UpdateFloorNameCustomRoomBase>());
        }

        [HttpPost]
        public ActionResult UpdateFloorNameRoomBase(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<UpdateFloorNameCustomRoomBase> _updatefloornamerb = new List<UpdateFloorNameCustomRoomBase>();
            List<UpdateFloorNameCustomRoomBase> updatefloornamerb_ = new List<UpdateFloorNameCustomRoomBase>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    UpdateFloorNameCustomRoomBase Record = csvReader.GetRecord<UpdateFloorNameCustomRoomBase>();
                    _updatefloornamerb.Add(Record);
                }

                foreach (UpdateFloorNameCustomRoomBase F in _updatefloornamerb)
                {
                    URL = Global.ProdBaseURL + "/update/RoomBase/" + F.RoomBaseID;

                    PostData = string.Format(@"<RoomBase>
                                            <CustomString1>{0}</CustomString1>
                                           </RoomBase>
                                                ", F.FloorName);

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    F.Status = sstatus.ToString();

                    updatefloornamerb_.Add(F);

                }

            }

            return View(updatefloornamerb_);
        }

        public ActionResult AddRoomInventory()
        {
            return View(new List<roomInventory>());
        }

        [HttpPost]
        public ActionResult AddRoomInventory(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<roomInventory> _addRoomInventory = new List<roomInventory>();
            List<roomInventory> addRoomInventory_ = new List<roomInventory>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    roomInventory Record = csvReader.GetRecord<roomInventory>();
                    _addRoomInventory.Add(Record);
                }

                foreach (roomInventory R in _addRoomInventory)
                {
                    URL =  Global.ProdBaseURL + "/create/RoomSpaceInventory";

                    PostData = string.Format(@"<RoomSpaceInventory>
                                                <RoomSpaceID>{0}</RoomSpaceID>
                                                <RoomSpaceInventoryTypeID>{1}</RoomSpaceInventoryTypeID>
                                                <RoomSpaceInventoryConditionID>{2}</RoomSpaceInventoryConditionID>
                                                <Description>{3}</Description>
                                                <Location>{4}</Location>
                                           </RoomSpaceInventory>
                                                ",R.RoomSpaceID, R.RoomSpaceInventory,R.RoomSpaceInventoryCondition,R.Description,R.Location);

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    R.Status = sstatus.ToString();

                    addRoomInventory_.Add(R);

                    ViewData["A"] = PostData;

                    
                }

            }


            return View(addRoomInventory_);
        }

        public ActionResult AddScholasticDrop()
        {
            return View( new List<SDrop>());
        }

        [HttpPost]
        public ActionResult AddScholasticDrop(HttpPostedFileBase postedFile, string username, string password)
        {

            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<SDrop> _addSDrop = new List<SDrop>();
            List<SDrop> addSDrop_ = new List<SDrop>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    SDrop Record = csvReader.GetRecord<SDrop>();
                    _addSDrop.Add(Record);
                }

                foreach (SDrop SD in _addSDrop)
                {
                    URL =  Global.ProdBaseURL + "/update/Entry";

                    PostData = string.Format(@"<Entry>
                                                <RoomSpaceID>{0}</RoomSpaceID>
                                                <RoomSpaceInventoryTypeID>{1}</RoomSpaceInventoryTypeID>
                                                <RoomSpaceInventoryConditionID>{2}</RoomSpaceInventoryConditionID>
                                                <Description>{3}</Description>
                                                <Location>{4}</Location>
                                           </Entry>
                                                ", SD.Term);

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    SD.Status = sstatus.ToString();

                    addSDrop_.Add(SD);

                    ViewData["A"] = PostData;


                }

            }
            return View(addSDrop_);
        }

        public ActionResult AddMaximoLocation()
        {
            return View( new List<AddMaxLocation>());
        }
       
       [HttpPost]
       public ActionResult AddMaximoLocation(HttpPostedFileBase postedFile, string username, string password)
        {

            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<AddMaxLocation> _addMaxLoc = new List<AddMaxLocation>();
            List<AddMaxLocation> addMaxLoc_ = new List<AddMaxLocation>();

           using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    AddMaxLocation Record = csvReader.GetRecord<AddMaxLocation>();
                    _addMaxLoc.Add(Record);
                }

                foreach (AddMaxLocation R in _addMaxLoc)
                {
                    URL =  Global.ProdBaseURL + "/update/RoomSpaceDetail/" + R.RoomSpaceID;

                    PostData = string.Format(@"<RoomSpaceDetail>
                                            <CustomString6>{0}</CustomString6>
                                           </RoomSpaceDetail>
                                                ", R.MaximoLocation);

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    R.Status = sstatus.ToString();

                    addMaxLoc_.Add(R);

                }

            }

                  
                    return View(addMaxLoc_);

        }


            
      }

 
}
