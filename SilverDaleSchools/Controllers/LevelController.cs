using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SilverDaleSchool.DAL;
using SilverDaleSchools.Models;
using SilverDaleSchools.Model;
using PagedList;
//using SilverDaleSchools.Models;
using SilverDaleSchools.DAL;
//using SilverDalesSchool.Model;
//using SilverDaleSchools.Model;
//using PagedList.Mvc;

namespace SilverDaleSchool.Controllers
{
    [Authorize]
    //[DynamicAuthorize]
    public class LevelController : Controller
    {
        //
        // GET: /Level/
        UnitOfWork work = new UnitOfWork();
        public ActionResult Index(string sortOrder, string currentFilter, string LevelString, int? page)
        // public ActionResult Index()
        {

            var level = from s in work.LevelRepository.Get().OrderBy(a => a.LevelName)
                        select s;
            if (!String.IsNullOrEmpty(LevelString))
            {
                //  string theCode = ExamCode.ToLower();
                level = level.Where(s => s.LevelName.Equals(LevelString));

            }
            int pageSize = 40;
            int pageNumber = (page ?? 1);

            ViewBag.Count = level.Count();
            //   List<Level>  theLevels =   work.LevelRepository.Get().OrderBy(a=>a.LevelName).ToList();
            return View(level.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Level/Details/5

        public ActionResult Details(int id)
        {
            Level theLevel = work.LevelRepository.GetByID(id);
            return View(theLevel);
        }

        //
        // GET: /Level/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Level/Create

        [HttpPost]
        public ActionResult Create(Level model)
        {
            try
            {
                if (!(ModelState.IsValid))
                {
                    return View(model);
                }
                // TODO: Add insert logic here
                List<Level> theLevel = work.LevelRepository.Get(a => a.LevelName.ToLower().Equals(model.LevelName.ToLower())).ToList();

                int tracker = 0;
                if (theLevel.Count > 0)
                {
                    foreach (Level l in theLevel)
                    {
                        if (!(string.IsNullOrEmpty(l.Type)))
                        {
                            if (!(string.IsNullOrEmpty(model.Type)))
                            {

                                if (l.Type.ToLower() == model.Type.ToLower())
                                {
                                    tracker = 1;
                                    break;
                                    // ModelState.AddModelError("", "Class has Already been Created");
                                    // return View(model);
                                }
                            }

                        }

                        if ((string.IsNullOrEmpty(l.Type)))
                        {
                            if ((string.IsNullOrEmpty(model.Type)))
                            {

                                if (l.LevelName.ToLower() == model.LevelName.ToLower())
                                {
                                    tracker = 1;
                                    break;
                                    // ModelState.AddModelError("", "Class has Already been Created");
                                    // return View(model);
                                }
                            }

                        }
//
                      //  work.LevelRepository.Insert(model);
                      //  work.Save();
                        //  ModelState.AddModelError("", "Class has Already been Created");
                        //  return View(model);
                    }
                }

                if (tracker == 1)
                {
                    ModelState.AddModelError("", "Class has Already been Created");
                    return View(model);
                }
                else
                {
                    work.LevelRepository.Insert(model);
                    work.Save();
                }
                //else
                //{

                //    work.LevelRepository.Insert(model);
                //    work.Save();
                //}

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Level/Edit/5

        public ActionResult Edit(string id)
        {

            Int32 theId = Convert.ToInt32(SilverDaleSchools.Models.Encript.DecryptString(id, true));
            Level theLevel = work.LevelRepository.GetByID(theId);
            return View(theLevel);
        }

        //
        // POST: /Level/Edit/5

        [HttpPost]
        public ActionResult Edit(Level model)
        {
            try
            {
                // TODO: Add update logic here

                if (!(ModelState.IsValid))
                {
                    return View(model);
                }

                // TODO: Add insert logic here
               // List<Level> theLevel = work.LevelRepository.Get(a => a.LevelName.ToLower().Equals(model.LevelName.ToLower())).ToList();

                //int tracker = 0;
                //if (theLevel.Count > 0)
                //{
                //    foreach (Level l in theLevel)
                //    {
                //        if (!(string.IsNullOrEmpty(l.Type)))
                //        {
                //            if (!(string.IsNullOrEmpty(model.Type)))
                //            {

                //                if (l.Type.ToLower() == model.Type.ToLower())
                //                {
                //                    tracker = 1;
                //                    break;
                //                    // ModelState.AddModelError("", "Class has Already been Created");
                //                    // return View(model);
                //                }
                //            }

                //        }

                //        if ((string.IsNullOrEmpty(l.Type)))
                //        {
                //            if ((string.IsNullOrEmpty(model.Type)))
                //            {

                //                if (l.LevelName.ToLower() == model.LevelName.ToLower())
                //                {
                //                    tracker = 1;
                //                    break;
                //                    // ModelState.AddModelError("", "Class has Already been Created");
                //                    // return View(model);
                //                }
                //            }

                //        }
                //        //
                //        //  work.LevelRepository.Insert(model);
                //        //  work.Save();
                //        //  ModelState.AddModelError("", "Class has Already been Created");
                //        //  return View(model);
                //    }
                //}

                //if (tracker == 1)
                //{
                  //  ModelState.AddModelError("", "Class has Already been Created");
                  //  return View(model);
                //}
                //else
                //{
                //    work.LevelRepository.Update(model);
                //    work.Save();
                //}


                work.LevelRepository.Update(model);
               work.Save();
                //if (User.Identity.Name != "5000001")
                //{
                //    //AuditTrail audit = new AuditTrail { Date = DateTime.Now, Action = "Edited Class", UserID = User.Identity.Name };
                //    //work.AuditTrailRepository.Insert(audit);
                //    //work.Save();
                //}

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Level/Delete/5

        public ActionResult Delete(string id)
        {
            Int32 theId = Convert.ToInt32(SilverDaleSchools.Models.Encript.DecryptString(id, true));

            Level model = work.LevelRepository.GetByID(theId);
            //  Level theLevel = work.LevelRepository.GetByID(id);
            return View(model);
            // return View();
        }

        //
        // POST: /Level/Delete/5

        [HttpPost]
        public ActionResult Delete(Level model)
        {
            try
            {

                //   Int32 theId = Convert.ToInt32(SilverDaleSchools.Models.Encript.DecryptString(id, true));

                Level theLevel = work.LevelRepository.GetByID(model.LevelID);
                //string theL = model.LevelName;
                // TODO: Add delete logic here
                work.LevelRepository.Delete(theLevel);
                work.Save();
                if (User.Identity.Name != "5000001")
                {
                    //AuditTrail audit = new AuditTrail { Date = DateTime.Now, Action = "Deleted a Class Name:-"+ theL , UserID = User.Identity.Name };
                    //work.AuditTrailRepository.Insert(audit);
                    //work.Save();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
