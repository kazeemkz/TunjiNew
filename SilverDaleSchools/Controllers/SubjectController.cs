using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using JobHustler.DAL;
//using JobHustler.Models;
//using SchoolManagement.Model;
using PagedList;
using SilverDaleSchools.DAL;
using SilverDaleSchools.Model;
//using PagedList.Mvc;

namespace SilverDaleSchools.Controllers
{
   // [DynamicAuthorize]
    public class SubjectController : Controller
    {
        //
        // GET: /Subject/
        UnitOfWork work = new UnitOfWork();

        // public ActionResult LoadExamCodes(string sortOrder, string currentFilter, string ExamCode, string Class, string Visible, int? page)
        public ActionResult Index(string sortOrder, string currentFilter, int? page)
        {

            int pageSize = 30;
            int pageNumber = (page ?? 1);
                   
      
            List<Subject> theSubjects = work.SubjectRepository.Get().ToList();
            return View(theSubjects.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Subject/Details/5

        public ActionResult Details(int id)
        {
            Subject theSubject = work.SubjectRepository.GetByID(id);
            return View(theSubject);
        }

        //
        // GET: /Subject/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Subject/Create

        [HttpPost]
        public ActionResult Create(Subject model)
        {
            try
            {
                if (!(ModelState.IsValid))
                {
                    return View(model);
                }
                // TODO: Add insert logic here

                int counter = 0;
                List<Subject> theSubject = work.SubjectRepository.Get().ToList();
                foreach (var subject in theSubject)
                {
                    string thesub = subject.Name.ToLower().Trim();
                    string thesub2 = model.Name.ToLower().Trim();
                    if (thesub == thesub2)
                    {
                        counter = counter + 1;
                    }
                }
                if (counter >= 1)
                {
                    ModelState.AddModelError("", "This Subject Already Exist !");
                    return View(model);
                    //  return View();
                }


                List<Subject> theSubjects = work.SubjectRepository.Get(a => a.Name.ToLower().Equals(model.Name.ToLower())).ToList();
                if (theSubjects.Count != 0)
                {
                    ModelState.AddModelError("", "This Subject Already Exist in Database");
                }

                work.SubjectRepository.Insert(model);
                work.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /Subject/Edit/5

        public ActionResult Edit(int id)
        {
            Subject theSubject = work.SubjectRepository.GetByID(id);
            return View(theSubject);
        }

        //
        // POST: /Subject/Edit/5

        public ActionResult IsSubjectNameExists(string Name)
        {
            int counter = 0;
            List<Subject> theSubject = work.SubjectRepository.Get().ToList();
            foreach (var subject in theSubject)
            {
                string thesub = subject.Name.ToLower().Trim();
                string thesub2 = Name.ToLower().Trim();
                if (thesub == thesub2)
                {
                    counter = counter + 1;
                }
            }
            if (counter >= 1)
            {
                ModelState.AddModelError("", "This Subject Already Exist in Database");
                return View();
            }
            else
            {
                return View("OK");
            }

        }

        [HttpPost]
        public ActionResult Edit(Subject model)
        {
            try
            {
              
                work.SubjectRepository.Update(model);
                work.Save();
                // TODO: Add update logic here
                //if (User.Identity.Name != "5000001")
                //{
                //    AuditTrail audit = new AuditTrail { Date = DateTime.Now, Action = "Subject was Updated,  Subject  Name:-" + model.Name, UserID = User.Identity.Name };
                //    work.AuditTrailRepository.Insert(audit);
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
        // GET: /Subject/Delete/5

        public ActionResult Delete(int id)
        {
            Subject theSubject = work.SubjectRepository.GetByID(id);
            return View(theSubject);
        }

        //
        // POST: /Subject/Delete/5

        [HttpPost]
        public ActionResult Delete(Subject model)
        {
            try
            {
                // TODO: Add delete logic here
                string name = model.Name;
                work.SubjectRepository.Delete(model);
                work.Save();
                //if (User.Identity.Name != "5000001")
                //{
                //    AuditTrail audit = new AuditTrail { Date = DateTime.Now, Action = "Subject was Deleted,  Subject  Name:-" + name , UserID = User.Identity.Name };
                //    work.AuditTrailRepository.Insert(audit);
                //    work.Save();
                //}

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
