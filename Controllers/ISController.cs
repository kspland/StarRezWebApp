using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Text;
using RL.Models;
using CsvHelper;
using System.Xml;

namespace RL.Controllers
{
    public class ISController : Controller
    {
        // GET: IS
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Application()
        {
            return View();
        }

        public ActionResult AddAppGender()
        {
            return View( new List<AppGender>());
        }

        [HttpPost]
        public ActionResult AddAppGender(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<AppGender> _appGender =  new List<AppGender>();
            List<AppGender> appGender_ = new List<AppGender>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    AppGender Record = csvReader.GetRecord<AppGender>();
                    _appGender.Add(Record);
                }
            }

            foreach(AppGender A in _appGender)
            {
                
                URL = Global.ProdBaseURL + "/update/EntryApplication/" + A.EntryApplicationID;

                PostData = string.Format(@"<EntryApplication>
                                                <EntryApplicationCustomField CustomFieldDefinitionID = '121'>   
                                                                <ValueString>{0}</ValueString>
                                                </EntryApplicationCustomField>
                                            </EntryApplication>",A.Gender);

                Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);
                
                A.Status = sstatus.ToString();

                appGender_.Add(A);
            }

            return View( appGender_);
        }

        public ActionResult AddAppEC()
        {
            return View( new List<AddAppEC>());
        }

        [HttpPost]
        public ActionResult AddAppEC(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<AddAppEC>  _addappdEC = new  List<AddAppEC>();
            List<AddAppEC> addadpEC_ = new List<AddAppEC>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    AddAppEC Record = csvReader.GetRecord<AddAppEC>();
                    _addappdEC.Add(Record);
                }
            }

            foreach(AddAppEC AEC in _addappdEC)
            {
                URL = Global.ProdBaseURL + "/update/EntryApplication/" + AEC.EntryApplicationID;

                PostData = string.Format(@"<EntryApplication>
                                                <EntryApplicationCustomField CustomFieldDefinitionID = '118'>   
                                                                <ValueInteger>{0}</ValueInteger>
                                                </EntryApplicationCustomField>
                                            </EntryApplication>", AEC.EnrollmentClass);

                Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);
                AEC.Status = sstatus.ToString();

                addadpEC_.Add(AEC);

            }
            return View(addadpEC_);
        }

        public ActionResult AddAppType()
        {
            return View( new List<AddAppType>());
        }

        [HttpPost]
        public ActionResult AddAppType(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<AddAppType> _addappType  = new List<AddAppType>();
            List<AddAppType> addappType_ = new List<AddAppType>();



            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    AddAppType Record = csvReader.GetRecord<AddAppType>();
                    _addappType.Add(Record);
                }

               
                
            }


            foreach(AddAppType A in _addappType)
            {
                URL =  Global.ProdBaseURL + "/update/EntryApplication/" + A.EntryApplicationID;
                PostData = string.Format(@"<EntryApplication>
                                                <EntryApplicationCustomField CustomFieldDefinitionID='127'>
                                                            <ValueString>{0}</ValueString>
                                                 </EntryApplicationCustomField>
                                            </EntryApplication>",A.ApplicationType);
                Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                A.Status = sstatus.ToString();

                addappType_.Add(A);
            }
            return View(addappType_);
        }

       
        public ActionResult HousingType()
        {
            return View( new List<AddHType>());
        }
        
        [HttpPost]
        public ActionResult HousingType(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<AddHType> _addHType = new List<AddHType>();
            List<AddHType> addHType_ = new List<AddHType>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    AddHType Record = csvReader.GetRecord<AddHType>();
                    _addHType.Add(Record);
                }



            }

            foreach( AddHType A in _addHType)
            {
                URL = Global.ProdBaseURL + "/update/EntryApplication/" + A.EntryApplicationID;

                 PostData = string.Format(@"<EntryApplication>
                                            <EntryApplicationCustomfield CustomFieldDefinitionID='61'>
                                                                <ValueString>{0}</ValueString>
                                                </EntryApplicationCustomfield>
                                           </EntryApplication>
                                                ", A.HousingType);

                Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                A.Status = sstatus.ToString();

                addHType_.Add(A);
            }

            return View(addHType_);
        }

        public ActionResult ChangeAppStatus()
        {

            return View(new List<AppStatus>());
        }

        [HttpPost]
        public ActionResult ChangeAppStatus(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<AppStatus> _changeappstat = new List<AppStatus>();
            List<AppStatus> changeappstat_ = new List<AppStatus>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    AppStatus Record = csvReader.GetRecord<AppStatus>();
                    _changeappstat.Add(Record);
                }

                foreach (AppStatus A in _changeappstat)
                {
                    URL = Global.ProdBaseURL + "/update/EntryApplication/" + A.EntryApplicationID;

                    PostData = string.Format(@"<EntryApplication>
                                                        <ApplicationStatusID>{0}</ApplicationStatusID>
                                           </EntryApplication>
                                                ", A.ApplicationStatus);

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                   
                    A.Status = sstatus.ToString();

                    changeappstat_.Add(A);

                }
                return View(_changeappstat);
            }
        }

        public ActionResult UpdateAppClass()
        {
            return View( new List<UpdateAppClassification>());
        }

        [HttpPost]
        public ActionResult UpdateAppClass(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<UpdateAppClassification> _changeappclassid = new List<UpdateAppClassification>();
            List<UpdateAppClassification> changeappclassid_ = new List<UpdateAppClassification>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    UpdateAppClassification Record = csvReader.GetRecord<UpdateAppClassification>();
                    _changeappclassid.Add(Record);
                }

                foreach (UpdateAppClassification A in _changeappclassid)
                {
                    URL = Global.ProdBaseURL + "/update/EntryApplication/" + A.EntryID;

                    PostData = string.Format(@"<Entry>
                                                        <ClassificationID>{0}</ClassificationID>
                                           </Entry>
                                                ", A.ClassificationID);

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);


                    A.Status = sstatus.ToString();

                    changeappclassid_.Add(A);
                }
            }

            return View(changeappclassid_);
        }

        public ActionResult UpdateApplicationOnEntry()
        {
            return View( new List<UpdateAppOnEntry>());

        }

        [HttpPost]
        public ActionResult UpdateApplicationOnEntry(HttpPostedFileBase postedFile, string username, string password)
        {

            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<UpdateAppOnEntry> _changeentryappstat = new List<UpdateAppOnEntry>();
            List<UpdateAppOnEntry> changeentryappstat_ = new List<UpdateAppOnEntry>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    UpdateAppOnEntry Record = csvReader.GetRecord<UpdateAppOnEntry>();
                    _changeentryappstat.Add(Record);
                }

                foreach (UpdateAppOnEntry E in _changeentryappstat)
                {
                    URL = Global.ProdBaseURL + "/update/EntryApplication/" + E.EntryID;

                    PostData = string.Format(@"<Entry>
                                                        <EntryApplicationID>{0}</EntryApplicationID>
                                           </Entry>
                                                ", E.EntryApplicationID);

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);


                    E.Status = sstatus.ToString();

                    changeentryappstat_.Add(E);
                }
            }

                    return View(changeentryappstat_);
        }

        public ActionResult CleanSDrops ()
        {
            return View( new List<CleanSD>());
        }

        [HttpPost]
        public ActionResult CleanSDrops(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<CleanSD> _cleansd = new List<CleanSD>();
            List<CleanSD> cleansd_ = new List<CleanSD>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    CleanSD Record = csvReader.GetRecord<CleanSD>();
                    _cleansd.Add(Record);
                }

                foreach (CleanSD S in _cleansd)
                {
                   
                    string cleanout = "";
                    bool newvalue = false;

                    URL = Global.ProdBaseURL + "/update/Entry/" + S.EntryID;

                    PostData = string.Format(@"<Entry>
                                                    <EntryCustomField CustomFieldDefinitionID = '108'>   
                                                                <ValueBoolean>{0}</ValueBoolean>
                                                    </EntryCustomField>
                                                     <EntryCustomField CustomFieldDefinitionID = '109'>   
                                                                <ValueDate>dt</ValueDate
                                                    </EntryCustomField>
                                                     <EntryCustomField CustomFieldDefinitionID = '150'>   
                                                                <ValueString>{1}</ValueString>
                                                    </EntryCustomField>
                                           </Entry>",newvalue,cleanout);

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);


                    S.Status = sstatus.ToString();

                    cleansd_.Add(S);
                }
            }


                return View(cleansd_);
        }

        public ActionResult UpdateAppFeeOnline()
        {
            return View(new List<EntryApp>());
        }

        [HttpPost]
        public ActionResult UpdateAppFeeOnline(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;


            List<EntryApp> _updateappfeeonlineflag = new List<EntryApp>();
            List<EntryApp> updateappfeeonlineflag_ = new List<EntryApp>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    EntryApp Record = csvReader.GetRecord<EntryApp>();
                    _updateappfeeonlineflag.Add(Record);
                }

                foreach (EntryApp E in _updateappfeeonlineflag)
                {
                    URL = Global.ProdBaseURL + "/update/EntryApplication/" + E.EntryApplicationID;

                    PostData = string.Format(@"<EntryApplication>
                                                        <CustomBit1>1</CustomBit1>
                                           </EntryApplication>
                                                ");

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);


                    E.Status = sstatus.ToString();

                    updateappfeeonlineflag_.Add(E);


                    


                }
                return View(updateappfeeonlineflag_);
            }


        }

        public ActionResult UpdateUnderGradPaymentFlagAppFee()
        {


            return View( new List<EntryApp>());
        }

        [HttpPost]
        public ActionResult UpdateUnderGradPaymentFlagAppFee(HttpPostedFileBase postedFile, string username, string password)
        {

            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            string updatedata = "A            APP FEE ONLY IN OFFICE/ONLINE";

            List<EntryApp> _updateundergradpaymentflag = new List<EntryApp>();
            List<EntryApp> updateundergradpaymentflag_ = new List<EntryApp>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    EntryApp Record = csvReader.GetRecord<EntryApp>();
                    _updateundergradpaymentflag.Add(Record);
                }

                foreach (EntryApp E in _updateundergradpaymentflag)
                {
                    URL = Global.ProdBaseURL + "/update/EntryApplication/" + E.EntryApplicationID;

                    PostData = string.Format(@"<EntryApplication>
                                            <EntryApplicationCustomfield CustomFieldDefinitionID='57'>
                                                                <ValueString>{0}</ValueString>
                                                </EntryApplicationCustomfield>
                                           </EntryApplication>
                                                ",updatedata);

                    ViewData["a"] = PostData;

                    

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    

                    E.Status = sstatus.ToString();

                    updateundergradpaymentflag_.Add(E);





                }
            }
                return View(updateundergradpaymentflag_);
        }

        public ActionResult UpdateUndergradAppPaymentCustomField()
        {
            return View( new List<EntryApp1>() );

        }

        [HttpPost]
        public ActionResult UpdateUndergradAppPaymentCustomField(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

           

            List<EntryApp1> _updateundergradpaymentflag = new List<EntryApp1>();
            List<EntryApp1> updateundergradpaymentflag_ = new List<EntryApp1>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    EntryApp1 Record = csvReader.GetRecord<EntryApp1>();
                    _updateundergradpaymentflag.Add(Record);
                }

                foreach (EntryApp1 E in _updateundergradpaymentflag)
                {
                    URL =  Global.ProdBaseURL + "/update/EntryApplication/" + E.EntryApplicationID;

                    PostData = string.Format(@"<EntryApplication>
                                            <EntryApplicationCustomfield CustomFieldDefinitionID='57'>
                                                                <ValueString>{0}</ValueString>
                                                </EntryApplicationCustomfield>
                                           </EntryApplication>
                                                ", E.UndergradPaymentFlag);

                    ViewData["a"] = PostData;



                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);



                    E.Status = sstatus.ToString();

                    updateundergradpaymentflag_.Add(E);





                }
            }
            return View(updateundergradpaymentflag_);
        }

        public ActionResult UpdateIncompleteButPaidContract()
        {
            return View( new List<UpdateDefaultRR>());
        }

        public ActionResult UpdateBuildingPreference()
        {
            return View(new List<BuildingPref>());
        }

        [HttpPost]
        public ActionResult UpdateBuildingPreference(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;



            List<BuildingPref> _updatebldpref = new List<BuildingPref>();
            List<BuildingPref> updatebldpref_ = new List<BuildingPref>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    BuildingPref Record = csvReader.GetRecord<BuildingPref>();
                    _updatebldpref.Add(Record);
                }

                foreach (BuildingPref B in _updatebldpref)
                {
                    URL = Global.ProdBaseURL + "/update/EntryApplication/" + B.EntryApplicationID;

                    PostData = string.Format(@"<EntryApplication>
                                            <EntryApplicationCustomfield CustomFieldDefinitionID='78'>
                                                                <ValueString>{0}</ValueString>
                                                </EntryApplicationCustomfield>
                                           </EntryApplication>
                                                ", B.BuildingPreference);

                    ViewData["a"] = PostData;



                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);



                    B.Status = sstatus.ToString();

                    updatebldpref_.Add(B);
                }
            }

            return View(updatebldpref_);
        }



        [HttpPost]
        public ActionResult UpdateIncompleteButPaidContract(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<UpdateDefaultRR> _incompleteapppaid = new List<UpdateDefaultRR>();
            List<UpdateDefaultRR> incompleteapppaid_ = new List<UpdateDefaultRR>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    UpdateDefaultRR Record = csvReader.GetRecord<UpdateDefaultRR>();
                    _incompleteapppaid.Add(Record);
                }

                foreach (UpdateDefaultRR I in _incompleteapppaid)
                {
                    URL =  Global.ProdBaseURL + "/update/EntryApplication/" + I.EntryApplicationID;

                    PostData = string.Format(@"<EntryApplication>
                                            <EntryApplicationCustomfield CustomFieldDefinitionID='57'>
                                                                <ValueString>{0}</ValueString>
                                                </EntryApplicationCustomfield>
                                                <ApplicationStatusID>1</ApplicationStatusID>
                                                 <CompleteDate>{1}</CompleteDate>
                                                 <CustomBit1>True</CustomBit1>
                                           </EntryApplication>
                                                ",I.UndergradPaymentFlag, I.ReceivedFeeDate);

                    



                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);



                    I.Status = sstatus.ToString();

                    incompleteapppaid_.Add(I);

                }
               
            }

            return View(incompleteapppaid_);
        }

        public ActionResult UpdateAppC19()
        {
            return View( new List<AppC19>());
        }

        [HttpPost]
        public ActionResult UpdateAppC19(HttpPostedFileBase postedFile, string username, string password)
        {

            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

           

            List<AppC19> _appc19 = new List<AppC19>();
            List<AppC19> appc19_ = new List<AppC19>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    AppC19 Record = csvReader.GetRecord<AppC19>();
                    _appc19.Add(Record);
                }

                foreach (AppC19 A in _appc19)
                {
               

                    URL =   Global.ProdBaseURL + "/update/EntryApplication/" + A.EntryApplicationID;

                    PostData = string.Format(@"<EntryApplication>
                                                <EntryApplicationCustomfield CustomFieldDefinitionID='88'>
                                                                <ValueBoolean>True</ValueBoolean>
                                                </EntryApplicationCustomfield>
                                                <EntryApplicationCustomfield CustomFieldDefinitionID='74'>
                                                                <ValueDate>{0}</ValueDate>
                                                </EntryApplicationCustomfield>
                                                <EntryApplicationCustomfield CustomFieldDefinitionID='75'>
                                                                <ValueString>EXP          EXPRESS CHECKOUT</ValueString>
                                                 </EntryApplicationCustomfield>
                                                <EntryApplicationCustomfield CustomFieldDefinitionID='76'>
                                                                <ValueString>HOME        MOVED HOME</ValueString>
                                                </EntryApplicationCustomfield>
                                                <ApplicationStatusID>{1}</ApplicationStatusID>
                                                <CancelDate>{2}</CancelDate>
                                           </EntryApplication>", A.CheckOut,A.AppStatusID,A.CheckOut);





                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    ViewData["a"] = PostData;
                    ViewData["b"] = results;
                    ViewData["c"] = A.CheckOut;


                    A.Status = sstatus.ToString();

                    appc19_.Add(A);

                }
            }

                return View(appc19_);

        }
        public  ActionResult HideRoomSpaces()
        {
            return View( new List<HideRoomSpace>());
        }

        [HttpPost]
        public ActionResult HideRoomSpaces(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<HideRoomSpace> _hideroomspace = new List<HideRoomSpace>();
            List<HideRoomSpace> hideroomspace_ = new List<HideRoomSpace>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    HideRoomSpace Record = csvReader.GetRecord<HideRoomSpace>();
                    _hideroomspace.Add(Record);
                }

                foreach (HideRoomSpace R in _hideroomspace)
                {
                    URL =  Global.ProdBaseURL + "/update/RoomSpace/" + R.RoomSpaceID;

                    PostData = string.Format(@"<RoomSpace>
                                                 <RecordTypeEnum>{0}</RecordTypeEnum>
                                              </RoomSpace>", R.RecordTypeEnum);





                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);



                    R.Status = sstatus.ToString();

                    hideroomspace_.Add(R);

                }

            }
                return View(hideroomspace_);
        }

        public ActionResult WebName()
        {
            return View( new List<WebName>());
        }

        [HttpPost]
        public ActionResult  WebName(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<WebName> _webname = new List<WebName>();
            List<WebName> webname_ = new List<WebName>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    WebName Record = csvReader.GetRecord<WebName>();
                    _webname.Add(Record);
                }

                foreach (WebName W in _webname)
                {
                    URL =  Global.ProdBaseURL + "/update/Entry/" + W.EntryID;

                    PostData = string.Format(@"<Entry>
                                                 <NameWeb>{0}</NameWeb>
                                              </Entry>",W.PAWSID);





                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);



                    W.Status = sstatus.ToString();

                    webname_.Add(W);

                }

            }

            return View(webname_);
        }

        public ActionResult UpdateAppTerm()
        {
            return View( new List<UpdateAppOnEntry>());
        }

        [HttpPost]
        public ActionResult UpdateAppTerm(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<UpdateAppOnEntry> _updateappterm = new List<UpdateAppOnEntry>();
            List<UpdateAppOnEntry> updateappterm_ = new List<UpdateAppOnEntry>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    UpdateAppOnEntry Record = csvReader.GetRecord<UpdateAppOnEntry>();
                    _updateappterm.Add(Record);
                }

                foreach (UpdateAppOnEntry U in _updateappterm)
                {
                    URL = Global.ProdBaseURL + "/update/EntryApplication/" + U.EntryApplicationID;

                    PostData = string.Format(@"<EntryApplication>
                                                 <TermID>{0}</TermID>
                                              </EntryApplication>", U.Term);





                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);



                    U.Status = sstatus.ToString();

                    updateappterm_.Add(U);
                }
              }
                return View(updateappterm_);
        }

        public ActionResult UpdateBookingCODate()
        {
           

                return View( new List<BookingUCO>());
        }

        [HttpPost]
        public ActionResult UpdateBookingCODate(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<BookingUCO> _updatebookingco = new List<BookingUCO>();
            List<BookingUCO> updatebookingco_ = new List<BookingUCO>();

            DateTime checkout;

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    BookingUCO Record = csvReader.GetRecord<BookingUCO>();
                    _updatebookingco.Add(Record);
                }

                foreach (BookingUCO B in _updatebookingco)
                {
                    checkout = DateTime.Parse(B.CheckOut);

                    URL =  Global.ProdBaseURL + "/update/Booking/" + B.BookingID;

                    PostData = string.Format(@"<Booking>
                                                 <CustomDate2>{0}</CustomDate2>
                                              </Booking>", checkout);





                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    ViewData["a"] = PostData;
                     ViewData["b"] = results;
                    ViewData["c"] = checkout;

                    B.Status = sstatus.ToString();

                    updatebookingco_.Add(B);
                }
            }
                return View(updatebookingco_);
        }

        public ActionResult BookingC19()
        {
            return View(new List<BookingUCO>() );
        }

        [HttpPost]
        public ActionResult BookingC19(HttpPostedFileBase postedFile, string username, string password)
        {

            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<BookingUCO> _updatebookingc19 = new List<BookingUCO>();
            List<BookingUCO> updatebookingc19_ = new List<BookingUCO>();

            DateTime checkout;

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    BookingUCO Record = csvReader.GetRecord<BookingUCO>();
                    _updatebookingc19.Add(Record);
                }

                foreach (BookingUCO B in _updatebookingc19)
                {
                    checkout = DateTime.Parse(B.CheckOut);

                    URL =  Global.ProdBaseURL + "/update/Booking/" + B.BookingID;

                    PostData = string.Format(@"<Booking>
                                                 <CheckOutDate>{0}</CheckOutDate>
                                                 <ContractDateEnd>{1}</ContractDateEnd>
                                                 <End_BookingReasonID>7</End_BookingReasonID>
                                              </Booking>", checkout,checkout);





                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    ViewData["a"] = PostData;
                    ViewData["b"] = results;
                    ViewData["c"] = checkout;

                    B.Status = sstatus.ToString();

                    updatebookingc19_.Add(B);
                }
            }

            return View(updatebookingc19_);
        }

        public ActionResult UpdateBookingEndDate()
        {
            return View(new List<BookingUCO>());
        }

        [HttpPost]
        public ActionResult UpdateBookingEndDate(HttpPostedFileBase postedFile, string username, string password)
        {

            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<BookingUCO> _updatebookingEndDate = new List<BookingUCO>();
            List<BookingUCO> updatebookingEndDate_ = new List<BookingUCO>();

            DateTime checkout;

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    BookingUCO Record = csvReader.GetRecord<BookingUCO>();
                    _updatebookingEndDate.Add(Record);
                }

                foreach (BookingUCO B in _updatebookingEndDate)
                {
                    checkout = DateTime.Parse(B.CheckOut);

                    URL = Global.ProdBaseURL +  "/update/Booking/" + B.BookingID;

                    PostData = string.Format(@"<Booking>
                                                 <CheckOutDate>{0}</CheckOutDate>
                                              </Booking>",checkout);


                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    ViewData["a"] = PostData;
                    ViewData["b"] = results;
                    ViewData["c"] = checkout;

                    B.Status = sstatus.ToString();

                    updatebookingEndDate_.Add(B);
                }
            }
                return View(updatebookingEndDate_);
        }
        public ActionResult UpdateFacNumberandBldAbb()
        {
            return View( new List<AddFacNumAndBldAbb>());
        }
       

        [HttpPost]
        public ActionResult UpdateFacNumberandBldAbb(HttpPostedFileBase postedFile, string username, string password)
        {

            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<AddFacNumAndBldAbb> _updatefacnumberandabb = new List<AddFacNumAndBldAbb>();
            List<AddFacNumAndBldAbb> updatefacnumbernadabb_ = new List<AddFacNumAndBldAbb>();

           

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    AddFacNumAndBldAbb Record = csvReader.GetRecord<AddFacNumAndBldAbb>();
                    _updatefacnumberandabb.Add(Record);
                }

                foreach (AddFacNumAndBldAbb R in _updatefacnumberandabb)
                {
                   

                    URL =  Global.ProdBaseURL + "/update/roombase/" + R.RoomBaseID ;

                    PostData = string.Format(@"<RoomBase>
                                                 <CustomString3>{0}</CustomString3>
                                                 <CustomString4>{1}</CustomString4>
                                              </RoomBase>",R.Abb ,R.FacNumber );





                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    ViewData["a"] = PostData;
                    ViewData["b"] = results;
                   

                    R.Status = sstatus.ToString();

                    updatefacnumbernadabb_.Add(R);
                }
            }



            return View(updatefacnumbernadabb_);
        }
     
        public ActionResult DeleteApps()
        {
            return View( new List<DeleteApps>());
        }

        [HttpPost]
        public ActionResult DeleteApps(HttpPostedFileBase postedFile, string username, string password)
        {

            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

           

            List<DeleteApps> _deleteapps = new List<DeleteApps>();
            List<DeleteApps> deleteapps_ = new List<DeleteApps>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    DeleteApps Record = csvReader.GetRecord<DeleteApps>();
                    _deleteapps.Add(Record);
                }

                foreach (DeleteApps D in _deleteapps)
                {




                     URL = Global.ProdBaseURL +  "/delete/EntryApplication/" + D.EntryApplicationID;
              


                    PostData = "";

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    D.Status = sstatus.ToString();

                    deleteapps_.Add(D);

                    ViewData["A"] = PostData;


                }

            }
            return View(deleteapps_);

        }

        public ActionResult UpdateAppCompleteDate()
        {
            return View( new List<UpdateNonActivePaidApp>());
        }

        [HttpPost]
        public ActionResult UpdateAppCompleteDate(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<UpdateNonActivePaidApp> _updateNAPaidApp = new List<UpdateNonActivePaidApp>();
            List<UpdateNonActivePaidApp> updateNAPaidApp_ = new List<UpdateNonActivePaidApp>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    UpdateNonActivePaidApp Record = csvReader.GetRecord<UpdateNonActivePaidApp>();
                    _updateNAPaidApp.Add(Record);
                }

                foreach (UpdateNonActivePaidApp U in _updateNAPaidApp)
                {
                    URL =  Global.ProdBaseURL + "/select/EntryApplication/" + U.EntryApplicationID;

                    PostData = string.Format(@"<EntryApplication>
                                                 <CompleteDate>{0}</CompleteDate>
                                                 <ApplicationStatusID>1</ApplicationStatusID>
                                                 <CustomBit1>true</CustomBit1>
                                              </EntryApplication>",U.ReceivedFeeDate);


                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    ViewData["A"] = PostData;
                    ViewData["B"] = URL;
                    ViewData["C"] = username;
                    ViewData["D"] = U.EntryApplicationID;

                    U.Status = sstatus.ToString();


                    updateNAPaidApp_.Add(U);
                }
            }

            return View( updateNAPaidApp_);
        }

        public ActionResult Room()
        {
            return View();
        }

        public ActionResult Booking()
        {
            return View();
        }

        public ActionResult Entry()
        {
            return View();
        }

      
    }
}