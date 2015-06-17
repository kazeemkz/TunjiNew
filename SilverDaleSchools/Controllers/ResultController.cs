using SilverDaleSchools.DAL;
using SilverDaleSchools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SilverDaleSchools.Model;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Excel;
using System.Data;

namespace SilverDaleSchools.Controllers
{
    [Authorize]

    public class ResultController : Controller
    {
        UnitOfWork work = new UnitOfWork();
        //
        // GET: /Result/
        [Authorize]
        public ViewResult Index(string LevelString, string Term, string StudentID, string Session, int? page)
        {
            List<Level> theLevels = work.LevelRepository.Get().ToList();
            List<SelectListItem> theItem = new List<SelectListItem>();
            theItem.Add(new SelectListItem() { Text = "None", Value = "" });

            foreach (var level in theLevels)
            {
                theItem.Add(new SelectListItem() { Text = level.LevelName + ":" + level.Type, Value = level.LevelName + ":" + level.Type });
            }

            ViewData["Level"] = theItem;

            //  if(string.IsNullOrEmpty(Term) &&)

            var results = from s in work.ResultRepository.Get().OrderByDescending(a => a.Class)
                          select s;

            if (User.IsInRole("Student"))
            {
                results = results.Where(a => a.StudentNo == User.Identity.Name);
            }


            if (!String.IsNullOrEmpty(Term))
            {
                results = results.Where(s => s.Term.Equals(Term));
            }

            if (!String.IsNullOrEmpty(Session))
            {
                results = results.Where(s => s.Session.Equals(Session));
            }


            if (!String.IsNullOrEmpty(LevelString))
            {
                results = results.Where(s => s.Class.Equals(LevelString));
            }

            if (!String.IsNullOrEmpty(StudentID))
            {
                results = results.Where(s => s.StudentNo.Equals(StudentID));
            }






            int pageSize = 50;
            int pageNumber = (page ?? 1);




            ViewBag.Count = results.Count();
            return View(results.ToPagedList(pageNumber, pageSize));

            // return View();
        }

        //
        // GET: /Result/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            Result theResult = work.ResultRepository.GetByID(id);
            return View(theResult);
        }

        //
        // GET: /Result/Create
       // [DynamicAuthorize]
        public ActionResult Create()
        {

            List<Level> theLevels = work.LevelRepository.Get().ToList();
            List<SelectListItem> theItem = new List<SelectListItem>();
            theItem.Add(new SelectListItem() { Text = "None", Value = "" });

            foreach (var level in theLevels)
            {
                theItem.Add(new SelectListItem() { Text = level.LevelName + ":" + level.Type, Value = level.LevelName + ":" + level.Type });
            }

            ViewData["Class"] = theItem;
            return View();
        }

        //
        // POST: /Result/Create
        [HttpPost]
       // [DynamicAuthorize]
        public async Task<ActionResult> Create(IEnumerable<HttpPostedFileBase> file, Result model)
        //public ActionResult Create(IEnumerable<HttpPostedFileBase> file, Result model)
        {
            try
            {
                // model.
                List<Result> checkForResult = new List<Result>();
                checkForResult = work.ResultRepository.Get().Where(a => a.Session == model.Session && a.Term == model.Term && a.Class == model.Class).ToList();

                if (checkForResult.Count() > 0)
                {
                    List<Level> theLevels = work.LevelRepository.Get().ToList();
                    List<SelectListItem> theItem = new List<SelectListItem>();
                    theItem.Add(new SelectListItem() { Text = "None", Value = "" });

                    foreach (var level in theLevels)
                    {
                        theItem.Add(new SelectListItem() { Text = level.LevelName + ":" + level.Type, Value = level.LevelName + ":" + level.Type });
                    }

                    ViewData["Class"] = theItem;
                    ModelState.AddModelError("", "You have uploaded for the class earlier!");
                    return View();
                }

                // TODO: Add insert logic here
                if (string.IsNullOrEmpty(Request.Files[0].FileName))
                {
                    ModelState.AddModelError("", "No Uploaded Document!");
                    return View();
                }//xlsx or xls
                if ((Request.Files[0].FileName.EndsWith(".xlsx")) || (Request.Files[0].FileName.EndsWith(".xls")))
                {
                    string fileExtension = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    //    string physicalPath = HttpContext.Server.MapPath("~/Content/") + Request.Files[0].FileName;


                    HttpPostedFileBase theFile = Request.Files[0];
                    var fileName = Path.GetFileName(Request.Files[0].FileName);



                    await new ReadResultExcelFile().Read(fileExtension, model.Class, model.Session, model.Term, theFile);
                    //new ReadResultExcelFile().Read( fileExtension, model.Class, model.Session, model.Term, theFile);
                }
                else
                {
                    ModelState.AddModelError("", "The Input File is not a valid Excel  file!");
                    return View();
                }



                return RedirectToAction("Index");
            }
            catch
            {
                List<Level> theLevels = work.LevelRepository.Get().ToList();
                List<SelectListItem> theItem = new List<SelectListItem>();
                theItem.Add(new SelectListItem() { Text = "None", Value = "" });

                foreach (var level in theLevels)
                {
                    theItem.Add(new SelectListItem() { Text = level.LevelName + ":" + level.Type, Value = level.LevelName + ":" + level.Type });
                }

                ViewData["Class"] = theItem;
                return View();
            }
        }


        public ActionResult PrintResult(int id)
        {
            Result theResult = work.ResultRepository.GetByID(id);

            string[] SplitedClass = theResult.Class.Split(':');

            string theClass = SplitedClass[0];
            string[] theClassNumber = theClass.Split(null);
            string theNumber = theClassNumber[1];




            StringWriter oStringWriter1 = new StringWriter();
            Document itextDoc = new Document(PageSize.A4);
            itextDoc.Open();
            Response.ContentType = "application/pdf";
            //  PrintResult print = new PrintResult();
            // Set up the document and the MS to write it to and create the PDF writer instance
            MemoryStream ms = new MemoryStream();
            //Document document = new Document(PageSize.A3.Rotate());
            Document document = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, ms);

            // Open the PDF document
            document.Open();
            Document thedoc = new Document();
            if (!(string.IsNullOrEmpty(theNumber)))
            {
                int theNewNumber = Convert.ToInt16(theNumber);

                if (theNewNumber > 9)
                {
                    thedoc = new PrintResultSenoir().PrintSilverDaleResult(theResult, ref oStringWriter1, ref document);
                }
                else
                {
                    thedoc = new PrintResult().PrintSilverDaleResult(theResult, ref oStringWriter1, ref document);
                }
            }

            iTextSharp.text.pdf.draw.VerticalPositionMark seperator = new iTextSharp.text.pdf.draw.LineSeparator();
            seperator.Offset = -6f;

            document.Close();

            // Hat tip to David for his code on stackoverflow for this bit
            // http://stackoverflow.com/questions/779430/asp-net-mvc-how-to-get-view-to-generate-pdf
            byte[] file = ms.ToArray();
            MemoryStream output = new MemoryStream();
            output.Write(file, 0, file.Length);
            output.Position = 0;
            // work.DeductionHistoryRepository
            HttpContext.Response.AddHeader("content-disposition", "attachment; filename=Result.pdf");
            return new FileStreamResult(output, "application/pdf"); //new FileStreamResult(output, "application/pdf");
        }

        //   GET: /Result/Edit/5
      //  [DynamicAuthorize]
        public ActionResult Edit(int id)
        {
            Result theResult = work.ResultRepository.GetByID(id);
            return View(theResult);
        }

        //
        // POST: /Result/Edit/5
        [HttpPost]
        //[DynamicAuthorize]
        public ActionResult Edit(Result model)
        {
            try
            {
                // TODO: Add update logic here

                TryUpdateModel(model);
                if (ModelState.IsValid)
                {
                    work.ResultRepository.Update(model);
                    work.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Result/Delete/5
       // [DynamicAuthorize]
        public ActionResult Delete(int id)
        {
            Result theResult = work.ResultRepository.GetByID(id);
            return View(theResult);
        }

        //
        // POST: /Result/Delete/5
        [HttpPost]
        //[DynamicAuthorize]
        public ActionResult Delete(Result model)
        {
            try
            {
                // TODO: Add delete logic here

                Result theResult = work.ResultRepository.GetByID(model.ResultID);
                work.ResultRepository.Delete(theResult);
                work.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
