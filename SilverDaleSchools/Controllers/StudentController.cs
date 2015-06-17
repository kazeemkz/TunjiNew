//using SilverDaleSchools.DAL;
//using SilverDaleSchools.Model;
//using SilverDaleSchools.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using PagedList;
//using System.Web.Security;
//using MvcMembership;
//using System.Data.SqlClient;
//using System.Data;

//namespace SilverDaleSchools.Controllers
//{
//    [Authorize]
//    [DynamicAuthorize]
//    public class StudentController : Controller
//    {
//        UnitOfWork work = new UnitOfWork();
//        private readonly IUserService _userService;
//        private readonly IRolesService _rolesService;
//        //
//        // GET: /Student/
//        public ViewResult Index(string arm, string sortOrder, string PrimarySec, string currentFilter, string ApprovedString, string searchString, string SexString, string LevelString, string StudentIDString, int? page)
//        {

//            List<Level> theLevels = work.LevelRepository.Get().ToList();
//            List<SelectListItem> theItem = new List<SelectListItem>();
//            theItem.Add(new SelectListItem() { Text = "None", Value = "" });


//            ViewBag.CurrentSort = sortOrder;
//            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
//            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
//            ViewBag.ClassSortParm = sortOrder == "class" ? "class desc" : "class";
//            ViewBag.GenderSortParm = sortOrder == "gender" ? "gender desc" : "gender";

//            if (Request.HttpMethod == "GET")
//            {
//                // searchString = currentFilter;
//            }
//            else
//            {
//                page = 1;
//            }
//            ViewBag.CurrentFilter = searchString;

//            var students = from s in work.StudentRepository.Get()
//                           select s;



//            //if (!String.IsNullOrEmpty(ApprovedString))
//            //{
//            //    bool theValue = Convert.ToBoolean(ApprovedString);
//            //    students = students.Where(s => s.IsApproved == theValue);
//            //}


//            if (!String.IsNullOrEmpty(SexString))
//            {
//                students = students.Where(s => s.Sex.Equals(SexString));
//            }




//            //if (!String.IsNullOrEmpty(LevelString))
//            //{
//            //    //students = students.Where(s => s.PresentLevel.Equals(LevelString) && s.PresentLevel !=null);
//            //    students = students.Where(s => s.PresentLevel == LevelString);
//            //}


//            //if (!String.IsNullOrEmpty(arm))
//            //{
//            //    //students = students.Where(s => s.PresentLevel.Equals(LevelString) && s.PresentLevel !=null);
//            //    students = students.Where(s => s.LevelType == arm);
//            //}



//            if (!String.IsNullOrEmpty(searchString))
//            {
//                students = students.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
//                                       || s.FirstName.ToUpper().Contains(searchString.ToUpper()) || s.Middle.ToUpper().Contains(searchString.ToUpper()));
//            }




//            if (!String.IsNullOrEmpty(StudentIDString))
//            {
//                // int theID = Convert.ToInt32(StudentIDString);
//                students = students.Where(s => s.UserID == StudentIDString);
//            }


//            switch (sortOrder)
//            {
//                case "Name desc":
//                    students = students.OrderByDescending(s => s.LastName);
//                    break;
//                //case "Date":
//                //    students = students.OrderBy(s => s.EnrollmentDate);
//                //    break;
//                //case "Date desc":
//                //    students = students.OrderByDescending(s => s.EnrollmentDate);
//                //    break;

//                //case "class":
//                //    students = students.OrderBy(s => s.PresentLevel);
//                //    break;
//                //case "class desc":
//                //    students = students.OrderByDescending(s => s.PresentLevel);
//                //    break;

//                case "gender":
//                    students = students.OrderBy(s => s.Sex);
//                    break;
//                case "gender desc":
//                    students = students.OrderByDescending(s => s.Sex);
//                    break;
//                default:
//                    students = students.OrderBy(s => s.LastName);
//                    break;
//            }

//            int pageSize = 50;
//            int pageNumber = (page ?? 1);

//            if (User.IsInRole("Student"))
//            {

//                ViewBag.Count = 1;
//                // int UserName = Convert.ToInt32(User.Identity.Name);
//                // List<PrimarySchoolStaff> theStaff = work.PrimarySchoolStaffRepository.Get(a => a.UserID == UserName).ToList();
//                //PrimarySchoolStaff theStaf = theStaff[0];
//                students = students.Where(a => a.UserID == User.Identity.Name);
//                return View(students.ToPagedList(pageNumber, pageSize));


//            }


//            else
//            {
//                ViewBag.Count = students.Count();
//                return View(students.ToPagedList(pageNumber, pageSize));
//            }
//        }

//        //
//        // GET: /Student/Details/5
//        public ActionResult Details(int id)
//        {
//            Student theStudent = work.StudentRepository.GetByID(id);
//            return View(theStudent);
//        }

//        //
//        // GET: /Student/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        //
//        // POST: /Student/Create
//        [HttpPost]
//        public async Task<ActionResult> Create(IEnumerable<HttpPostedFileBase> file)
//        //  public ActionResult Create(IEnumerable<HttpPostedFileBase> file)
//        {
//            try
//            {
//                // TODO: Add insert logic here
//                if (string.IsNullOrEmpty(Request.Files[0].FileName))
//                {
//                  ModelState.AddModelError("","No Uploaded Document!");
//                    return View();
//                }
//                if ((Request.Files[0].FileName.EndsWith(".xlsx")) || (Request.Files[0].FileName.EndsWith(".xls")))
//                {
//                    string fileExtension = System.IO.Path.GetExtension(Request.Files[0].FileName);
//                    //    string physicalPath = HttpContext.Server.MapPath("~/Content/") + Request.Files[0].FileName;


//                    HttpPostedFileBase theFile = Request.Files[0];

//                    //    file
//                    // ReadExcelFile.

//                    await new ReadExcelFile().Read(fileExtension, theFile);
//                }
//                else
//                {
//                    ModelState.AddModelError("", "The Input File is not a valid Excel  file!");
//                    return View();
//                }



//                return RedirectToAction("Index");
//            }
//            catch
//            {

//                return View();
//            }
//        }

//        //
//        // GET: /Student/Edit/5
//        public ActionResult Edit(int id)
//        {
//            Student theStudent = work.StudentRepository.GetByID(id);
//            List<SelectListItem> theItem3 = new List<SelectListItem>();
//            string[] theRoles = Roles.GetAllRoles();
//            theItem3.Add(new SelectListItem() { Text = "None", Value = "" });
//            foreach (var role in theRoles)
//            {

//                theItem3.Add(new SelectListItem() { Text = role, Value = role });

//            }
//            ViewData["Role"] = theItem3;
//            return View(theStudent);
//        }

//        //
//        // POST: /Student/Edit/5
//        [HttpPost]
//        public ActionResult Edit(Student model)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                TryUpdateModel(model);
//                if (ModelState.IsValid)
//                {
//                    work.StudentRepository.Update(model);
//                    work.Save();
//                }


//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                List<SelectListItem> theItem3 = new List<SelectListItem>();
//                string[] theRoles = Roles.GetAllRoles();
//                theItem3.Add(new SelectListItem() { Text = "None", Value = "" });
//                foreach (var role in theRoles)
//                {

//                    theItem3.Add(new SelectListItem() { Text = role, Value = role });

//                }
//                ViewData["Role"] = theItem3;
//                return View();
//            }
//        }

//        //
//        // GET: /Student/Delete/5
//        public ActionResult Delete(int id)
//        {
//            Student theStudent = work.StudentRepository.GetByID(id);
//            return View(theStudent);
//        }

//        //
//        // POST: /Student/Delete/5
//        [HttpPost]
//        public ActionResult Delete(Student model)
//        {
//            try
//            {
//                // TODO: Add delete logic here
//                Student theStudent = work.StudentRepository.GetByID(model.StudentID);

//                string theUserString = theStudent.UserID;// user.UserName;
//                var user = Membership.GetUser(theUserString);
//                _rolesService.RemoveFromAllRoles(user);
//                _userService.Delete(user);

//                work.StudentRepository.Delete(theStudent);
//                work.Save();


//                // DELETE FROM table_name WHERE some_column=some_value
//                string con = System.Configuration.ConfigurationManager.ConnectionStrings["stDatabase"].ConnectionString;
//                SqlConnection conn = new System.Data.SqlClient.SqlConnection(con);
//                SqlCommand updateCmd = new SqlCommand("DELETE FROM Users " +
//                    //"SET LastActivityDate = @LastActivityDate " +
//          "WHERE UserName = @UserName", conn);

//                //  updateCmd.Parameters.Add("@LastActivityDate", SqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).AddMinutes(-10);
//                updateCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = theUserString;
//                //updateCmd.Parameters.Add("@ApplicationName", SqlDbType.VarChar, 255).Value = m_ApplicationName;
//                conn.Open();
//                updateCmd.ExecuteNonQuery();
//                conn.Close();
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
