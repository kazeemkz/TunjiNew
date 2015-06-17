using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SilverDaleSchools.DAL;
using SilverDaleSchools.Model;
using SilverDaleSchools.Models;
using System.Web.Security;
//using SilverDaleSchools.DAL;

namespace SilverDaleSchools.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class MyRoleController : Controller
    {
        //
        // GET: /MyRole/

        UnitOfWork work = new UnitOfWork();


        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /MyRole/Details/5

        public ActionResult Details(int id)
        {
            //  work.MyRoleRepository.
            return View();
        }

        //
        // GET: /MyRole/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MyRole/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MyRole/Edit/5

        public ActionResult Edit(string roleName)
        {

            List<MyRole> theRoles = work.MyRoleRepository.Get(a => a.RoleName.Equals(roleName)).ToList();

            if (theRoles.Count == 0)
            {
                string[] theaddCoddedRoles = Roles.GetAllRoles();


                foreach (var role in theaddCoddedRoles)
                {

                    MyRole theRle = new MyRole();
                    theRle.RoleName = role;
                    theRle.Attendance = "";
                    theRle.AttendanceStaff = "";
                    theRle.BulkSMS = "";
                    theRle.ClassSubject = "";
                    theRle.Exam = "";
                    theRle.Level = "";
                    theRle.Material = "";
                    theRle.NewsBoard = "";
                    theRle.OnlineExam = "";
                    theRle.OrderItem = "";
                    theRle.Parent = "";
                    theRle.Post = "";
                    theRle.Result = "";
                    theRle.SchoolFeePayment = "";
                    theRle.SecondarySchoolStudent = "";
                    theRle.Staff = "";
                    theRle.Store = "";
                    theRle.Student = "";
                    theRle.StudentFees = "";
                    theRle.StudentStoreItem = "";
                    theRle.Subject = "";
                    theRle.TimeTable = "";


                    work.MyRoleRepository.Insert(theRle);
                }

                work.Save();
                theRoles = work.MyRoleRepository.Get(a => a.RoleName.Equals(roleName)).ToList();
            }

            MyRole theRole = theRoles[0];
            // string StudentRoles = theRole.Student;
            if (string.IsNullOrEmpty(theRole.Student))
            {
                theRole.Student = "";
            }
            string[] StudentActivities = theRole.Student.Split('-');

            if (string.IsNullOrEmpty(theRole.Subject))
            {
                theRole.Subject = "";
            }
            string[] SubjectActivities = theRole.Subject.Split('-');


            if (string.IsNullOrEmpty(theRole.AttendanceStaff))
            {
                theRole.AttendanceStaff = "";
            }
            string[] AttendanceStaffActivities = theRole.AttendanceStaff.Split('-');


            if (string.IsNullOrEmpty(theRole.OrderItem))
            {
                theRole.OrderItem = "";
            }
            string[] OrderItemActivities = theRole.OrderItem.Split('-');


            if (string.IsNullOrEmpty(theRole.ClassSubject))
            {
                theRole.ClassSubject = "";
            }
            string[] ClassSubjectActivities = theRole.ClassSubject.Split('-');


            if (string.IsNullOrEmpty(theRole.Exam))
            {
                theRole.Exam = "";
            }
            string[] ExamActivities = theRole.Exam.Split('-');

            if (string.IsNullOrEmpty(theRole.Level))
            {
                theRole.Level = "";
            }
            string[] LevelActivities = theRole.Level.Split('-');

            if (string.IsNullOrEmpty(theRole.StudentFees))
            {
                theRole.StudentFees = "";
            }
            string[] StudentFeesActivities = theRole.StudentFees.Split('-');

            if (string.IsNullOrEmpty(theRole.Store))
            {
                theRole.Store = "";
            }
            string[] StoreActivities = theRole.Store.Split('-');

            if (string.IsNullOrEmpty(theRole.Staff))
            {
                theRole.Staff = "";
            }
            string[] StaffActivities = theRole.Staff.Split('-');

            if (string.IsNullOrEmpty(theRole.OnlineExam))
            {
                theRole.OnlineExam = "";
            }
            string[] OnlineExamActivities = theRole.OnlineExam.Split('-');

            if (string.IsNullOrEmpty(theRole.SecondarySchoolStudent))
            {
                theRole.SecondarySchoolStudent = "";
            }
            string[] SecondarySchoolStudent = theRole.SecondarySchoolStudent.Split('-');

            if (string.IsNullOrEmpty(theRole.TimeTable))
            {
                theRole.TimeTable = "";
            }
            string[] TimeTableActivities = theRole.TimeTable.Split('-');

            if (string.IsNullOrEmpty(theRole.NewsBoard))
            {
                theRole.NewsBoard = "";
            }
            string[] NewsBoardActivities = theRole.NewsBoard.Split('-');

            if (string.IsNullOrEmpty(theRole.Parent))
            {
                theRole.Parent = "";
            }
            string[] ParentActivities = theRole.Parent.Split('-');

            if (string.IsNullOrEmpty(theRole.BulkSMS))
            {
                theRole.BulkSMS = "";
            }
            string[] BulkSMSActivities = theRole.BulkSMS.Split('-');

            if (string.IsNullOrEmpty(theRole.Post))
            {
                theRole.Post = "";
            }
            string[] PostActivities = theRole.Post.Split('-');


            if (string.IsNullOrEmpty(theRole.Attendance))
            {
                theRole.Attendance = "";
            }
            string[] AttendanceActivities = theRole.Attendance.Split('-');

            if (string.IsNullOrEmpty(theRole.SchoolFeePayment))
            {
                theRole.SchoolFeePayment = "";
            }
            string[] SchoolFeePaymentActivities = theRole.SchoolFeePayment.Split('-');

            if (string.IsNullOrEmpty(theRole.StudentStoreItem))
            {
                theRole.StudentStoreItem = "";
            }
            string[] StudentStoreItemtActivities = theRole.StudentStoreItem.Split('-');


            if (string.IsNullOrEmpty(theRole.Result))
            {
                theRole.Result = "";
            }
            string[] ResultActivities = theRole.Result.Split('-');


            List<string> storeActivities = new List<string>();
            List<string> studentFeesActivities = new List<string>();
            List<string> levelActivities = new List<string>();
            List<string> studentActivites = new List<string>();
            List<string> subjectActivites = new List<string>();
            List<string> classSubjectActivites = new List<string>();
            List<string> examActivites = new List<string>();
            List<string> staffActivities = new List<string>();
            List<string> onlineexamActivities = new List<string>();
            List<string> timeTableActivities = new List<string>();
            List<string> newsBoardActivities = new List<string>();
            List<string> secondarySchoolStudent = new List<string>();
            List<string> parentActivities = new List<string>();
            List<string> bulkSMSActivities = new List<string>();
            List<string> postActivities = new List<string>();
            List<string> attendanceActivities = new List<string>();
            List<string> attendanceStaffActivities = new List<string>();
            List<string> orderItemActivities = new List<string>();
            List<string> schoolFeePaymentActivities = new List<string>();
            List<string> studentStoreItemtActivities = new List<string>();

            List<string> resultActivities = new List<string>();
            // List<string> newsBoardActivities = new List<string>();

            foreach (var role in SecondarySchoolStudent)
            {
                secondarySchoolStudent.Add(role);
            }

            foreach (var role in AttendanceActivities)
            {
                attendanceActivities.Add(role);
            }

            foreach (var role in OnlineExamActivities)
            {
                onlineexamActivities.Add(role);
            }

            foreach (var role in StaffActivities)
            {
                staffActivities.Add(role);
            }

            foreach (var role in StoreActivities)
            {
                storeActivities.Add(role);
            }

            foreach (var role in StudentFeesActivities)
            {
                studentFeesActivities.Add(role);
            }

            foreach (var role in LevelActivities)
            {
                levelActivities.Add(role);
            }

            foreach (var role in ExamActivities)
            {
                examActivites.Add(role);
            }

            foreach (var role in ClassSubjectActivities)
            {
                classSubjectActivites.Add(role);
            }



            foreach (var role in SubjectActivities)
            {
                subjectActivites.Add(role);
            }

            foreach (var role in StudentActivities)
            {
                studentActivites.Add(role);
            }

            foreach (var role in TimeTableActivities)
            {
                timeTableActivities.Add(role);
            }

            foreach (var role in NewsBoardActivities)
            {
                newsBoardActivities.Add(role);
            }

            foreach (var role in ParentActivities)
            {
                parentActivities.Add(role);
            }

            foreach (var role in BulkSMSActivities)
            {
                bulkSMSActivities.Add(role);
            }
            foreach (var role in PostActivities)
            {
                postActivities.Add(role);
            }

            foreach (var role in AttendanceStaffActivities)
            {
                attendanceStaffActivities.Add(role);
            }

            foreach (var role in OrderItemActivities)
            {
                orderItemActivities.Add(role);
            }

            foreach (var role in SchoolFeePaymentActivities)
            {
                schoolFeePaymentActivities.Add(role);
            }
            foreach (var role in StudentStoreItemtActivities)
            {
                studentStoreItemtActivities.Add(role);
            }

            foreach (var role in ResultActivities)
            {
                resultActivities.Add(role);
            }
            //StudentStoreItemt
            //PopulateStudentActivity(theRole, studentActivites, "Student");
            PopulateActivity(theRole, staffActivities, "Staff");
            PopulateActivity(theRole, storeActivities, "Store");
            PopulateActivity(theRole, studentFeesActivities, "StudentFees");
            PopulateActivity(theRole, levelActivities, "Level");
            PopulateActivity(theRole, examActivites, "Exam");
            PopulateActivity(theRole, classSubjectActivites, "ClassSubject");
            PopulateActivity(theRole, studentActivites, "Student");
            PopulateActivity(theRole, subjectActivites, "Subject");
            PopulateActivity(theRole, onlineexamActivities, "OnlineExam");
            PopulateActivity(theRole, secondarySchoolStudent, "SecondarySchoolStudent");
            PopulateActivity(theRole, timeTableActivities, "TimeTable");
            PopulateActivity(theRole, newsBoardActivities, "NewsBoard");
            PopulateActivity(theRole, parentActivities, "Parent");
            PopulateActivity(theRole, bulkSMSActivities, "BulkSMS");
            PopulateActivity(theRole, postActivities, "Post");
            PopulateActivity(theRole, attendanceActivities, "Attendance");
            PopulateActivity(theRole, attendanceStaffActivities, "AttendanceStaff");
            PopulateActivity(theRole, orderItemActivities, "OrderItem");
            PopulateActivity(theRole, schoolFeePaymentActivities, "SchoolFeePayment");
            PopulateActivity(theRole, studentStoreItemtActivities, "StudentStoreItem");
            PopulateActivity(theRole, resultActivities, "Result");
            return View(theRole);
            // return View();
        }

        private void PopulateActivity(MyRole instructo, List<string> roles, string type)
        {

            var allActivites = new List<string>() { "List", "Create", "Edit", "Delete", "Details" };
            var viewModel = new List<ActivityData>();
            foreach (var activity in allActivites)
            {
                viewModel.Add(new ActivityData
                {

                    // ActivityID = course.SubjectID,
                    Name = activity + " " + type,
                    Assigned = roles.Contains(activity)
                });
            }
            if (type.Equals("Staff"))
            {
                ViewBag.Staff = viewModel;
            }
            if (type.Equals("Store"))
            {
                ViewBag.Store = viewModel;
            }
            if (type.Equals("StudentFees"))
            {
                ViewBag.StudentFees = viewModel;
            }
            if (type.Equals("Level"))
            {
                ViewBag.Level = viewModel;
            }
            if (type.Equals("Exam"))
            {
                ViewBag.Exam = viewModel;
            }
            if (type.Equals("ClassSubject"))
            {
                ViewBag.ClassSubject = viewModel;
            }
            if (type.Equals("Student"))
            {
                ViewBag.Student = viewModel;
            }
            if (type.Equals("Subject"))
            {
                ViewBag.Subject = viewModel;
            }

            if (type.Equals("OnlineExam"))
            {
                ViewBag.OnlineExam = viewModel;
            }

            if (type.Equals("SecondarySchoolStudent"))
            {
                ViewBag.SecondarySchoolStudent = viewModel;
            }

            if (type.Equals("TimeTable"))
            {
                ViewBag.TimeTable = viewModel;
            }

            if (type.Equals("NewsBoard"))
            {
                ViewBag.NewsBoard = viewModel;
            }
            if (type.Equals("Parent"))
            {
                ViewBag.Parent = viewModel;
            }
            if (type.Equals("BulkSMS"))
            {
                ViewBag.BulkSMS = viewModel;
            }
            if (type.Equals("Post"))
            {
                ViewBag.Post = viewModel;
            }

            if (type.Equals("Attendance"))
            {
                ViewBag.Attendance = viewModel;
            }
            if (type.Equals("AttendanceStaff"))
            {
                ViewBag.AttendanceStaff = viewModel;
            }

            if (type.Equals("OrderItem"))
            {
                ViewBag.OrderItem = viewModel;
            }

            if (type.Equals("SchoolFeePayment"))
            {
                ViewBag.SchoolFeePayment = viewModel;
            }

            if (type.Equals("StudentStoreItem"))
            {
                ViewBag.StudentStoreItem = viewModel;
            }

            if (type.Equals("Result"))
            {
                ViewBag.Result = viewModel;
            }
            //  ViewBag.Subject = viewModel;studentStoreItemtActivities
        }

        [HttpPost]
        public ActionResult Edit(MyRole model, string[] selectedCourses)
        {
            try
            {

                StringBuilder studentActivites = new StringBuilder();
                StringBuilder subjectActivites = new StringBuilder();



                StringBuilder storeActivities = new StringBuilder();

                StringBuilder studentFeesActivities = new StringBuilder();

                StringBuilder levelActivities = new StringBuilder();

                StringBuilder classSubjectActivites = new StringBuilder();

                StringBuilder examActivites = new StringBuilder();

                StringBuilder staffActivities = new StringBuilder();

                StringBuilder onlineexamActivities = new StringBuilder();

                StringBuilder secondarySchoolStudentActivities = new StringBuilder();
                StringBuilder timeTableActivities = new StringBuilder();
                StringBuilder newsBoardActivities = new StringBuilder();
                StringBuilder parentActivities = new StringBuilder();
                StringBuilder bulkSMSActivities = new StringBuilder();
                StringBuilder postActivities = new StringBuilder();
                StringBuilder attendanceActivities = new StringBuilder();
                StringBuilder attendanceStaffActivities = new StringBuilder();
                StringBuilder orderItemActivities = new StringBuilder();
                StringBuilder schoolFeePaymentActivities = new StringBuilder();
                StringBuilder studentStoreItemtActivities = new StringBuilder();

                StringBuilder resultActivities = new StringBuilder();
                //   StringBuilder attendanceActivities = new StringBuilder();StudentStoreItem




                // strinb  studentActivites = "";
                if (selectedCourses != null)
                {


                    foreach (var activities in selectedCourses)
                    {
                        String[] fakeActivity = activities.Split(' ');
                        string theac = fakeActivity[1];

                        if (activities.EndsWith("OnlineExam") && theac == "OnlineExam")
                        {
                            String[] realActivity = activities.Split(' ');
                            onlineexamActivities.Append(realActivity[0]);
                            onlineexamActivities.Append("-");
                        }

                        if (activities.EndsWith("Student") && theac == "Student")
                        {
                            String[] realActivity = activities.Split(' ');
                            studentActivites.Append(realActivity[0]);
                            studentActivites.Append("-");
                        }
                        if (activities.EndsWith("SecondarySchoolStudent") && theac == "SecondarySchoolStudent")
                        {
                            String[] realActivity = activities.Split(' ');
                            secondarySchoolStudentActivities.Append(realActivity[0]);
                            secondarySchoolStudentActivities.Append("-");
                        }


                        if (activities.EndsWith("Subject") && theac == "Subject")
                        {

                            String[] realActivity = activities.Split(' ');
                            subjectActivites.Append(realActivity[0]);
                            // subjectActivites.Append(activities);
                            subjectActivites.Append("-");
                        }

                        if (activities.EndsWith("Staff"))
                        {

                            String[] staffActivity = activities.Split(' ');
                            staffActivities.Append(staffActivity[0]);
                            // subjectActivites.Append(activities);
                            staffActivities.Append("-");
                        }

                        if (activities.EndsWith("Table"))
                        {

                            String[] timeTableActivity = activities.Split(' ');
                            timeTableActivities.Append(timeTableActivity[0]);
                            // subjectActivites.Append(activities);
                            timeTableActivities.Append("-");
                        }

                        if (activities.EndsWith("Board"))
                        {

                            String[] newsBoardActivity = activities.Split(' ');
                            newsBoardActivities.Append(newsBoardActivity[0]);
                            // subjectActivites.Append(activities);
                            newsBoardActivities.Append("-");
                        }


                        if (activities.EndsWith("Store"))
                        {

                            String[] storeActivity = activities.Split(' ');
                            storeActivities.Append(storeActivity[0]);
                            // subjectActivites.Append(activities);
                            storeActivities.Append("-");
                        }

                        if (activities.EndsWith("OrderItem"))
                        {

                            String[] orderItemActivity = activities.Split(' ');
                            orderItemActivities.Append(orderItemActivity[0]);
                            // subjectActivites.Append(activities);
                            orderItemActivities.Append("-");
                        }

                        if (activities.EndsWith("StudentFees"))
                        {

                            String[] studentFeesActivity = activities.Split(' ');
                            studentFeesActivities.Append(studentFeesActivity[0]);
                            // subjectActivites.Append(activities);
                            studentFeesActivities.Append("-");
                        }

                        if (activities.EndsWith("Level"))
                        {

                            String[] levelActivity = activities.Split(' ');
                            levelActivities.Append(levelActivity[0]);
                            // subjectActivites.Append(activities);
                            levelActivities.Append("-");
                        }


                        if (activities.EndsWith("Exam") && theac == "Exam")
                        {

                            String[] examlActivity = activities.Split(' ');
                            examActivites.Append(examlActivity[0]);
                            // subjectActivites.Append(activities);
                            examActivites.Append("-");
                        }


                        if (activities.EndsWith("ClassSubject"))
                        {

                            String[] classSubjectlActivity = activities.Split(' ');
                            classSubjectActivites.Append(classSubjectlActivity[0]);
                            // subjectActivites.Append(activities);
                            classSubjectActivites.Append("-");
                        }

                        if (activities.EndsWith("Parent"))
                        {

                            String[] parentActivity = activities.Split(' ');
                            parentActivities.Append(parentActivity[0]);
                            // subjectActivites.Append(activities);
                            parentActivities.Append("-");
                        }

                        if (activities.EndsWith("SMS"))
                        {

                            String[] bulkSMSActivity = activities.Split(' ');
                            bulkSMSActivities.Append(bulkSMSActivity[0]);
                            // subjectActivites.Append(activities);
                            bulkSMSActivities.Append("-");
                        }
                        if (activities.EndsWith("Post"))
                        {

                            String[] postActivity = activities.Split(' ');
                            postActivities.Append(postActivity[0]);
                            // subjectActivites.Append(activities);
                            postActivities.Append("-");
                        }

                        if (activities.EndsWith("Attendance") && theac == "Attendance")
                        {

                            String[] attendanceActivity = activities.Split(' ');
                            attendanceActivities.Append(attendanceActivity[0]);
                            // subjectActivites.Append(activities);
                            attendanceActivities.Append("-");
                        }

                        if (activities.EndsWith("AttendanceStaff"))
                        {

                            String[] attendanceStaffActivity = activities.Split(' ');
                            attendanceStaffActivities.Append(attendanceStaffActivity[0]);
                            // subjectActivites.Append(activities);
                            attendanceStaffActivities.Append("-");
                        }//

                        if (activities.EndsWith("SchoolFeePayment"))
                        {

                            String[] schoolFeePaymentActivity = activities.Split(' ');
                            schoolFeePaymentActivities.Append(schoolFeePaymentActivity[0]);
                            // subjectActivites.Append(activities);
                            schoolFeePaymentActivities.Append("-");
                        }//StudentStoreItem

                        if (activities.EndsWith("StudentStoreItem"))
                        {

                            String[] studentStoreItemActivity = activities.Split(' ');
                            studentStoreItemtActivities.Append(studentStoreItemActivity[0]);
                            // subjectActivites.Append(activities);
                            studentStoreItemtActivities.Append("-");
                        }//StudentStoreItem

                        if (activities.EndsWith("Result"))
                        {

                            String[] resultActivity = activities.Split(' ');
                            resultActivities.Append(resultActivity[0]);
                            // subjectActivites.Append(activities);
                            resultActivities.Append("-");
                        }//StudentStoreItem

                    }
                }
                model.ClassSubject = Convert.ToString(classSubjectActivites);
                model.Exam = Convert.ToString(examActivites);
                model.Level = Convert.ToString(levelActivities);
                model.StudentFees = Convert.ToString(studentFeesActivities);
                model.Store = Convert.ToString(storeActivities);
                model.Staff = Convert.ToString(staffActivities);
                model.Subject = Convert.ToString(subjectActivites);
                model.Student = Convert.ToString(studentActivites);
                model.OnlineExam = Convert.ToString(onlineexamActivities);
                model.SecondarySchoolStudent = Convert.ToString(secondarySchoolStudentActivities);
                model.TimeTable = Convert.ToString(timeTableActivities);
                model.NewsBoard = Convert.ToString(newsBoardActivities);
                model.Parent = Convert.ToString(parentActivities);
                model.BulkSMS = Convert.ToString(bulkSMSActivities);
                model.Post = Convert.ToString(postActivities);
                model.Attendance = Convert.ToString(attendanceActivities);
                model.AttendanceStaff = Convert.ToString(attendanceStaffActivities);
                model.OrderItem = Convert.ToString(orderItemActivities);
                model.SchoolFeePayment = Convert.ToString(schoolFeePaymentActivities);//
                model.StudentStoreItem = Convert.ToString(studentStoreItemtActivities);//studentStoreItemtActivities

                model.Result = Convert.ToString(resultActivities);//studentStoreItemtActivities

                // TODO: Add update logic here

                work.MyRoleRepository.Update(model);
                work.Save();

                return RedirectToAction("Index", "UserAdministration");
            }
            catch
            {
                return View();
            }
        }

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /MyRole/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /MyRole/Delete/5

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
