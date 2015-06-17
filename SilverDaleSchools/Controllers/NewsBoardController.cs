using SilverDaleSchools.DAL;
using SilverDaleSchools.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SilverDaleSchools.Models;


namespace SilverDaleSchools.Controllers
{
    public class NewsBoardController : Controller
    {
        UnitOfWork work = new UnitOfWork();
        //
        // GET: /NewsBoard/

        //    public ViewResult Index(string sortOrder, string currentFilter, string Date, string searchString, string SexString, string LevelString, string StudentIDString, int? page)
        // [DynamicAuthorize]
        public ActionResult Index(string sortOrder, string date, string dateto, int? page)
        {
            List<NewsBoard> theNews = work.NewsBoardRepository.Get().OrderByDescending(a=>a.Date).ToList();

            if (!String.IsNullOrEmpty(date) && !(String.IsNullOrEmpty(dateto)))
            {
                DateTime from = Convert.ToDateTime(date);
                DateTime to = Convert.ToDateTime(dateto);
                theNews = theNews.Where(a => a.Date >= from.Date && a.Date <= to.Date).ToList();
            }

            if (!(String.IsNullOrEmpty(date)) && (String.IsNullOrEmpty(dateto)))
            {
                DateTime from = Convert.ToDateTime(date);
               // DateTime to = Convert.ToDateTime(dateto);
                theNews = theNews.Where(a => a.Date.Date == from.Date).ToList();
            }

            if ((String.IsNullOrEmpty(date)) && !(String.IsNullOrEmpty(dateto)))
            {
                //DateTime from = Convert.ToDateTime(date);
                 DateTime to = Convert.ToDateTime(dateto);
                theNews = theNews.Where(a => a.Date.Date == to.Date).ToList();
            }

            int pageSize = 100;
            int pageNumber = (page ?? 1);


            return View(theNews.ToPagedList(pageNumber, pageSize));
          //  return View(theNews);
        }

        //
        // GET: /NewsBoard/Details/5
        // [DynamicAuthorize]
        public ActionResult Details(string id)
        {
            Int32 theId = Convert.ToInt32(Models.Encript.DecryptString(id, true));
          NewsBoard thNew =  work.NewsBoardRepository.GetByID(theId);

          return View(thNew);
        }

        //
        // GET: /NewsBoard/Create
        // [DynamicAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NewsBoard/Create

        [HttpPost]
       // [DynamicAuthorize]
        public ActionResult Create(NewsBoard model)
        {
            model.Date = DateTime.Now;
            try
            {
                if (ModelState.IsValid)
                {
                    work.NewsBoardRepository.Insert(model);
                    work.Save();

                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /NewsBoard/Edit/5
        // [DynamicAuthorize]
        public ActionResult Edit(string id)
        {
            Int32 theId = Convert.ToInt32(Models.Encript.DecryptString(id, true));
            NewsBoard theNews = work.NewsBoardRepository.GetByID(theId);
            return View(theNews);
        }

        //
        // POST: /NewsBoard/Edit/5

        [HttpPost]
       // [DynamicAuthorize]
        public ActionResult Edit(NewsBoard model)
        {
            model.Date = DateTime.Now;
            try
            {
                if (ModelState.IsValid)
                {
                    work.NewsBoardRepository.Update(model);
                    work.Save();
                    if (User.Identity.Name != "5000001")
                    {
                      //  AuditTrail audit = new AuditTrail { Date = DateTime.Now, Action = "Created a News on News Board", UserID = User.Identity.Name };
                      //  work.AuditTrailRepository.Insert(audit);
                      //  work.Save();
                    }
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /NewsBoard/Delete/5
      //  [DynamicAuthorize]
        public ActionResult Delete(string id)
        {
            Int32 theId = Convert.ToInt32(Models.Encript.DecryptString(id, true));
            NewsBoard theNews = work.NewsBoardRepository.GetByID(theId);
            //  work.
            return View(theNews);
        }

        //
        // POST: /NewsBoard/Delete/5

        [HttpPost]
      // [DynamicAuthorize]
        public ActionResult Delete(NewsBoard model)
        {
            try
            {
                NewsBoard theNews = work.NewsBoardRepository.GetByID(model.NewsBoardID);

                work.NewsBoardRepository.Delete(theNews);
                work.Save();
                if (User.Identity.Name != "5000001")
                {
                  //  AuditTrail audit = new AuditTrail { Date = DateTime.Now, Action = "Deleted a news from the news Board", UserID = User.Identity.Name };
                   // work.AuditTrailRepository.Insert(audit);
                  //  work.Save();
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult LoadNewBoard(string level)
        {
            List<NewsBoard> theNewsBoard = work.NewsBoardRepository.Get().OrderByDescending(a=>a.Date).ToList();

            List<NewsBoard> theNewsBoard1 = theNewsBoard.Take(6).ToList();
          //theNewsBoard = 
            List<SelectListItem> news = new List<SelectListItem>();
          
            foreach (var co in theNewsBoard1)
            {
               string theDate = string.Format("{0: dd-MMM-yyyy}", co.Date);
                //Course theCourse = work.CourseRepository.GetByID(co.);
               news.Add(new SelectListItem { Text = co.Caption + " " + theDate, Value = co.Content });
            }
            return Json(news, JsonRequestBehavior.AllowGet);
        }
    }
}
