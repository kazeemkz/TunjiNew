//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Security;
//using SilverDaleSchools.DAL;
//using SilverDaleSchools.Model;

//namespace SilverDaleSchools.Models
//{
//    public class DynamicAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
//    {
//        //UnitOfWork work = new UnitOfWork();

//        protected override bool AuthorizeCore(HttpContextBase httpContext)
//        {


//            Membership.GetUser(true);
//            UnitOfWork work = new UnitOfWork();
//            Roles = null;
//            string UserName = "";
//            int UserNameInt;
//            List<Person> thePerson;
//            List<Student> theStudent;
//            List<Staff> theStaff;
//           // List<Parent> theParent;
//            Person theRealPerson = new Person();
//           // Parent theRealParent = new Parent();
//            string theControllerName = "";
//            string theActionName = "";
//            dynamic controllerName ="";
//            dynamic actionName ="";
//            List<MyRole> theRole = new List<MyRole>();
//            try
//            {

//                controllerName = httpContext.Request.RequestContext.RouteData.Values["controller"];
//                theControllerName = Convert.ToString(controllerName);
//                string originalController = Convert.ToString(controllerName);
               
//                //
//                UserName = httpContext.User.Identity.Name;
//               // UserNameInt = Convert.ToInt32(UserName);

//                try
//                {
//                   theStudent =work.StudentRepository.Get(a => a.UserID == UserName).ToList();
//                   theStaff = work.StaffRepository.Get(a => a.UserID == UserName).ToList();

//                   if (theStudent.Count > 0)
//                   {
//                       theRealPerson = theStudent[0];
//                   }


//                   if (theStaff.Count > 0)
//                   {
//                       theRealPerson = theStaff[0];
//                   }

//                   // thePerson = work.PersonRepository.Get(a => a.UserID == UserName).ToList();
//                   // theRealPerson = thePerson[0];
//                    theControllerName = Convert.ToString(controllerName);
//                    actionName = httpContext.Request.RequestContext.RouteData.Values["action"];
//                    theActionName = Convert.ToString(actionName);
//                    theRole = work.MyRoleRepository.Get(a => a.RoleName.Equals(theRealPerson.Role)).ToList();
//                }
//                catch
//                {
//                    //theParent = work.ParentRepository.Get(a => a.UserID == UserNameInt).ToList();
//                    //theRealParent = theParent[0];
//                    //theControllerName = Convert.ToString(controllerName);
//                    //actionName = httpContext.Request.RequestContext.RouteData.Values["action"];
//                    //theActionName = Convert.ToString(actionName);
//                    //theRole = work.MyRoleRepository.Get(a => a.RoleName.Equals(theRealParent.Role)).ToList();
//                }

//                if (theControllerName.Contains("Upload"))
//                {
//                    theControllerName = "UploadLessonNote";
//                }

//                if (theControllerName.Contains("ReadContent"))
//                {
//                    theControllerName = "UploadLessonNote";
//                }

//                if (theControllerName.Contains("Chapter"))
//                {
//                    theControllerName = "UploadLessonNote";
//                }
//                // Get this string (roles) from a database or somewhere dynamic using the controllerName and actionName
//                //Roles = "Role1,Role2,Role3"; // i.e.  GetRolesFromDatabase(controllerName, actionName);
//               // List<MyRole> theRole = work.MyRoleRepository.Get(a => a.RoleName.Equals(theRealPerson.Role)).ToList();


//                switch (theControllerName)
//                {
//                      //  if(theControllerName.Contains("Upload"))

//                    case "UploadLessonNote":
//                        string[] activities50 = {"-"};
//                        if (!(String.IsNullOrEmpty( theRole[0].Material)))
//                        {
//                          //  activities50.em
//                            activities50 = theRole[0].Material.Split('-');
//                        }
                       
//                        List<string> activityList50 = new List<string>();
//                        foreach (var activity in activities50)
//                        {
//                            if (activity.Equals("List"))//|| activity.Equals("StudentView"))
//                            {
//                                activityList50.Add("Index");
//                            }
//                            else
//                            {
//                                activityList50.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList50)
//                        {
//                            //DeleteChapter
//                            if (activity == "Delete")
//                            {
//                                if (actionName == "DeleteChapter")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }

                              
//                            }
//                            if (activity == "Edit" || activity == "Index")
//                            {
//                                if (actionName == "Edit")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }

//                                if (actionName == "Index")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                            else
//                            {
//                                if (activity.Equals(actionName))
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                        }

//                        //if (!(string.IsNullOrEmpty( originalController)))
//                        //{

//                        //}
//                        break;

//                    case "Question":

//                        string[] activities39 = theRole[0].OnlineExam.Split('-');
//                        List<string> activityList39 = new List<string>();
//                        foreach (var activity in activities39)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList39.Add("Index");
//                            }
//                            else
//                            {
//                                activityList39.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList39)
//                        {
//                            if (activity == "Index")
//                            {
//                                //if (actionName == "LoadExamCodes")
//                                //{
//                                //    Roles = theRole[0].RoleName;
//                                //    return base.AuthorizeCore(httpContext);
//                                //}
//                                if (actionName == "Index")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                            else
//                            {
//                                if (activity.Equals(actionName))
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                        }

//                        break;

//                    case "Order":

//                        string[] activities38 = theRole[0].StudentStoreItem.Split('-');
//                        List<string> activityList38 = new List<string>();
//                        foreach (var activity in activities38)
//                        {
//                            if (activity.Equals("List"))//|| activity.Equals("StudentView"))
//                            {
//                                activityList38.Add("Index");
//                            }
//                            else
//                            {
//                                activityList38.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList38)
//                        {
//                            if (activity == "Edit" || activity == "Index")
//                            {
//                                if (actionName == "Edit")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }

//                                if (actionName == "Index")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                            else
//                            {
//                                if (activity.Equals(actionName))
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                        }

//                        break;
//                    case "StudentStoreItem":

//                        string[] activities37 = theRole[0].StudentStoreItem.Split('-');
//                        List<string> activityList37 = new List<string>();
//                        foreach (var activity in activities37)
//                        {
//                            if (activity.Equals("List"))//|| activity.Equals("StudentView"))
//                            {
//                                activityList37.Add("Index");
//                            }
//                            else
//                            {
//                                activityList37.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList37)
//                        {
//                            if (activity == "Edit" || activity == "Index")
//                            {
//                                if (actionName == "Edit")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
                               
//                                if (actionName == "Index")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                            else
//                            {
//                                if (activity.Equals(actionName))
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                        }

//                        break;
//                    case "SchoolFeePayment":

//                        string[] activities36 = theRole[0].SchoolFeePayment.Split('-');
//                        List<string> activityList36 = new List<string>();
//                        foreach (var activity in activities36)
//                        {
//                            if (activity.Equals("List"))//|| activity.Equals("StudentView"))
//                            {
//                                activityList36.Add("Index");
//                            }
//                            else
//                            {
//                                activityList36.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList36)
//                        {
//                            if (activity == "Index")
//                            {
//                                if (actionName == "ViewFeeForStudent")//
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                                if (actionName == "ViewYourFees")//ViewYourFees
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                                if (actionName == "Index")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                            else
//                            {
//                                if (activity.Equals(actionName))
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                        }

//                        break;
//                    case "OrderItem":

//                        string[] activities35 = theRole[0].OrderItem.Split('-');
//                        List<string> activityList35 = new List<string>();
//                        foreach (var activity in activities35)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList35.Add("Index");
//                            }
//                            else
//                            {
//                                activityList35.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList35)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;

//                    case "Result":

//                        string[] activities40 = theRole[0].Result.Split('-');
//                        List<string> activityList40 = new List<string>();
//                        foreach (var activity in activities40)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList40.Add("Index");
//                            }
//                            else
//                            {
//                                activityList40.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList40)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;
               
//                    case "AttendanceStaff":

//                        string[] activities34 = theRole[0].Attendance.Split('-');
//                        List<string> activityList34 = new List<string>();
//                        foreach (var activity in activities34)
//                        {
//                            if (activity.Equals("List")) //|| activity.Equals("StaffView"))
//                            {
//                                activityList34.Add("Index");
//                              //  activityList34.Add("Index");
//                            }
//                            //if (activity.Equals("StaffView"))
//                            //{
//                            //    activityList34.Add("Index");
//                            //    //  activityList34.Add("Index");
//                            //}
//                            else
//                            {
//                                activityList34.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList34)
//                        {
//                            if (activity == "Index")
//                            {
//                                if (actionName == "StaffView")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                                if (actionName == "Index")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                            else
//                            {
//                                if (activity.Equals(actionName))
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                        }

//                        break;
//                    case "Attendance":

//                        string[] activities33 = theRole[0].Attendance.Split('-');
//                        List<string> activityList33 = new List<string>();
//                        foreach (var activity in activities33)
//                        {
//                            if (activity.Equals("List") )//|| activity.Equals("StudentView"))
//                            {
//                                activityList33.Add("Index");
//                            }
//                            else
//                            {
//                                activityList33.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList33)
//                        {
//                            if (activity == "Index")
//                            {
//                                if (actionName == "StudentView")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                                if (actionName == "Index")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                            else
//                            {
//                                if (activity.Equals(actionName))
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                        }

//                        break;
//                    case "Post":

//                        string[] activities32 = theRole[0].Post.Split('-');
//                        List<string> activityList32 = new List<string>();
//                        foreach (var activity in activities32)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList32.Add("Index");
//                            }
//                            else
//                            {
//                                activityList32.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList32)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;
//                    case "BulkSMS":

//                        string[] activities31 = theRole[0].BulkSMS.Split('-');
//                        List<string> activityList31 = new List<string>();
//                        foreach (var activity in activities31)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList31.Add("Index");
//                            }
//                            else
//                            {
//                                activityList31.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList31)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;

//                    case "Parent":

//                        string[] activities30 = theRole[0].TimeTable.Split('-');
//                        List<string> activityList30 = new List<string>();
//                        foreach (var activity in activities30)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList30.Add("Index");
//                            }
//                            else
//                            {
//                                activityList30.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList30)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;

//                    case "TimeTable":

//                        string[] activities23 = theRole[0].TimeTable.Split('-');
//                        List<string> activityList23 = new List<string>();
//                        foreach (var activity in activities23)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList23.Add("Index");
//                            }
//                            else
//                            {
//                                activityList23.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList23)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;


//                    case "NewsBoard":

//                        string[] activities24 = theRole[0].NewsBoard.Split('-');
//                        List<string> activityList24 = new List<string>();
//                        foreach (var activity in activities24)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList24.Add("Index");
//                            }
//                            else
//                            {
//                                activityList24.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList24)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;





//                    case "OnlineExam":

//                        string[] activities0 = theRole[0].OnlineExam.Split('-');
//                        List<string> activityList0 = new List<string>();
//                        foreach (var activity in activities0)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList0.Add("Index");
//                            }
//                            else
//                            {
//                                activityList0.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList0)
//                        {
//                            if (activity == "Index")
//                            {
//                                if (actionName == "LoadExamCodes")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                                if (actionName == "Index")
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                            else
//                            {
//                                if (activity.Equals(actionName))
//                                {
//                                    Roles = theRole[0].RoleName;
//                                    return base.AuthorizeCore(httpContext);
//                                }
//                            }
//                        }

//                        break;



//                    case "PrimarySchoolStudent":

//                        string[] activities = theRole[0].Student.Split('-');
//                        List<string> activityList = new List<string>();
//                        //student fees
//                        if (actionName == "Index3")
//                        {
//                            foreach (var role in theRole)
//                            {
//                                if (role.StudentFees != null)
//                                {
//                                    string[] val = role.StudentFees.Split('-');
//                                    foreach (var v in val)
//                                    {
//                                        if (v == "Edit")
//                                        {
//                                            Roles = theRole[0].RoleName;
//                                            return base.AuthorizeCore(httpContext);
//                                            //break;
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                        //store list
//                        if (actionName == "Index2")
//                        {
//                            foreach (var role in theRole)
//                            {
//                                if (role.StudentFees != null)
//                                {
//                                    string[] val = role.Store.Split('-');
//                                    foreach (var v in val)
//                                    {
//                                        if (v == "Edit")
//                                        {
//                                            Roles = theRole[0].RoleName;
//                                            return base.AuthorizeCore(httpContext);
//                                            //break;
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                        foreach (var activity in activities)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList.Add("Index");
//                            }
//                            else
//                            {
//                                activityList.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;


//                    case "Exam":

//                        string[] activities1 = theRole[0].Exam.Split('-');
//                        List<string> activityList1 = new List<string>();
//                        foreach (var activity in activities1)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList1.Add("Index");
//                                activityList1.Add("Create");
//                            }
//                            //if (activity.Equals("Create"))
//                            //{
//                            //    activityList1.Add("Index");
//                            //}
//                            else
//                            {
//                                activityList1.Add(activity);
//                            }

//                        }
//                        //  roles
//                        // activityList.Add(activities);
//                        foreach (var activity in activityList1)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;


//                    case "Level":

//                        string[] activities2 = theRole[0].Level.Split('-');
//                        List<string> activityList2 = new List<string>();
//                        foreach (var activity in activities2)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList2.Add("Index");
//                            }
//                            else
//                            {
//                                activityList2.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList2)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;


//                    case "PrimarySchoolStaff":

//                        string[] activities3 = theRole[0].Staff.Split('-');
//                        List<string> activityList3 = new List<string>();
//                        foreach (var activity in activities3)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList3.Add("Index");
//                            }
//                            else
//                            {
//                                activityList3.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList3)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;


//                    case "Store":

//                        string[] activities4 = theRole[0].Store.Split('-');
//                        List<string> activityList4 = new List<string>();
//                        foreach (var activity in activities4)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList4.Add("Index");
//                            }
//                            else
//                            {
//                                activityList4.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList4)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;

//                    case "StudentFees":

//                        string[] activities5 = theRole[0].StudentFees.Split('-');
//                        List<string> activityList5 = new List<string>();
//                        foreach (var activity in activities5)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList5.Add("Index");
//                            }
//                            else
//                            {
//                                activityList5.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList5)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;




//                    case "Subject":

//                        string[] activities6 = theRole[0].Subject.Split('-');
//                        List<string> activityList6 = new List<string>();
//                        foreach (var activity in activities6)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList6.Add("Index");
//                            }
//                            else
//                            {
//                                activityList6.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList6)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;



//                    case "SubjectRegistration":

//                        string[] activities7 = theRole[0].ClassSubject.Split('-');
//                        List<string> activityList7 = new List<string>();
//                        foreach (var activity in activities7)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList7.Add("Index");
//                            }
//                            else
//                            {
//                                activityList7.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList7)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;


//                    case "SecondarySchoolStudent":

//                        string[] activities8 = theRole[0].SecondarySchoolStudent.Split('-');
//                        List<string> activityList8 = new List<string>();
//                        foreach (var activity in activities8)
//                        {
//                            if (activity.Equals("List"))
//                            {
//                                activityList8.Add("Index");
//                            }
//                            else
//                            {
//                                activityList8.Add(activity);
//                            }

//                        }

//                        // activityList.Add(activities);
//                        foreach (var activity in activityList8)
//                        {
//                            if (activity.Equals(actionName))
//                            {
//                                Roles = theRole[0].RoleName;
//                                return base.AuthorizeCore(httpContext);
//                            }
//                        }

//                        break;
//                }

//                //work.MyRoleRepository.Get()


//                Roles = "SuperAdmin"; // i.e.  GetRolesFromDatabase(controllerName, actionName);

//                return base.AuthorizeCore(httpContext);
//            }
//            catch (Exception e)
//            {

//                Roles = "SuperAdmin"; // i.e.  GetRolesFromDatabase(controllerName, actionName);

//                return base.AuthorizeCore(httpContext);
//            }
//        }
//    }
//}