using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using SilverDaleSchools.Models;
using System.Web.Security;
using SilverDaleSchools.DAL;
using System.Data.SqlClient;
using System.Data;
using SilverDaleSchools.Model;

namespace SilverDaleSchools.Controllers
{

    [Authorize]
    // [RequireHttps]
    public class AccountController : Controller
    {
        UnitOfWork work = new UnitOfWork();
        //
        // GET: /Account/Login


        // [AllowAnonymous]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {

            //List<MyRole> theRoles = work.MyRoleRepository.Get().ToList();

            //if (theRoles.Count == 0)
            //{
            //    string[] theaddCoddedRoles = Roles.GetAllRoles();


            //    foreach (var role in theaddCoddedRoles)
            //    {

            //        MyRole theRle = new MyRole();
            //        theRle.RoleName = role;
            //        theRle.Attendance = "";
            //        theRle.AttendanceStaff = "";
            //        theRle.BulkSMS = "";
            //        theRle.ClassSubject = "";
            //        theRle.Exam = "";
            //        theRle.Level = "";
            //        theRle.Material = "";
            //        theRle.NewsBoard = "";
            //        theRle.OnlineExam = "";
            //        theRle.OrderItem = "";
            //        theRle.Parent = "";
            //        theRle.Post = "";
            //        theRle.Result = "";
            //        theRle.SchoolFeePayment = "";
            //        theRle.SecondarySchoolStudent = "";
            //        theRle.Staff = "";
            //        theRle.Store = "";
            //        theRle.Student = "";
            //        theRle.StudentFees = "";
            //        theRle.StudentStoreItem = "";
            //        theRle.Subject = "";
            //        theRle.TimeTable = "";


            //        work.MyRoleRepository.Insert(theRle);
            //    }

            //    work.Save();
            //    //  theRoles = work.MyRoleRepository.Get(a => a.RoleName.Equals(roleName)).ToList();
            //}
          //  return View("Blocked");
            return View();

        }

        //
        // POST: /Account/Login

        [AllowAnonymous]
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            model.UserName = Server.HtmlEncode(model.UserName);
            model.Password = Server.HtmlEncode(model.Password);
            string name = null;
            //try
            //{
            //    name = Membership.GetUser(model.UserName).ToString();
            //}
            //catch (Exception e)
            //{
            //    // if (string.IsNullOrEmpty(name))
            //    // {
            //    name = "8080";
            //    // }
            //}
            if (ModelState.IsValid)
            {
                bool value = false;
                try
                {
                    value = Membership.GetUser(model.UserName).IsOnline;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    return View();
                }


                //A user is considered online if the current date and
                // time minus the UserIsOnlineTimeWindow property value is
                // earlier than the LastActivityDate for the user.
               // if (value && name != "5000001")
                 if (false)
                {

                    //if (DateTime.UtcNow.AddMinutes(-(Membership.UserIsOnlineTimeWindow)) < Membership.GetUser(model.UserName).LastActivityDate)
                    {
                        ModelState.AddModelError("", "You have Logged-In in another System, Log-Out and try again");

                    }

                    //  (DateTime -)
                    // if (User.Identity.IsAu(value == true)
                    // return RedirectToAction("Login", "Account");
                    //  ModelState.AddModelError("", "You have Logged-In in another System, Log-Out and try again");
                }
                else
                {



                    if (Membership.ValidateUser(model.UserName, model.Password))
                    {

                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            string con = System.Configuration.ConfigurationManager.ConnectionStrings["stDatabase"].ConnectionString;
                            SqlConnection conn = new System.Data.SqlClient.SqlConnection(con);
                            SqlCommand updateCmd = new SqlCommand("UPDATE Users " +
                      "SET LastActivityDate = @LastActivityDate " +
                      "WHERE UserName = @UserName", conn);
                            // TimeZoneInfo.ConvertTimeToUtc(DateTime.Now)  DateTime.UtcNow.AddMinutes(-10);
                            updateCmd.Parameters.Add("@LastActivityDate", SqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).AddMinutes(-10);
                            updateCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 255).Value = User.Identity.Name;
                            //updateCmd.Parameters.Add("@ApplicationName", SqlDbType.VarChar, 255).Value = m_ApplicationName;
                            conn.Open();
                            updateCmd.ExecuteNonQuery();
                            conn.Close();
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            string con = System.Configuration.ConfigurationManager.ConnectionStrings["stDatabase"].ConnectionString;
                            SqlConnection conn = new System.Data.SqlClient.SqlConnection(con);
                            SqlCommand updateCmd = new SqlCommand("UPDATE Users " +
                      "SET LastActivityDate = @LastActivityDate " +
                      "WHERE UserName = @UserName", conn);
                            // TimeZoneInfo.ConvertTimeToUtc(DateTime.Now)  DateTime.UtcNow.AddMinutes(-10);
                            updateCmd.Parameters.Add("@LastActivityDate", SqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).AddMinutes(-10);
                            updateCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 255).Value = User.Identity.Name;
                            //updateCmd.Parameters.Add("@ApplicationName", SqlDbType.VarChar, 255).Value = m_ApplicationName;
                            conn.Open();
                            updateCmd.ExecuteNonQuery();
                            conn.Close();

                            SilverDaleSchools.DAL.UnitOfWork work = new SilverDaleSchools.DAL.UnitOfWork();
                            string UserName = model.UserName;

                                int UserNameInt = Convert.ToInt32( model.UserName);
                            Session["UserName"] = UserName;
                            List<SilverDaleSchools.Model.MyRole> theRole = null;
                            List<SilverDaleSchools.Model.Person> thePerson = null;
                            SilverDaleSchools.Model.Person theRealPerson = null;

                            //List<SilverDaleSchools.Model.Staff> theS = null;
                            List<SilverDaleSchools.Model.Person> theStu = null;

                            theStu = work.PersonRepository.Get(a => a.UserID == UserNameInt).ToList();
                           // theStu = work.StudentRepository.Get(a => a.UserID == UserName).ToList();
                           // SilverDaleSchools.Model.Parent theRealParent = null;
                           // SilverDaleSchools.Model.SecondarySchoolStudent theRealSecondarySchoolStudent = null;
                          //  SilverDaleSchools.Model.Student theRealPrimarySchoolStudent = null;
                            if (UserName != "")
                            {
                               // int userName = Convert.ToInt32(UserName);
                               //// List<Parent> theP1 = work.ParentRepository.Get(a => a.UserID == userName).ToList();
                               // //Parent theR = theP1[0];
                               // // MembershipUser user = Membership.GetUser(Convert.ToString(UserName), false); ;
                               // // MembershipUserCollection theUser =   Membership.FindUsersByName(UserName);
                               // //MembershipUser k =  theUser[0];
                               // if (theP1.Count() != 0)
                               // //if (user..IsInRole("Parent")) 
                               // {
                               //     //  int userName = Convert.ToInt32(UserName); ;
                               //     List<Parent> theP = work.ParentRepository.Get(a => a.UserID == userName).ToList();
                               //     theRealParent = theP[0];
                               //     Session["theRealParent"] = theRealParent;
                               //     theRole = work.MyRoleRepository.Get(a => a.RoleName.Equals(theRealParent.Role)).ToList();

                               //     Session["theRole"] = theRole;
                              //  }
                              //  else
                              //  {
                                  //  int UserNameInt = Convert.ToInt32(UserName);

                                //if ((theRealPerson is SilverDaleSchools.Model.Staff))

                                if (theStu.Count > 0)
                                {
                                   // List<Staff> theStaff = new List<Staff>();
                                   // theStaff = work.StaffRepository.Get(a => a.UserID == UserName).ToList();
                                   // theRealPerson = theStaff[0];
                                    Session["theRealPerson"] = theStu[0];// theRealPerson;
                                }

                               // if ((theRealPerson is SilverDaleSchools.Model.Student))
                               if (theStu.Count > 0)
                                {
                                   // List<Student> theStudent = new List<Student>();
                                   // theStudent = work.StudentRepository.Get(a => a.UserID == UserName).ToList();
                                   // theRealPerson = theStudent[0];
                                    Session["theRealPerson"] = theStu[0];// theRealPerson;
                                }
                                    //thePerson = work.PersonRepository.Get(a => a.UserID == UserName).ToList();
                                    //theRealPerson = thePerson[0];
                                    //Session["theRealPerson"] = theRealPerson;

                                    //theRole = work.MyRoleRepository.Get(a => a.RoleName.Equals(theRealPerson.Role)).ToList();

                                   // Session["theRole"] = theRole;
                                  //  if (!(theRealPerson is SilverDaleSchools.Model.Staff))
                                    if (theStu.Count > 0)
                                    {
                                      //Student theStudent = (Student)  theRealPerson;

                                       // theRealPrimarySchoolStudent = work.PersonRepository.GetByID(theStudent.StudentID);

                                        Session["theRealPrimarySchoolStudent"] = theStu[0];// work.PersonRepository.GetByID(theStudent.StudentID);
                                    }
                                }
                            //}


                            return RedirectToAction("Index", "Home");

                        }

                    }
                    else
                    {
                        string con = System.Configuration.ConfigurationManager.ConnectionStrings["stDatabase"].ConnectionString;
                        SqlConnection conn = new System.Data.SqlClient.SqlConnection(con);
                        SqlCommand updateCmd = new SqlCommand("UPDATE Users " +
                  "SET LastActivityDate = @LastActivityDate " +
                  "WHERE UserName = @UserName", conn);
                        // TimeZoneInfo.ConvertTimeToUtc(DateTime.Now)  DateTime.UtcNow.AddMinutes(-10);
                        updateCmd.Parameters.Add("@LastActivityDate", SqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).AddMinutes(-10);
                        updateCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 255).Value = Membership.GetUser(model.UserName).UserName;
                        //updateCmd.Parameters.Add("@ApplicationName", SqlDbType.VarChar, 255).Value = m_ApplicationName;
                        conn.Open();
                        updateCmd.ExecuteNonQuery();
                        conn.Close();
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["stDatabase"].ConnectionString;
            SqlConnection conn = new System.Data.SqlClient.SqlConnection(con);

            // MembershipUser me = Membership.GetUser(false);
            FormsAuthentication.SignOut();
            // me.LastActivityDate = DateTime.Now.AddMinutes(-10);
            //  Membership.UpdateUser(me);

            SqlCommand updateCmd = new SqlCommand("UPDATE Users " +
                    "SET LastActivityDate = @LastActivityDate " +
                    "WHERE UserName = @UserName", conn);

            updateCmd.Parameters.Add("@LastActivityDate", SqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).AddMinutes(-10);
            updateCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 255).Value = User.Identity.Name;
            //updateCmd.Parameters.Add("@ApplicationName", SqlDbType.VarChar, 255).Value = m_ApplicationName;
            conn.Open();
            updateCmd.ExecuteNonQuery();
            conn.Close();


            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Attempt to register the user
        //        MembershipCreateStatus createStatus;
        //        Membership.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);

        //        if (createStatus == MembershipCreateStatus.Success)
        //        {
        //            FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", ErrorCodeToString(createStatus));
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        //
        // GET: /Account/ChangePassword

        public ActionResult ChangePassword()
        {
            return View("ChangePassword");
        }

        //
        // POST: /Account/ChangePassword

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, userIsOnline: true);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }


        [AllowAnonymous]
        public ActionResult ValidateCodeSec(string passwordsec)
        {
            if (passwordsec == "33353")
            {
                return RedirectToAction("Create", "SecondarySchoolStudent", new { pass = passwordsec });

            }
            else
            {
                ViewBag.ID = 1;
                return RedirectToAction("Login", "Account");
                //  RedirectToAction("Login", "Account", new { returnUrl ="/"});
            }
            // return View();

        }
        [AllowAnonymous]
        // public dynamic ValidateCode(string code)
        //public ViewResult ValidateCode(string code)
        public ActionResult ValidateCode(string passwordPrimary)
        {

            if (passwordPrimary == "33353")
            {
                return RedirectToAction("Create2", "PrimarySchoolStudent");
                // return View("Create2");

            }
            else
            {
                ViewBag.ID = 1;
                return RedirectToAction("Login", "Account");
                //  RedirectToAction("Login", "Account", new { returnUrl = "/" });
                // return View("Login");

            }
            // return View();
            // RedirectToAction("Login", "Account", new { returnUrl = "/" });
            //  }



        }

        private IEnumerable<string> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}