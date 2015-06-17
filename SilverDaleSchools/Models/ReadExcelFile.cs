//using Excel;
////using LinqToExcel;
//using Remotion.Data.Linq;
//using SilverDaleSchools.DAL;
//using SilverDaleSchools.Model;
//using SilverDalesSchools.Models;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.OleDb;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Security;

//namespace SilverDaleSchools.Models
//{
//    public class ReadExcelFile
//    {

//        public async Task Read(string fileExtension, HttpPostedFileBase theFile)
//        {

//            try
//            {
//                UnitOfWork work = new UnitOfWork();

//                List<Student> theStudentList = new List<Student>();




//                IExcelDataReader excelReader = null;
//                if ((fileExtension.EndsWith(".xlsx")))
//                {
//                    //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
//                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(theFile.InputStream);
//                }

//                if ((fileExtension.EndsWith(".xls")))
//                {

//                    //1. Reading from a binary Excel file ('97-2003 format; *.xls)
//                    excelReader = ExcelReaderFactory.CreateBinaryReader(theFile.InputStream);
//                }
//                // ExcelDataReader reader = new ExcelDataReader(ExcelFileUpload.PostedFile.InputStream);

//                /// FileStream stream = File.Open(Request.Files[0], FileMode.Open, FileAccess.Read);


//                //...

//                //...
//                //3. DataSet - The result of each spreadsheet will be created in the result.Tables
//                DataSet result = excelReader.AsDataSet();
//                //  ...
//                //4. DataSet - Create column names from first row
//                excelReader.IsFirstRowAsColumnNames = true;
//                DataSet result2 = excelReader.AsDataSet();

//                //5. Data Reader methods
//                int counter = 0;
//                while (excelReader.Read())
//                {

//                    if (counter > 0)
//                    {

//                        Result theNewResult = new Result();

//                        try
//                        {
//                            if (!string.IsNullOrEmpty(excelReader.GetString(0)) && !string.IsNullOrEmpty(excelReader.GetString(1)) && !string.IsNullOrEmpty(excelReader.GetString(2)))
//                            {

//                                theStudentList.Add(new Student
//                                {
//                                    //  UserID = theString,
//                                    UserID = (excelReader.GetString(0)),
//                                    LastName = excelReader.GetString(1),
//                                    FirstName = excelReader.GetString(2),
//                                    Middle = excelReader.GetString(3),
//                                    Sex = excelReader.GetString(4),

//                                    PhoneNumber = excelReader.GetString(5),
//                                    EmailAddress = excelReader.GetString(6),

//                                    Address = excelReader.GetString(7),
//                                    ParentName = excelReader.GetString(8),
//                                    ParentAddress = excelReader.GetString(9),
//                                    ParentPhoneNumber = excelReader.GetString(10),
//                                    LGAName = excelReader.GetString(11),
//                                    StateName = excelReader.GetString(12),
//                                    CountryName = excelReader.GetString(13),
//                                    LocalLanguageName = excelReader.GetString(14),
//                                    Role = "Student",


//                                });
//                            }


//                        }
//                        catch (Exception e)
//                        {

//                        }




//                    }





//                    counter = counter + 1;
//                }

//                foreach (Student s in theStudentList)
//                {

//                    try
//                    {
//                        List<Student> theStudent = work.StudentRepository.Get().Where(a => a.UserID == s.UserID).ToList();//(s.UserID).ToList();
//                        var theValue = Membership.GetUser(s.UserID.ToString());
//                        if (Membership.GetUser(s.UserID.ToString()) == null && theStudent.Count() == 0 && !(string.IsNullOrEmpty(s.UserID)))
//                        {
                            
//                            work.StudentRepository.Insert(s);
//                            if (string.IsNullOrEmpty(s.EmailAddress))
//                            {
//                                s.EmailAddress = "student@yahoo.com";
//                            }
//                            Membership.CreateUser(s.UserID.ToString(), PaddPassword.Padd(s.LastName), s.EmailAddress);
//                            Roles.AddUserToRole(s.UserID.ToString(), s.Role);
//                            Tweaker.AdjustTimer(s.UserID.ToString());
//                            //  work.StudentRepository.Insert(s);
//                              work.Save();
//                        }
//                    }

//                    catch(Exception e)
//                    {

//                    }
                   
//                }
//              //  work.Save();

//            }

//            catch (Exception e)
//            {


//            }


//        }
//    }
//}