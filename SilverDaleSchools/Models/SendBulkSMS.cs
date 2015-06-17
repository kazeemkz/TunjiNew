using JobHustler.DAL;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SchoolManagement.Models
{
    public static class SendBulkSMS
    {
        public static dynamic SendNow(BulkSMS model)
        {

            try
            {

                if (!(string.IsNullOrEmpty(model.Numbers)))
                {
                    string[] numbers = model.Numbers.Split(';');

                    if (numbers.Count() > 0)
                    {
                        foreach (string num in numbers)
                        {
                            Send(num, model);
                            //ttp://login.betasms.com/customer/api/?username=exp_jb@yahoo.com&password=light&message=test&sender=demo&mobiles=2347034455709

                        }
                    }
                }

                if (!(string.IsNullOrEmpty(model.ClassArm)))
                {
                    string theArm = model.ClassArm;
                    UnitOfWork work = new UnitOfWork();

                    List<PrimarySchoolStudent> theStudent = work.PrimarySchoolStudentRepository.Get(a => a.LevelType == theArm && a.HomeTelephone != null).ToList();

                    string[] numbers = model.ClassArm.Split(';');

                    if (theStudent.Count() > 0)
                    {
                        foreach (PrimarySchoolStudent stu in theStudent)
                        {
                            string num = stu.HomeTelephone;
                            Send(num, model);
                           

                        }
                    }
                }

                if (!(string.IsNullOrEmpty(model.Class)))
                {
                    List<PrimarySchoolStudent> theStudent = new List<PrimarySchoolStudent>();
                    string Class = model.Class;
                    UnitOfWork work = new UnitOfWork();
                    if(Class =="All Students")
                    {
                        theStudent = work.PrimarySchoolStudentRepository.Get(a => a.HomeTelephone != null).ToList();
                        if (theStudent.Count() > 0)
                        {
                            foreach (PrimarySchoolStudent stu in theStudent)
                            {
                                string num = stu.HomeTelephone;
                                Send(num, model);


                            }
                        }
                    }
                    if (Class == "All Staff")
                    {
                        List<PrimarySchoolStaff> theStaff = work.PrimarySchoolStaffRepository.Get(a => a.Telephone != null).ToList();
                        if (theStaff.Count() > 0)
                        {
                            foreach (PrimarySchoolStaff staff in theStaff)
                            {
                                string num = staff.Telephone;
                                Send(num, model);


                            }
                        }
                    }
                    else
                    {

                        theStudent = work.PrimarySchoolStudentRepository.Get(a => a.PresentLevel == Class && a.HomeTelephone != null).ToList();
                        if (theStudent.Count() > 0)
                        {
                            foreach (PrimarySchoolStudent stu in theStudent)
                            {
                                string num = stu.HomeTelephone;
                                Send(num, model);


                            }
                        }
                    }
                   // string[] numbers = model.ClassArm.Split(';');

                   
                }

            }
            catch (Exception e)
            {
                
                return 1;
            }
            return 3;
        }

        public static void Send(string num, BulkSMS model)
        {
            string theNumber = num;

            if ((num.StartsWith("234")))
            {
                // theNumber = num.Substring(3);
            }
            if ((num.StartsWith("+234")))
            {
                theNumber = num.Substring(1);
            }
            if ((num.StartsWith("0")))
            {

                theNumber = num.Substring(1);
                theNumber = "234" + theNumber;
            }


            string senderusername = "exp_jb@yahoo.com";
            string senderpassword = "lightoo1";
            string senderid = "School";
            string body = model.Body;
            string sURL;
            StreamReader objReader;

            sURL = "http://login.betasms.com/customer/api/?username=" + senderusername + "&password=" + senderpassword + "&message=" + body + "&sender=" + senderid + "&mobiles=" + theNumber;// +"&type=1&message=" + txtMessage.Text;
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            try
            {
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                objReader = new StreamReader(objStream);
                objReader.Close();
            }
            catch (Exception ex)
            {
               // continue;
               // ex.ToString();
            }
            //h
        }
    }
}