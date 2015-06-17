using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using JobHustler.DAL;
//using JobHustler.Models;
//using SchoolManagement.DAL;
//using SchoolManagement.Model;
//using SchoolManagement.Models;
using PagedList;
using SilverDaleSchools.DAL;
using SilverDaleSchools.Models;
using SilverDaleSchools.Model;
//using PagedList.Mvc;

namespace SilverDaleSchools.Controllers
{
   // [DynamicAuthorize]
    public class SubjectRegistrationController : Controller
    {
        UnitOfWork work = new UnitOfWork();
        sdContext db = new sdContext();
        //
        // GET: /SubjectRegistration/

        // public ActionResult Index()
        public ActionResult Index(string sortOrder, string currentFilter, int? page)
        {

            int pageSize = 30;
            int pageNumber = (page ?? 1);
            SubRegistrationViewModel model = new SubRegistrationViewModel();
            List<Subject> theSubjects = work.SubjectRepository.Get().ToList();
            model.Subjects = theSubjects;

            ViewBag.Count = work.SubjectRegistrationRepository.Get().Count();

            List<SubjectRegistration> theSubReg = work.SubjectRegistrationRepository.Get().ToList();
            return View(theSubReg.ToPagedList(pageNumber, pageSize));
            //  return View(theSubReg);
        }

        //
        // GET: /SubjectRegistration/Details/5

        public ActionResult Details(int id)
        {
            //msContext
            SubjectRegistration theSubReg = work.SubjectRegistrationRepository.GetByID(id);
            return View(theSubReg);
        }

        //
        // GET: /SubjectRegistration/Create

        public ActionResult Create()
        {

            SubRegistrationViewModel model = new SubRegistrationViewModel();
            SubjectRegistration thesubReg = new SubjectRegistration();
            List<Subject> theSubjects = work.SubjectRepository.Get().OrderBy(a => a.Name).ToList();
            model.Subjects = theSubjects;
            model.SubjectRegistration = thesubReg;


            Dictionary<string, string> theDic = new Dictionary<string, string>();
            List<SelectListItem> theItem = new List<SelectListItem>();
            List<Subject> theSub = work.SubjectRepository.Get().OrderBy(a => a.Name).ToList();
            foreach (var subject in theSub)
            {
                theItem.Add(new SelectListItem() { Text = subject.Name, Value = subject.Name });
            }

            //  theItem.Add(new SelectListItem() { Text = "PRIMART 1A", Value = "PRIMART 1A" });
            ViewBag.Subjects = theItem;
            ViewBag.Subject = theSub;
            return View(model);
        }

        //
        // POST: /SubjectRegistration/Create

        [HttpPost]
        public ActionResult Create(SubRegistrationViewModel model, string[] SubjectRegistration)
        {
            try
            {
                Int32 theId = Convert.ToInt32 (model.UserID);
                List<Person> thePerson = new List<Person>();
                thePerson = work.PersonRepository.Get(a => a.UserID == theId).ToList();
                if (thePerson.Count > 0 )
                {
                    if (SubjectRegistration == null || model.UserID == null)
                    {
                        // SubRegistrationViewModel model = new SubRegistrationViewModel();
                        SubjectRegistration thesubReg = new SubjectRegistration();
                        List<Subject> theSubjects = work.SubjectRepository.Get().OrderBy(a => a.Name).ToList();
                        model.Subjects = theSubjects;
                        model.SubjectRegistration = thesubReg;


                        Dictionary<string, string> theDic = new Dictionary<string, string>();
                        List<SelectListItem> theItem = new List<SelectListItem>();
                        List<Subject> theSub = work.SubjectRepository.Get().OrderBy(a => a.Name).ToList();
                        foreach (var subject in theSub)
                        {
                            theItem.Add(new SelectListItem() { Text = subject.Name, Value = subject.Name });
                        }

                        //  theItem.Add(new SelectListItem() { Text = "PRIMART 1A", Value = "PRIMART 1A" });
                        ViewBag.Subjects = theItem;
                        ViewBag.Subject = theSub;
                        ModelState.AddModelError("", "Select at least one Subject to a given student");
                        //////
                        return View(model);
                    }

                    else
                    {
                        List<SubjectRegistration> theRegSub = work.SubjectRegistrationRepository.Get(a => a.UserID == model.UserID).ToList();

                        if (theRegSub.Count > 0)
                        {
                            // SubRegistrationViewModel model = new SubRegistrationViewModel();
                            SubjectRegistration thesubReg = new SubjectRegistration();
                            List<Subject> theSubjects = work.SubjectRepository.Get().OrderBy(a => a.Name).ToList();
                            model.Subjects = theSubjects;
                            model.SubjectRegistration = thesubReg;


                            Dictionary<string, string> theDic = new Dictionary<string, string>();
                            List<SelectListItem> theItem = new List<SelectListItem>();
                            List<Subject> theSub = work.SubjectRepository.Get().OrderBy(a => a.Name).ToList();
                            foreach (var subject in theSub)
                            {
                                theItem.Add(new SelectListItem() { Text = subject.Name, Value = subject.Name });
                            }

                            //  theItem.Add(new SelectListItem() { Text = "PRIMART 1A", Value = "PRIMART 1A" });
                            ViewBag.Subjects = theItem;
                            ViewBag.Subject = theSub;
                            ModelState.AddModelError("", "Class Subjects for Selected Class has been Created Earlier");
                            return View(model);
                        }
                        // TODO: Add insert logic here

                        List<Subject> theSubjects4 = new List<Subject>();
                        List<Subject> theSubjects2 = new List<Subject>();
                        foreach (var sub in SubjectRegistration)
                        {
                            theSubjects2 = work.SubjectRepository.Get(a => a.Name.Equals(sub)).ToList();
                            theSubjects4.Add(theSubjects2[0]);
                        }

                        SubjectRegistration theRealSub = new SubjectRegistration();
                        theRealSub.UserID = model.UserID;
                        theRealSub.Subjects = theSubjects4;
                        work.SubjectRegistrationRepository.Insert(theRealSub);
                        work.Save();

                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    // SubRegistrationViewModel model = new SubRegistrationViewModel();
                    SubjectRegistration thesubReg = new SubjectRegistration();
                    List<Subject> theSubjects = work.SubjectRepository.Get().OrderBy(a => a.Name).ToList();
                    model.Subjects = theSubjects;
                    model.SubjectRegistration = thesubReg;


                    Dictionary<string, string> theDic = new Dictionary<string, string>();
                    List<SelectListItem> theItem = new List<SelectListItem>();
                    List<Subject> theSub = work.SubjectRepository.Get().OrderBy(a => a.Name).ToList();
                    foreach (var subject in theSub)
                    {
                        theItem.Add(new SelectListItem() { Text = subject.Name, Value = subject.Name });
                    }

                    //  theItem.Add(new SelectListItem() { Text = "PRIMART 1A", Value = "PRIMART 1A" });
                    ViewBag.Subjects = theItem;
                    ViewBag.Subject = theSub;
                    ModelState.AddModelError("", "Candidate ID is not Valid, Try Again!");
                    return View(model);
                }
         
               
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SubjectRegistration/Edit/5

        public ActionResult Edit(int id)
        {
            SubjectRegistration theSubReg = work.SubjectRegistrationRepository.GetByID(id);

            PopulateAssignedSubjectData(theSubReg);
            return View(theSubReg);
            // return View();
        }

        private void PopulateAssignedSubjectData(SubjectRegistration instructor)
        {
            var allCourses = work.SubjectRepository.Get(); //db.Courses;
            var instructorCourses = new HashSet<int>(instructor.Subjects.Select(c => c.SubjectID));
            var viewModel = new List<AssignedSubjectData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedSubjectData
                {
                    SubjectID = course.SubjectID,
                    Name = course.Name,
                    Assigned = instructorCourses.Contains(course.SubjectID)
                });
            }
            ViewBag.Courses = viewModel;
        }

        //
        // POST: /SubjectRegistration/Edit/5
        [HttpPost]
        public ActionResult Edit(SubjectRegistration model, string[] selectedCourses)
        {
            List<SubjectRegistration> theReg = work.SubjectRegistrationRepository.Get(a => a.UserID == model.UserID).ToList();
            SubjectRegistration theRegi = theReg[0];
            SubjectRegistration SubjectRegistrationToUpdate = work.SubjectRegistrationRepository.GetByID(theRegi.SubjectRegistrationID);
            // SubjectRegistration SubjectRegistrationToUpdate = theReg[0];
            //var SubjectRegistrationToUpdate = db.SubjectRegistrations
            //    .Include("Subjects")
            //   .Where(i => i.Level == model.Level)
            //    .Single();
            if (TryUpdateModel(SubjectRegistrationToUpdate, "", null, new string[] { "Courses" }))
            {
                try
                {
                    //if (String.IsNullOrWhiteSpace(instructorToUpdate.OfficeAssignment.Location))
                    //{
                    //    instructorToUpdate.OfficeAssignment = null;
                    //}

                    // work.SubjectRegistrationRepository.Get(a=>a.Level.Equals(SubjectRegistrationToUpdate.Level))
                    UpdateInstructorCourses(selectedCourses, SubjectRegistrationToUpdate);
                    work.SubjectRegistrationRepository.Update(SubjectRegistrationToUpdate);
                    work.Save();

                    //  db. Update(SubjectRegistrationToUpdate);
                    // db.Save();

                    //  db.Entry(SubjectRegistrationToUpdate).State = EntityState.Modified;
                    // db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    //Log the error (add a variable name after DataException)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }

            }
            // PopulateAssignedCourseData(SubjectRegistrationToUpdate);
            // return View(instructorToUpdate);
            return View("Index");
        }






        //[HttpPost]
        //public ActionResult Edit(SubjectRegistration model, string[] selectedCourses)
        //{
        //    try
        //    {

        //        // TODO: Add update logic here
        //        List<Subject> theSubjects = new List<Subject>();
        //        List<Subject> theSubjects2 = new List<Subject>();
        //        foreach (var sub in selectedCourses)
        //        {
        //            int theIntValue = Convert.ToInt32(sub);
        //            theSubjects2 = work.SubjectRepository.Get(a => a.SubjectID == theIntValue).ToList();
        //            theSubjects.Add(theSubjects2[0]);
        //        }

        //        model.Subjects = theSubjects;
        //        work.SubjectRegistrationRepository.Update(model);
        //        work.Save();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        private void UpdateInstructorCourses(string[] selectedCourses, SubjectRegistration instructorToUpdate)
        {
            if (selectedCourses == null)
            {
                instructorToUpdate.Subjects = new List<Subject>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>
                (instructorToUpdate.Subjects.Select(c => c.SubjectID));
            foreach (var course in work.SubjectRepository.Get().ToList())
            {
                if (selectedCoursesHS.Contains(course.SubjectID.ToString()))
                {
                    if (!instructorCourses.Contains(course.SubjectID))
                    {
                        instructorToUpdate.Subjects.Add(course);
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.SubjectID))
                    {
                        instructorToUpdate.Subjects.Remove(course);
                    }
                }
            }
        }

        //
        // GET: /SubjectRegistration/Delete/5

        public ActionResult Delete(int id)
        {
            SubjectRegistration theRegistrations = work.SubjectRegistrationRepository.GetByID(id);
            return View(theRegistrations);
        }

        //
        // POST: /SubjectRegistration/Delete/5

        [HttpPost]
        public ActionResult Delete(SubjectRegistration model)
        {
            try
            {
                // TODO: Add delete logic here

                work.SubjectRegistrationRepository.Delete(model);
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
