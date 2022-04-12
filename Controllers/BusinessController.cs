using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsvHelper;
using System.IO;
using System.Net;
using System.Xml;
using System.Text;
using RL.Models;


namespace RL.Controllers
{
    public class BusinessController : Controller
    {
        // GET: Business
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCharges()
        {
            return View(new List<CreateCI>());
        }

        [HttpPost]
        public ActionResult AddCharges(HttpPostedFileBase postedFile, string username, string password)
        {

            /*   
             * 
             *   This application will be used to create ChargeItems. Business has a template and completes the Chargeitem
             *   to be added to the system. A CSV file is used to upload containing fields for
             *   ChargeGroupID, ChargeGroup, ChargeGroupAbbreviation, ChargeItem, TisCodeConversion, ChargeItemAbbreviation
             *   GLSAccountCode, ObjectCode,DefaultAmount and Status.
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
            List<CreateCI> _ListCreateCI = new List<CreateCI>();

            // Declaration of list to store the data that has been proccessed.
            List<CreateCI> ListCreateCI_ = new List<CreateCI>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    CreateCI Record = csvReader.GetRecord<CreateCI>();
                    _ListCreateCI.Add(Record);
                }
            }



            foreach (CreateCI C in _ListCreateCI)
            {

                // Build the URL with the Base Rest Services URL and the type of modification. The EntryApplicationID is the primary key
                // for the Application that will be updated.
                URL = Global.ProdBaseURL + "/create/ChargeItem/";

                // Build string data node for ChargeItem.
                //  These Fields are used with the default information required RecordTypeEnum, Tax_GLPostingID,
                // AccountReceivable_GLPostdingID,TaxRate,TaxRate2,TaxRate3
                // AmountInputAsExTax, TaxOrderEnum, TaxCategoryEnum, UnearnedIncome,Disputable,CustomBit1,CustomBit2,
                //
                // CustomString1 refers to GLSAccountCode
                // CustomString2 refers to ObjectCode

                PostData = string.Format(@"<ChargeItem>
                                                <RecordTypeEnum>Normal</RecordTypeEnum>
                                                <Tax_GLPostingID>1</Tax_GLPostingID>
                                                <AccountReceivable_GLPostingID>2</AccountReceivable_GLPostingID>
                                                <TaxRate>0</TaxRate>
                                                <TaxRate2>0</TaxRate2>
                                                <TaxRate3>0</TaxRate3>
                                                <AmountInputAsExTax>false</AmountInputAsExTax>
                                                <TaxOrderEnum>Tax1ThenTax2ThenTax3</TaxOrderEnum>
                                                <TaxCategoryEnum>Exempt</TaxCategoryEnum>
                                                <UnearnedIncome_ChargeItemID>0</UnearnedIncome_ChargeItemID>
                                                <Disputable>false</Disputable>
                                                <CustomBit1>false</CustomBit1>
                                                <CustomBit2>false</CustomBit2>
                                                <ChargeGroupID>{0}</ChargeGroupID>
                                                <Description>{1}</Description>
                                                <GLNumber>{2}</GLNumber>
                                                <Abbreviation>{3}</Abbreviation>
                                                <DefaultAmount>{4}</DefaultAmount>
                                                <CustomString1>{5}</CustomString1>
                                                <CustomString2>{6}</CustomString2>
                                           </ChargeItem>", C.ChargeGroupID, C.ChargeItem, C.GLSAcctCode, C.ChargeItemAbbreviation, C.DefaultAmount, C.Objectcode, C.TISCodeConversion);

                // Sub program makes the request with the Data, required URL for operation, method type and returns the success
                Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);


                // Add the status to indicate if change was successful or failed
                C.Status = sstatus.ToString();

                // Add the new records to final data output.

                ListCreateCI_.Add(C);

            }
            return View(_ListCreateCI);
        }

        public ActionResult HideCharge()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HideCharge(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<TDescription> _updateTDesc = new List<TDescription>();
            List<TDescription> updateTDesc_ = new List<TDescription>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    TDescription Record = csvReader.GetRecord<TDescription>();
                    _updateTDesc.Add(Record);
                }
            }

            foreach (TDescription T in _updateTDesc)
            {

                URL = Global.ProdBaseURL + "/update/Transaction/" + T.Description;

                PostData = string.Format(@"<Transaction>
                                                <Description>{0}</Description>
                                            </Transaction>", T.Description);

                Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                T.Status = sstatus.ToString();

                updateTDesc_.Add(T);
            }

            return View(updateTDesc_);
        }





        public ActionResult TransactionCommentUpdate()
        {
            return View(new List<TDescription>());
        }

        [HttpPost]
        public ActionResult TransactionCommentUpdate(HttpPostedFileBase postedFile, string username, string password)
        {

            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<TDescription> _updateTDesc = new List<TDescription>();
            List<TDescription> updateTDesc_ = new List<TDescription>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    TDescription Record = csvReader.GetRecord<TDescription>();
                    _updateTDesc.Add(Record);
                }
            }

            foreach (TDescription T in _updateTDesc)
            {

                URL = Global.ProdBaseURL + "/update/Transaction/" + T.TransactionID;

                PostData = string.Format(@"<Transaction>
                                                <Description>{0}</Description>
                                            </Transaction>", T.Description);

                Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                T.Status = sstatus.ToString();

                updateTDesc_.Add(T);
            }

            return View(updateTDesc_);
        }

        public ActionResult UpdateDefaultRoomRate()
        {
            return View(new List<UpdateDefRR>());
        }

        [HttpPost]
        public ActionResult UpdateDefaultRoomRate(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<UpdateDefRR> _updatedefaultrr = new List<UpdateDefRR>();
            List<UpdateDefRR> updatedefaultrr_ = new List<UpdateDefRR>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    UpdateDefRR Record = csvReader.GetRecord<UpdateDefRR>();
                    _updatedefaultrr.Add(Record);
                }

                foreach (UpdateDefRR R in _updatedefaultrr)
                {
                    URL = Global.ProdBaseURL + "/update/RoomSpaceDetail/" + R.RoomSpaceID;

                    PostData = string.Format(@"<RoomSpaceDetail>
                                            <CustomString1>{0}</CustomString1>
                                            <CustomString2>{1}</CustomString2>
                                            <CustomString3>{2}</CustomString3>
                                           </RoomSpaceDetail>
                                                ", R.RoomType, R.DefaultRoomRate, R.DefaultRoomCode);

                    Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);

                    R.Status = sstatus.ToString();

                    updatedefaultrr_.Add(R);

                }

            }

            return View(updatedefaultrr_);

        }

        public ActionResult DeleteTransactions()
        {
            return View(new List<DeleteTransactions>());
        }

        [HttpPost]
        public ActionResult DeleteTransactions(HttpPostedFileBase postedFile, string username, string password)
        {
            string AUTHINFO = username + ":" + password;
            string URL;
            string PostData;
            string Method = "Post";
            string results;
            HttpStatusCode sstatus;

            List<DeleteTransactions> _deleteTransaction = new List<DeleteTransactions>();
            List<DeleteTransactions> deleteTransaction_ = new List<DeleteTransactions>();

            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.MissingFieldFound = null;
                csvReader.Configuration.ReadingExceptionOccurred = null;

                while (csvReader.Read())
                {
                    DeleteTransactions Record = csvReader.GetRecord<DeleteTransactions>();
                    _deleteTransaction.Add(Record);
                }
            }

            foreach (DeleteTransactions D in _deleteTransaction)
            {
                URL = Global.ProdBaseURL + "/delete/Transaction/" + D.TransactionID;
                PostData = string.Format("");


                Sub.PerformRequest(URL, Method, PostData, out results, AUTHINFO, out sstatus);
                D.Status = sstatus.ToString();

                deleteTransaction_.Add(D);

                ViewData["A"] = PostData;
                ViewData["B"] = D.Status;

            }

            return View(deleteTransaction_);
        }




    }
          
}