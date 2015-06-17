using SilverDaleSchools.DAL;
using SilverDaleSchools.Model;
using SilverDalesSchools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.Security;
using SilverDaleSchools.Models;
using MvcMembership;
using System.Data.SqlClient;
using System.Data;

namespace SilverDaleSchools.Controllers
{
    [Authorize]
    //[DynamicAuthorize]
    public class StaffController : Controller
    {
        UnitOfWork work = new UnitOfWork();
        private readonly IUserService _userService;
        private readonly IRolesService _rolesService;
        //
        // GET: /Staff/
        //   public ActionResult Index()
        public ViewResult Index(string sortOrder, string currentFilter, string ApprovedString, string searchString, string SexString, string role, string StudentIDString, int? page)
        {
            List<SelectListItem> theItem3 = new List<SelectListItem>();
            string[] theRoles = Roles.GetAllRoles();
            theItem3.Add(new SelectListItem() { Text = "None", Value = "" });
            foreach (var theRole in theRoles)
            {
                theItem3.Add(new SelectListItem() { Text = theRole, Value = theRole });
            }
            ViewData["Role"] = theItem3;



            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            ViewBag.ClassSortParm = sortOrder == "class" ? "class desc" : "class";
            ViewBag.GenderSortParm = sortOrder == "gender" ? "gender desc" : "gender";

            if (Request.HttpMethod == "GET")
            {
                // searchString = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchString;

            var students = from s in work.PersonRepository.Get()
                           select s;

            students = students.Where(a => a.UserID != 5000001);
            students = students.Where(a => a.UserID != 5000002);
            //   students = students.Where(s => s.UserID != 5000001);
            //  students = students.Where(s => s.UserID != 5000052);
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                                       || s.FirstName.ToUpper().Contains(searchString.ToUpper()) || s.MiddleName.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!String.IsNullOrEmpty(SexString))
            {
                students = students.Where(s => s.Sex.Equals(SexString));
            }

            if (!String.IsNullOrEmpty(role))
            {
                students = students.Where(s => s.Role.Equals(role));
            }

            if (!String.IsNullOrEmpty(StudentIDString))
            {
                  int theID = Convert.ToInt32(StudentIDString);
                students = students.Where(s => s.UserID == theID);
            }

            if (!String.IsNullOrEmpty(SexString))
            {
                students = students.Where(s => s.Sex.Equals(SexString));
            }

            //if (!String.IsNullOrEmpty(ApprovedString))
            //{
            //    bool theValue = Convert.ToBoolean(ApprovedString);
            //    students = students.Where(s => s.IsApproved == theValue);
            //}
            switch (sortOrder)
            {
                case "Name desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "Date desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;

                //case "class":
                //    students = students.OrderBy(s => s.ClassTeacherOf);
                //    break;
                //case "class desc":
                //    students = students.OrderByDescending(s => s.ClassTeacherOf);
                //    break;

                case "gender":
                    students = students.OrderBy(s => s.Sex);
                    break;
                case "gender desc":
                    students = students.OrderByDescending(s => s.Sex);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 40;
            int pageNumber = (page ?? 1);
            ViewBag.Count = students.Count();
           // ViewBag.Count = results.Count();
            //if (!(User.IsInRole("SuperAdmin")))
            //{

            //    int UserName = Convert.ToInt32(User.Identity.Name);
            //    List<Staff> theStaff = work.StaffRepository.Get(a => a.UserID == UserName).ToList();
            //    Staff theStaf = theStaff[0];
            //   // students = students.Where(a => a.UserID == UserName && a.IsApproved == true);
            //    ViewBag.Count = students.Count();
            //    return View(students.ToPagedList(pageNumber, pageSize));

            //}
            // else
            // {
            return View(students.ToPagedList(pageNumber, pageSize));
            //  }
        }

        //
        // GET: /Staff/Details/5
        public ActionResult Details(int id)
        {
            Person theStaff = work.PersonRepository.GetByID(id);
            return View(theStaff);
        }

        //
        // GET: /Staff/Create
        public ActionResult Create()
        {
            List<SelectListItem> theItem3 = new List<SelectListItem>();
            string[] theRoles = Roles.GetAllRoles();

            theItem3.Add(new SelectListItem() { Text = "None", Value = "" });
            foreach (var role in theRoles)
            {
              //  if (role != "Student")
               // {

                    theItem3.Add(new SelectListItem() { Text = role, Value = role });
               // }

            }
            ViewData["Role"] = theItem3;
            return View();
        }

        //
        // POST: /Staff/Create
        [HttpPost]
        public ActionResult Create(Person model)
        {
            try
            {
                model.EnrollmentDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    if (Membership.GetUser(model.UserID.ToString()) == null)
                    {
                         //PaddPassword.
                        Membership.CreateUser(model.UserID.ToString(), PaddPassword.Padd(model.Password), "Person@yahoo.com");
                        Roles.AddUserToRole(model.UserID.ToString(), model.Role);
                        work.PersonRepository.Insert(model);
                        work.Save();
                    }
                    else
                    {

                        ModelState.AddModelError("", "Staff/Student ID Already Exist, Please user another ID!");
                        List<SelectListItem> theItem3 = new List<SelectListItem>();
                        string[] theRoles = Roles.GetAllRoles();

                        theItem3.Add(new SelectListItem() { Text = "None", Value = "" });
                        foreach (var role in theRoles)
                        {

                          //  if (role != "Student")
                           // {

                                theItem3.Add(new SelectListItem() { Text = role, Value = role });
                          //  }

                        }
                        ViewData["Role"] = theItem3;
                        return View();
                    }
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Staff/Edit/5
        public ActionResult Edit(int id)
        {
            List<SelectListItem> theItem3 = new List<SelectListItem>();
            string[] theRoles = Roles.GetAllRoles();
            // theItem3.Add(new SelectListItem() { Text = "None", Value = "" });
            foreach (var theRole in theRoles)
            {
              //  if (theRole != "Student")
              //  {

                    theItem3.Add(new SelectListItem() { Text = theRole, Value = theRole });
              //  }
            }
            ViewData["Role"] = theItem3;
            Person theStaff = work.PersonRepository.GetByID(id);
            return View(theStaff);
        }

        //
        // POST: /Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(Person model)
        {
            try
            {
                // TODO: Add update logic here
                UnitOfWork work2 = new UnitOfWork();
                Person staff = work2.PersonRepository.GetByID(model.PersonID);
                string[] RoleList = Roles.GetAllRoles();
                //  Roles.RemoveUserFromRoles(model.UserID.ToString(), RoleList);
                foreach (var role in RoleList)
                {
                    if (Roles.IsUserInRole(model.UserID.ToString(), role))
                    {
                        Roles.RemoveUserFromRole(model.UserID.ToString(), role);
                    }
                }
                Roles.AddUserToRole(model.UserID.ToString(), model.Role);
                // work.StaffRepository.Update(model);

                SilverDaleSchools.Models.Tweaker.AdjustTimer(model.UserID.ToString());
                TryUpdateModel(model);
                if (ModelState.IsValid)
                {
                    work.PersonRepository.Update(model);
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
        // GET: /Staff/Delete/5
        public ActionResult Delete(int id)
        {
            Person theStaff = work.PersonRepository.GetByID(id);
            return View(theStaff);
        }

        //
        // POST: /Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(Person model)
        {
            try
            {
                // TODO: Add delete logic here
                Person theStaff = work.PersonRepository.GetByID(model.PersonID);

                string theUserString = model.UserID.ToString();// user.UserName;
                var user = Membership.GetUser(theUserString);
                _rolesService.RemoveFromAllRoles(user);
                _userService.Delete(user);

                work.PersonRepository.Delete(theStaff);
                work.Save();

                // DELETE FROM table_name WHERE some_column=some_value
                string con = System.Configuration.ConfigurationManager.ConnectionStrings["stDatabase"].ConnectionString;
                SqlConnection conn = new System.Data.SqlClient.SqlConnection(con);
                SqlCommand updateCmd = new SqlCommand("DELETE FROM Users " +
                    //"SET LastActivityDate = @LastActivityDate " +
          "WHERE UserName = @UserName", conn);

                //  updateCmd.Parameters.Add("@LastActivityDate", SqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).AddMinutes(-10);
                updateCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = theUserString;
                //updateCmd.Parameters.Add("@ApplicationName", SqlDbType.VarChar, 255).Value = m_ApplicationName;
                conn.Open();
                updateCmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
