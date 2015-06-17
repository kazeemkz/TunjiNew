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
using System.Web.Security;
//using SilverDalesSchool.Model;
//using SilverDaleSchools.Model;
//using PagedList.Mvc;

namespace SilverDaleSchools.Controllers
{
     [Authorize]
    public class CommentController : Controller
    {

        //
        // GET: /Comment/
        UnitOfWork work = new UnitOfWork();


        public ActionResult Index(int PostID = 0)
        {
            Membership.GetUser(true);
            List<Comment> PostComment = work.CommentRepository.Get(a => a.PostID == PostID).ToList();
            return View(PostComment);
        }

        //
        // GET: /Comment/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Comment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Comment/Create

        [HttpPost]
        public ActionResult Create(string Commment, int PostID)
        {
            try
            {
                if (string.IsNullOrEmpty(Commment))
                {
                    return RedirectToAction("Details", "Post", new { id = PostID });
                }
                Int32 theUserName = Convert.ToInt32(User.Identity.Name);
                Person thePerson = work.PersonRepository.Get(a => a.UserID == theUserName).First();
                Comment theComment = new Comment();
                theComment.PostID = PostID;
                theComment.Role = thePerson.Role;
                theComment.Content = Commment;
                theComment.DateCreated = DateTime.Now;
                theComment.CommenterName = thePerson.FirstName + " " + thePerson.LastName;
                theComment.Commenter = theUserName;
                //   theComment.

                work.CommentRepository.Insert(theComment);
                work.Save();
                // TODO: Add insert logic here
                Membership.GetUser(true);
                return RedirectToAction("Details", "Post", new { id = PostID });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Comment/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Comment/Edit/5

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
        // GET: /Comment/Delete/5

        // public ActionResult Delete(int id)
        // {
        //     return View();
        // }

        //
        // POST: /Comment/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Comment theUserComment = work.CommentRepository.GetByID(id);
                Post CommentPost = work.PostRepository.GetByID(theUserComment.PostID);
                work.CommentRepository.Delete(theUserComment);
                work.Save();
                // TODO: Add delete logic here
                Membership.GetUser(true);
                return RedirectToAction("Details", "Post", new { id = theUserComment.PostID });
            }
            catch
            {
                return View();
            }
        }
    }
}
