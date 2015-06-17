using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Security;
using MvcMembership;
using MvcMembership.Settings;
using SilverDaleSchools.Models;
//using SilverDaleSchools.Models;
using SilverDaleSchools.DAL;
using SilverDaleSchools.Model;
using System.Data;
using System.Data.SqlClient;
//using SampleWebsite.Mvc3.Areas.MvcMembership.Models.UserAdministration;

namespace SilverDaleSchools.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    //[AuthorizeUnlessOnlyUser(Roles = "SuperAdmin")] // allows access if you're the only user, only validates role if role provider is enabled
    public class UserAdministrationController : Controller
    {
        // SelectList
        UnitOfWork work = new UnitOfWork();
        private const int PageSize = 40;
        private const string ResetPasswordBody = "Your new password is: ";
        private const string ResetPasswordSubject = "Your New Password";
        private readonly IRolesService _rolesService;
        private readonly ISmtpClient _smtpClient;
        private readonly IMembershipSettings _membershipSettings;
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public UserAdministrationController()
            : this(new AspNetMembershipProviderWrapper(), new AspNetRoleProviderWrapper(), new SmtpClientProxy())
        {
        }

        public UserAdministrationController(AspNetMembershipProviderWrapper membership, IRolesService roles, ISmtpClient smtp)
            : this(membership.Settings, membership, membership, roles, smtp)
        {
        }

        public UserAdministrationController(
            IMembershipSettings membershipSettings,
            IUserService userService,
            IPasswordService passwordService,
            IRolesService rolesService,
            ISmtpClient smtpClient)
        {
            _membershipSettings = membershipSettings;
            _userService = userService;
            _passwordService = passwordService;
            _rolesService = rolesService;
            _smtpClient = smtpClient;
        }
        // [Authorize(Roles = "SuperAdmin")] 
        public ActionResult Index(int? page, string search)
        {
            var users = string.IsNullOrWhiteSpace(search)
                ? _userService.FindAll(page ?? 1, PageSize)
                : search.Contains("@")
                    ? _userService.FindByEmail(search, page ?? 1, PageSize)
                    : _userService.FindByUserName(search, page ?? 1, PageSize);

            //  users.ToLookup()
            if (!string.IsNullOrWhiteSpace(search) && users.Count == 1)
                return RedirectToAction("Details", new { id = users[0].ProviderUserKey.ToString() });

            return View(new IndexViewModel
                            {
                                Search = search,
                                Users = users,
                                Roles = _rolesService.Enabled
                                    ? _rolesService.FindAll()
                                    : Enumerable.Empty<string>(),
                                IsRolesEnabled = _rolesService.Enabled
                            });
        }

        public string GetUserName(string userID)
        {
            Int32 user = Convert.ToInt32(userID);
            List<Person> thePersons = new List<Person>();
            string names = " ";
            Int32 id = 0;
            try
            {
                // id = Convert.ToInt32(userID);

                thePersons = work.PersonRepository.Get(a => a.UserID == user).ToList();

            }
            catch (Exception e)
            {
                return names;
            }

            try
            {
                //if (thePersons.Count() == 0)
                //{
                //    Parent pa = work.ParentRepository.Get(a => a.UserID == id).First();
                //    names = pa.LastName + " " + pa.FirstName + " " + pa.MiddleName;
                //    return names;
                //}
                //else
                //{
                Person thePerson = thePersons[0];
                names = thePerson.LastName + " " + thePerson.FirstName + " " + thePerson.MiddleName;
                return names;
                // }
            }
            catch (Exception e)
            {
                return names;
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult CreateRole(string id)
        {
            if (_rolesService.Enabled)
                _rolesService.Create(id);
            MyRole role = new MyRole();
            role.RoleName = id;
            role.Student = "";
            role.Subject = "";
            role.ClassSubject = "";
            role.Level = "";
            role.Exam = "";
            role.Staff = "";
            role.Store = "";
            role.StudentFees = "";
            role.OnlineExam = "";
            role.SecondarySchoolStudent = "";
            work.MyRoleRepository.Insert(role);
            work.Save();
            return RedirectToAction("Index");
        }

        public ViewResult Delete(string id)
        {
            //  Membership.
            ViewBag.ID = id;
            return View("Delete");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult DeleteRole(string id)
        {
            List<MyRole> theRole = work.MyRoleRepository.Get(a => a.RoleName.Equals(id)).ToList();
            string Roler = theRole[0].RoleName;
            List<string> usersInRole = _rolesService.FindUserNamesByRole(Roler).ToList();
            if (usersInRole.Count() > 0)
            {
                foreach (string u in usersInRole)
                {
                    // var user = _userService.Get(id);
                    var user = _userService.Get(u);

                    _rolesService.RemoveFromRole(user, Roler);
                    _rolesService.AddToRole(user, "Default");

                }
            }
            _rolesService.Delete(id);

            work.MyRoleRepository.Delete(theRole[0]);
            work.Save();
            return RedirectToAction("Index");
        }

        public ViewResult Role(string id)
        {
            return View(new RoleViewModel
                            {
                                Role = id,
                                Users = _rolesService.FindUserNamesByRole(id)
                                                     .ToDictionary(
                                                        k => k,
                                                        v => _userService.Get(v)
                                                     )
                            });
        }

        public ViewResult Details(Guid id)
        {
            var user = _userService.Get(id);
            var userRoles = _rolesService.Enabled
                ? _rolesService.FindByUser(user)
                : Enumerable.Empty<string>();
            return View(new DetailsViewModel
                            {
                                CanResetPassword = _membershipSettings.Password.ResetOrRetrieval.CanReset,
                                RequirePasswordQuestionAnswerToResetPassword = _membershipSettings.Password.ResetOrRetrieval.RequiresQuestionAndAnswer,
                                DisplayName = user.UserName,
                                User = user,
                                Roles = _rolesService.Enabled
                                    ? _rolesService.FindAll().ToDictionary(role => role, role => userRoles.Contains(role))
                                    : new Dictionary<string, bool>(0),
                                IsRolesEnabled = _rolesService.Enabled,
                                Status = user.IsOnline
                                            ? DetailsViewModel.StatusEnum.Online
                                            : !user.IsApproved
                                                ? DetailsViewModel.StatusEnum.Unapproved
                                                : user.IsLockedOut
                                                    ? DetailsViewModel.StatusEnum.LockedOut
                                                    : DetailsViewModel.StatusEnum.Offline
                            });
        }

        public ViewResult Password(Guid id)
        {
            var user = _userService.Get(id);
            var userRoles = _rolesService.Enabled
                ? _rolesService.FindByUser(user)
                : Enumerable.Empty<string>();
            return View(new DetailsViewModel
            {
                CanResetPassword = _membershipSettings.Password.ResetOrRetrieval.CanReset,
                RequirePasswordQuestionAnswerToResetPassword = _membershipSettings.Password.ResetOrRetrieval.RequiresQuestionAndAnswer,
                DisplayName = user.UserName,
                User = user,
                Roles = _rolesService.Enabled
                    ? _rolesService.FindAll().ToDictionary(role => role, role => userRoles.Contains(role))
                    : new Dictionary<string, bool>(0),
                IsRolesEnabled = _rolesService.Enabled,
                Status = user.IsOnline
                            ? DetailsViewModel.StatusEnum.Online
                            : !user.IsApproved
                                ? DetailsViewModel.StatusEnum.Unapproved
                                : user.IsLockedOut
                                    ? DetailsViewModel.StatusEnum.LockedOut
                                    : DetailsViewModel.StatusEnum.Offline
            });
        }

        public ViewResult UsersRoles(Guid id)
        {
            var user = _userService.Get(id);
            var userRoles = _rolesService.FindByUser(user);
            return View(new DetailsViewModel
            {
                CanResetPassword = _membershipSettings.Password.ResetOrRetrieval.CanReset,
                RequirePasswordQuestionAnswerToResetPassword = _membershipSettings.Password.ResetOrRetrieval.RequiresQuestionAndAnswer,
                DisplayName = user.UserName,
                User = user,
                Roles = _rolesService.FindAll().ToDictionary(role => role, role => userRoles.Contains(role)),
                IsRolesEnabled = true,
                Status = user.IsOnline
                            ? DetailsViewModel.StatusEnum.Online
                            : !user.IsApproved
                                ? DetailsViewModel.StatusEnum.Unapproved
                                : user.IsLockedOut
                                    ? DetailsViewModel.StatusEnum.LockedOut
                                    : DetailsViewModel.StatusEnum.Offline
            });
        }

        public ViewResult CreateUser()
        {
            var model = new CreateUserViewModel
                            {
                                InitialRoles = _rolesService.FindAll().ToDictionary(k => k, v => false)
                            };
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateUser(CreateUserViewModel createUserViewModel)
        {
            if (!ModelState.IsValid)
                return View(createUserViewModel);

            try
            {
                if (createUserViewModel.Password != createUserViewModel.ConfirmPassword)
                    throw new MembershipCreateUserException("Passwords do not match.");

                var user = _userService.Create(
                    createUserViewModel.Username,
                    createUserViewModel.Password,
                    createUserViewModel.Email,
                    createUserViewModel.PasswordQuestion,
                    createUserViewModel.PasswordAnswer,
                    true);
                //  _rolesService.

                if (createUserViewModel.InitialRoles != null)
                {
                    var rolesToAddUserTo = createUserViewModel.InitialRoles.Where(x => x.Value).Select(x => x.Key);
                    foreach (var role in rolesToAddUserTo)
                        _rolesService.AddToRole(user, role);
                }
                SilverDaleSchools.Models.Tweaker.AdjustTimer(user.UserName);
                return RedirectToAction("Details", new { id = user.ProviderUserKey });
            }
            catch (MembershipCreateUserException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(createUserViewModel);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult Details(Guid id, string email, string comments)
        {
            var user = _userService.Get(id);
            user.Email = email;
            user.Comment = comments;
            _userService.Update(user);
            return RedirectToAction("Details", new { id });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult DeleteUser(Guid id)
        {
            var user = _userService.Get(id);

            if (_rolesService.Enabled)
            {

                string theUserString = user.UserName;
                 int theUserName = Convert.ToInt32(user.UserName);

                _rolesService.RemoveFromAllRoles(user);
                _userService.Delete(user);



                try
                {
                    List<Person> theUser = work.PersonRepository.Get(a => a.UserID == theUserName).ToList();

                    if (theUser.Count() > 0)
                    {

                        work.PersonRepository.Delete(theUser[0]);
                        work.Save();
                    }

                    else
                    {
                        List<Person> theStaff = work.PersonRepository.Get(a => a.UserID == theUserName).ToList();
                        work.PersonRepository.Delete(theStaff[0]);
                        work.Save();
                    }
                }

                catch (Exception e)
                {
                }


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

            }
            return RedirectToAction("Index");
        }

        public void LogOutUser(string id)
        {

            var user = _userService.Get(id);
            //  User  theUser = Membership.GetUser(id);
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["stDatabase"].ConnectionString;
            SqlConnection conn = new System.Data.SqlClient.SqlConnection(con);
            SqlCommand updateCmd = new SqlCommand("UPDATE Users " +
      "SET LastActivityDate = @LastActivityDate " +
      "WHERE UserName = @UserName", conn);
            // TimeZoneInfo.ConvertTimeToUtc(DateTime.Now)  DateTime.UtcNow.AddMinutes(-10);
            updateCmd.Parameters.Add("@LastActivityDate", SqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).AddMinutes(-10);
            updateCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 255).Value = user.UserName;
            //updateCmd.Parameters.Add("@ApplicationName", SqlDbType.VarChar, 255).Value = m_ApplicationName;
            conn.Open();
            updateCmd.ExecuteNonQuery();
            conn.Close();
            //  FormsAuthentication.SignOut(
            // return Redirect(returnUrl);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult ChangeApproval(Guid id, bool isApproved)
        {
            var user = _userService.Get(id);
            user.IsApproved = isApproved;
            SilverDaleSchools.Models.Tweaker.AdjustTimer(user.UserName);
            _userService.Update(user);
            //  Tweaker.AdjustTimer(model.UserID.ToString());
            return RedirectToAction("Details", new { id });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult ChangeLocked(Guid id)
        {
            var user = _userService.Get(id);
            user.UnlockUser();
            SilverDaleSchools.Models.Tweaker.AdjustTimer(user.UserName);
            _userService.Update(user);
            return RedirectToAction("Details", new { id });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult Unlock(Guid id)
        {
            _passwordService.Unlock(_userService.Get(id));
            var user = _userService.Get(id);
            SilverDaleSchools.Models.Tweaker.AdjustTimer(user.UserName);
            return RedirectToAction("Details", new { id });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult ResetPassword(Guid id)
        {
            var user = _userService.Get(id);
            var newPassword = _passwordService.ResetPassword(user);

            var body = ResetPasswordBody + newPassword;
            var msg = new MailMessage();
            msg.To.Add(user.Email);
            msg.Subject = ResetPasswordSubject;
            msg.Body = body;
            _smtpClient.Send(msg);
            //  var user = _userService.Get(id);
            SilverDaleSchools.Models.Tweaker.AdjustTimer(user.UserName);
            return RedirectToAction("Password", new { id });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult ResetPasswordWithAnswer(Guid id, string answer)
        {
            var user = _userService.Get(id);
            var newPassword = _passwordService.ResetPassword(user, answer);

            var body = ResetPasswordBody + newPassword;
            var msg = new MailMessage();
            msg.To.Add(user.Email);
            msg.Subject = ResetPasswordSubject;
            msg.Body = body;
            _smtpClient.Send(msg);

            return RedirectToAction("Password", new { id });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult SetPassword(Guid id, string password)
        {
            var user = _userService.Get(id);
            _passwordService.ChangePassword(user, password);

            //var body = ResetPasswordBody + password;
            //var msg = new MailMessage();
            //msg.To.Add(user.Email);
            //msg.Subject = ResetPasswordSubject;
            //msg.Body = body;
            //_smtpClient.Send(msg);

            // var user = _userService.Get(id);
            SilverDaleSchools.Models.Tweaker.AdjustTimer(user.UserName);

            return RedirectToAction("Password", new { id });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult AddToRole(Guid id, string role)
        {
            var user = _userService.Get(id);
            string theUSerName = user.UserName;
             Int32 theUserNameInt = Convert.ToInt32(theUSerName);

             Person model = work.PersonRepository.Get(a => a.UserID == theUserNameInt).First();

            string[] RoleList = Roles.GetAllRoles();
            //  Roles.RemoveUserFromRoles(model.UserID.ToString(), RoleList);
            foreach (var role1 in RoleList)
            {
                if (Roles.IsUserInRole(model.UserID.ToString(), role1))
                {
                    Roles.RemoveUserFromRole(model.UserID.ToString(), role1);
                }
            }
            Roles.AddUserToRole(model.UserID.ToString(), role);
            model.Role = role;
            work.PersonRepository.Update(model);
            work.Save();

            //  _rolesService.RemoveFromAllRoles(user);
            //   _rolesService.AddToRole(_userService.Get(id), role);
            // user = _userService.Get(id);
            SilverDaleSchools.Models.Tweaker.AdjustTimer(user.UserName);
            return RedirectToAction("UsersRoles", new { id });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult RemoveFromRole(Guid id, string role)
        {
            _rolesService.RemoveFromRole(_userService.Get(id), role);
            _rolesService.AddToRole(_userService.Get(id), "Default");
            var user = _userService.Get(id);
            SilverDaleSchools.Models.Tweaker.AdjustTimer(user.UserName);
            return RedirectToAction("UsersRoles", new { id });
        }
    }
}