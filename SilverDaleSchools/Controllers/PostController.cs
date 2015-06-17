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

namespace SilverDaleSchools.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        //
        // GET: /Post/
        UnitOfWork work = new UnitOfWork();
        sdContext db = new sdContext();
      //  [DynamicAuthorize]
        public ActionResult Index(int? page, string sortOrder, string currentFilter)
        {
            //throw new Exception();
            int pageSize = 40;
            int pageNumber = (page ?? 1);

            Int32 theUserName = Convert.ToInt32(User.Identity.Name);

            Person theStudent = work.PersonRepository.Get(a => a.UserID == theUserName).First();

            if (theStudent.Role == "SuperAdmin")
            {


                Person theStudent1 = work.PersonRepository.Get(a => a.UserID == theUserName).First();

           //  List<Subject> theRegisteredSubjects =   theStudent1..Subjects as List<Subject> ;
                 List<Subject> theRegisteredSubjects =   work.SubjectRepository.Get().ToList() ;
             //   List<Post> thePost = work.PostRepository.Get(a => a.Class == theStudent1.LevelType).ToList();

             List<Post> thePosts = new List<Post>();
             List<Post> thePosts1 = new List<Post>();
                thePosts1 = work.PostRepository.Get().ToList();

                //if(thePosts.Count > 0)
                //{

                //}
                // foreach (var s in theRegisteredSubjects)
                 //{
                    // if(thePosts1.Count > 0)
                    // {
                         List<Post> thePost = db.Posts.Include("Comments").ToList();

                        // if (thePost.Count > 0)
                        // {
                           //  thePosts.Add(thePost[0]);
                        // }
                    // }
                      
               // }

                 return View(thePost.OrderByDescending(a => a.DateCreated).ToPagedList(pageNumber, pageSize));
                //  return View(thePost.OrderByDescending(a => a.DateCreated));

            }
            else
           // if (theStudent is PrimarySchoolStaff)
            {
             
            string theUser =    User.Identity.Name;
      //   List<SubjectRegistration> theRegisteredSubjects =   work.SubjectRegistrationRepository.Get(a => a.UserID == theUser).ToList();
            List<Post> thePosts1 = work.PostRepository.Get().ToList();
            List<SubjectRegistration> theRegisteredSubjects =      db.SubjectRegistrations.Include("Subjects").Where(a => a.UserID == theUser).ToList();
         List<Post> theUserPost = new List<Post>();
                foreach(SubjectRegistration s in theRegisteredSubjects)
                {
                    if (thePosts1.Count > 0)
                    {
                        foreach (Subject sub in s.Subjects)
                        {
                            List<Post> thPost = db.Posts.Include("Comments").Where(a => a.Subject == sub.Name).ToList();

                            theUserPost.AddRange(thPost);
                        }
                    }
                  //  theUserPost
                }
                  //List<Post> thePostAdmin = db.Posts.Include("Comments").ToList();
                //}
                //  List<Post> thePostStudent = work.PostRepository.Get(a => a.Level).ToList();
                //  return View();
                return View(theUserPost.OrderByDescending(a => a.DateCreated).ToPagedList(pageNumber, pageSize));
                // return View(thePost.OrderByDescending(a => a.DateCreated));
            }

            return View();
        }

        //
        // GET: /Post/Details/5
      //  [DynamicAuthorize]
        public ActionResult Details(int id)
        {
              // List<Post> thePost  = db.Posts.Include("Comments").Where(a => a.Level == "Non-Student").ToList();/
            Post thePost = db.Posts.Include("Comments").Where(a => a.PostID == id).First();// work.PostRepository.GetByID(id);
            return View(thePost);
        }

        //
        // GET: /Post/Create
       // [DynamicAuthorize]
        public ActionResult Create()
        {
            string theUser = User.Identity.Name;
            //   List<SubjectRegistration> theRegisteredSubjects =   work.SubjectRegistrationRepository.Get(a => a.UserID == theUser).ToList();

            List<SubjectRegistration> theRegisteredSubjects = db.SubjectRegistrations.Include("Subjects").Where(a => a.UserID == theUser).ToList();
            List<Subject> theUserPost = new List<Subject>();
            List<SelectListItem> theItem = new List<SelectListItem>();
            theItem.Add(new SelectListItem() { Text = "None", Value = "" });
            foreach (SubjectRegistration s in theRegisteredSubjects)
            {
                foreach (Subject sub in s.Subjects)
                {
                   // List<Post> thPost = db.Posts.Include("Comments").Where(a => a.Subject == sub.Name).ToList();

                    theItem.Add(new SelectListItem() { Text = sub.Name, Value = sub.Name  });
                   // theUserPost.Add(sub);// AddRange(thPost);
                }

                //  theUserPost
            }
            //List<Level> theLevels = work.LevelRepository.Get().ToList();
            //List<SelectListItem> theItem = new List<SelectListItem>();
            //theItem.Add(new SelectListItem() { Text = "None", Value = "" });

            //foreach (var level in theLevels)
            //{
            //    theItem.Add(new SelectListItem() { Text = level.LevelName + ":" + level.Type, Value = level.LevelName + ":" + level.Type });
            //}

            ViewData["arm"] = theItem;
            return View();
        }

        //
        // POST: /Post/Create

        [HttpPost]
      //  [DynamicAuthorize]
        public ActionResult Create(Post model)
        {

            if (User.IsInRole("Student"))
            {
                Int32 userId = Convert.ToInt32(User.Identity.Name);
                Person theUser = work.PersonRepository.Get(a => a.UserID == userId).First();

               // model.Class = theUser.LevelType;
            }
            if (string.IsNullOrEmpty(model.Subject))
            {
                string theUser = User.Identity.Name;
                //   List<SubjectRegistration> theRegisteredSubjects =   work.SubjectRegistrationRepository.Get(a => a.UserID == theUser).ToList();

                List<SubjectRegistration> theRegisteredSubjects = db.SubjectRegistrations.Include("Subjects").Where(a => a.UserID == theUser).ToList();
                List<Subject> theUserPost = new List<Subject>();
                List<SelectListItem> theItem = new List<SelectListItem>();
                theItem.Add(new SelectListItem() { Text = "None", Value = "" });
                foreach (SubjectRegistration s in theRegisteredSubjects)
                {
                    foreach (Subject sub in s.Subjects)
                    {
                        // List<Post> thPost = db.Posts.Include("Comments").Where(a => a.Subject == sub.Name).ToList();

                        theItem.Add(new SelectListItem() { Text = sub.Name, Value = sub.Name });
                        // theUserPost.Add(sub);// AddRange(thPost);
                    }

                    //  theUserPost
                }

                ViewData["arm"] = theItem;
                ModelState.AddModelError("", " Please Choose a Course!");
                return View();
            }

            Int32 theUserName = Convert.ToInt32(User.Identity.Name);
            Person thePerson = work.PersonRepository.Get(a => a.UserID == theUserName).First();
            model.DateCreated = DateTime.Now;
            //if (thePerson is PrimarySchoolStudent)
            //{
            //    PrimarySchoolStudent theStudent = work.PrimarySchoolStudentRepository.Get(a => a.UserID == theUserName).First();
            //    // PrimarySchoolStudent new 
            //    model.Level = theStudent.PresentLevel;
            //}
            //else
            //{
            //    model.Level = "Non-Student";
            //}
            model.PosterName = thePerson.UserID;
            model.RealName = thePerson.FirstName + " " + thePerson.LastName;
            model.Role = thePerson.Role;
            try
            {
                if (ModelState.IsValid)
                {
                    work.PostRepository.Insert(model);
                    work.Save();
                }
                // TODO: Add insert logic here

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

                ViewData["arm"] = theItem;
                return View();
            }
        }

        //
        // GET: /Post/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Post/Delete/5

        public ActionResult Delete(int id)
        {
            Post thePost = work.PostRepository.GetByID(id);

            work.PostRepository.Delete(thePost);
            work.Save();
            return RedirectToAction("Index");
            //  return View();
        }

        //
        // POST: /Post/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
