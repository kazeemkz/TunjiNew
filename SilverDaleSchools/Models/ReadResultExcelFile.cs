using Excel;
using SilverDaleSchools.DAL;
using SilverDaleSchools.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SilverDaleSchools.Models
{
    public class ReadResultExcelFile
    {
        List<Result> theResultList = new List<Result>();
        UnitOfWork work = new UnitOfWork();
        // public void Read( string fileExtension, string theClass, string session, string term, HttpPostedFileBase theFile)
        public async Task Read(string fileExtension, string theClass, string session, string term, HttpPostedFileBase theFile)
        {
            //   await new ReadResultExcelFile().Read(physicalPath, fileExtension, model.Class, model.Session, model.Term);
            try
            {
                IExcelDataReader excelReader = null;
                if ((fileExtension.EndsWith(".xlsx")))
                {
                    //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(theFile.InputStream);
                }

                if ((fileExtension.EndsWith(".xls")))
                {

                    //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                    excelReader = ExcelReaderFactory.CreateBinaryReader(theFile.InputStream);
                }
                // ExcelDataReader reader = new ExcelDataReader(ExcelFileUpload.PostedFile.InputStream);

                /// FileStream stream = File.Open(Request.Files[0], FileMode.Open, FileAccess.Read);


                //...

                //...
                //3. DataSet - The result of each spreadsheet will be created in the result.Tables
                DataSet result = excelReader.AsDataSet();
                //  ...
                //4. DataSet - Create column names from first row
                excelReader.IsFirstRowAsColumnNames = true;
                DataSet result2 = excelReader.AsDataSet();

                //5. Data Reader methods
                int counter = 0;
                while (excelReader.Read())
                {

                    if (counter > 0)
                    {

                        Result theNewResult = new Result();

                        try
                        {

                            theNewResult.Class = theClass;
                            theNewResult.Session = session;
                            theNewResult.Term = term;
                            theNewResult.StudentNo = excelReader.GetString(0);

                            theNewResult.Surname = excelReader.GetString(1);

                            theNewResult.Firstname = excelReader.GetString(2);

                            theNewResult.Othernames = excelReader.GetString(3);

                            theNewResult.Class = theClass;//excelReader.GetString(4);

                            theNewResult.Sex = excelReader.GetString(5);

                            // string theV = dr["No# of Times School Opened"].ToString();


                            //   dr.
                            try
                            {
                                theNewResult.NoofTimesSchoolOpened = Convert.ToInt32(excelReader.GetString(6));
                            }
                            catch (Exception e)
                            {
                                theNewResult.NoofTimesSchoolOpened = 0;
                            }
                            try
                            {
                                theNewResult.NoofTimesPresent = Convert.ToInt32(excelReader.GetString(7));
                            }
                            catch (Exception e)
                            {
                                theNewResult.NoofTimesPresent = 0;
                            }

                            try
                            {
                                theNewResult.NoofTimesPunctual = Convert.ToInt32(excelReader.GetString(8));
                            }
                            catch (Exception e)
                            {
                                theNewResult.NoofTimesPunctual = 0;
                            }

                            try
                            {
                                theNewResult.NoofTimesAbsent = Convert.ToInt32(excelReader.GetString(9));
                            }
                            catch (Exception e)
                            {
                                theNewResult.NoofTimesAbsent = 0;
                            }




                            theNewResult.Fluency = excelReader.GetString(10);

                            theNewResult.Games = excelReader.GetString(11);

                            theNewResult.Sports = excelReader.GetString(12);

                            theNewResult.HandlingofTools = excelReader.GetString(13);

                            theNewResult.MusicalSkills = excelReader.GetString(14);

                            theNewResult.AttentiveandWorkIndependently = excelReader.GetString(15);

                            theNewResult.DoesHomeworkRegularly = excelReader.GetString(16);

                            theNewResult.IsNeatandOrderly = excelReader.GetString(17);


                            theNewResult.Respectauthority = excelReader.GetString(18);

                            theNewResult.TakeCareofBooksandProperty = excelReader.GetString(19);

                            theNewResult.FormMastersComments = excelReader.GetString(20);


                            theNewResult.PrincipalsComment = excelReader.GetString(21);

                            theNewResult.TotalScoreObtainable = Convert.ToDecimal(Convert.ToInt32(excelReader.GetString(22)));

                            theNewResult.TotalScoreObtained = Convert.ToDecimal(Convert.ToInt32(excelReader.GetString(23)));

                            theNewResult.Percentage = Convert.ToDecimal(excelReader.GetString(24)) * 100;


                            //English
                            if (!(string.IsNullOrEmpty(excelReader.GetString(28))))
                            {
                                theNewResult.EnglishLanguage_Attendance = Convert.ToInt16(excelReader.GetString(25));
                                theNewResult.EnglishLanguage_ContinuousAssessment = Convert.ToDecimal(excelReader.GetString(26));
                                theNewResult.EnglishLanguage_ExaminationScore = Convert.ToDecimal(excelReader.GetString(27));
                                theNewResult.EnglishLanguage_TotalScore = Convert.ToDecimal(excelReader.GetString(28));

                            }
                            //

                            //Yoruba
                            if (!(string.IsNullOrEmpty(excelReader.GetString(32))))
                            {
                                theNewResult.Yoruba_Attendance = Convert.ToInt16(excelReader.GetString(29));
                                theNewResult.Yoruba_ContinuousAssessment = Convert.ToDecimal(excelReader.GetString(30));
                                theNewResult.Yoruba_ExaminationScore = Convert.ToDecimal(excelReader.GetString(31));
                                theNewResult.Yoruba_TotalScore = Convert.ToDecimal(excelReader.GetString(32));
                            }

                            //French
                            if (!(string.IsNullOrEmpty((excelReader.GetString(36)))))
                            {
                                theNewResult.French_Attendance = Convert.ToInt16((excelReader.GetString(33)));
                                theNewResult.French_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(34)));
                                theNewResult.French_ExaminationScore = Convert.ToDecimal((excelReader.GetString(35)));
                                theNewResult.French_TotalScore = Convert.ToDecimal(excelReader.GetString(36));
                            }


                            //Literature in English

                            //   string lie = dr["Literature in English (Attendance)"].ToString();

                            if (!(string.IsNullOrEmpty(((excelReader.GetString(40))))))
                            {
                                theNewResult.LiteratureinEnglish_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(37)));
                                theNewResult.LiteratureinEnglish_ExaminationScore = Convert.ToDecimal((excelReader.GetString(38)));
                                theNewResult.LiteratureinEnglish_TotalScore = Convert.ToDecimal((excelReader.GetString(39)));

                                theNewResult.LiteratureinEnglish_Attendance = Convert.ToInt16((excelReader.GetString(40)));
                            }




                            //Igbo
                            if (!(string.IsNullOrEmpty((excelReader.GetString(44)))))
                            {
                                theNewResult.Igbo_Attendance = Convert.ToInt16((excelReader.GetString(41)));
                                theNewResult.Igbo_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(42)));
                                theNewResult.Igbo_ExaminationScore = Convert.ToDecimal((excelReader.GetString(43)));
                                theNewResult.Igbo_TotalScore = Convert.ToDecimal((excelReader.GetString(44)));

                            }
                            //Hausa
                            if (!(string.IsNullOrEmpty((excelReader.GetString(48)))))
                            {
                                theNewResult.Hausa_Attendance = Convert.ToInt16((excelReader.GetString(45)));
                                theNewResult.Hausa_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(46)));
                                theNewResult.Hausa_ExaminationScore = Convert.ToDecimal((excelReader.GetString(47)));
                                theNewResult.Hausa_TotalScore = Convert.ToDecimal((excelReader.GetString(48)));

                            }
                            //Physics
                            if (!(string.IsNullOrEmpty((excelReader.GetString(52)))))
                            {
                                theNewResult.Physics_Attendance = Convert.ToInt16((excelReader.GetString(49)));
                                theNewResult.Physics_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(50)));
                                theNewResult.Physics_ExaminationScore = Convert.ToDecimal((excelReader.GetString(51)));
                                theNewResult.Physics_TotalScore = Convert.ToDecimal((excelReader.GetString(52)));

                            }

                            //Chemistry
                            if (!(string.IsNullOrEmpty((excelReader.GetString(56)))))
                            {
                                theNewResult.Chemistry_Attendance = Convert.ToInt16((excelReader.GetString(53)));
                                theNewResult.Chemistry_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(54)));
                                theNewResult.Chemistry_ExaminationScore = Convert.ToDecimal((excelReader.GetString(55)));
                                theNewResult.Chemistry_TotalScore = Convert.ToDecimal((excelReader.GetString(56)));
                            }


                            //Biology
                            if (!(string.IsNullOrEmpty((excelReader.GetString(60)))))
                            {
                                theNewResult.Biology_Attendance = Convert.ToInt16((excelReader.GetString(57)));
                                theNewResult.Biology_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(58)));
                                theNewResult.Biology_ExaminationScore = Convert.ToDecimal((excelReader.GetString(59)));
                                theNewResult.Biology_TotalScore = Convert.ToDecimal((excelReader.GetString(60)));

                            }
                            //Computer
                            if (!(string.IsNullOrEmpty((excelReader.GetString(64)))))
                            {
                                theNewResult.Computer_Attendance = Convert.ToInt16((excelReader.GetString(61)));
                                theNewResult.Computer_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(62)));
                                theNewResult.Computer_ExaminationScore = Convert.ToDecimal((excelReader.GetString(63)));
                                theNewResult.Computer_TotalScore = Convert.ToDecimal((excelReader.GetString(64)));
                            }

                            //Physical Health Education
                            if (!(string.IsNullOrEmpty((excelReader.GetString(68)))))
                            {
                                theNewResult.PhysicalHealthEducation_Attendance = Convert.ToInt16((excelReader.GetString(65)));
                                theNewResult.PhysicalHealthEducation_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(66)));
                                theNewResult.PhysicalHealthEducation_ExaminationScore = Convert.ToDecimal((excelReader.GetString(67)));
                                theNewResult.PhysicalHealthEducation_TotalScore = Convert.ToDecimal((excelReader.GetString(68)));
                            }


                            //Physical Health Education
                            if (!(string.IsNullOrEmpty((excelReader.GetString(72)))))
                            {
                                theNewResult.Mathematics_Attendance = Convert.ToInt16((excelReader.GetString(69)));
                                theNewResult.Mathematics_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(70)));
                                theNewResult.Mathematics_ExaminationScore = Convert.ToDecimal((excelReader.GetString(71)));
                                theNewResult.Mathematics_TotalScore = Convert.ToDecimal((excelReader.GetString(72)));

                            }

                            //Further Mathematics
                            if (!(string.IsNullOrEmpty((excelReader.GetString(76)))))
                            {
                                theNewResult.FurtherMathematics_Attendance = Convert.ToInt16((excelReader.GetString(73)));
                                theNewResult.FurtherMathematics_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(74)));
                                theNewResult.FurtherMathematics_ExaminationScore = Convert.ToDecimal((excelReader.GetString(75)));
                                theNewResult.FurtherMathematics_TotalScore = Convert.ToDecimal((excelReader.GetString(76)));
                            }


                            //Agricultural Science
                            if (!(string.IsNullOrEmpty((excelReader.GetString(80)))))
                            {
                                theNewResult.AgriculturalScience_Attendance = Convert.ToInt16((excelReader.GetString(77)));
                                theNewResult.AgriculturalScience_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(78)));
                                theNewResult.AgriculturalScience_ExaminationScore = Convert.ToDecimal((excelReader.GetString(79)));
                                theNewResult.AgriculturalScience_TotalScore = Convert.ToDecimal((excelReader.GetString(80)));

                            }
                            //Food and Nutrition (Attendance)
                            if (!(string.IsNullOrEmpty((excelReader.GetString(84)))))
                            {
                                theNewResult.FoodandNutrition_Attendance = Convert.ToInt16((excelReader.GetString(81)));
                                theNewResult.FoodandNutrition_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(82)));
                                theNewResult.FoodandNutrition_ExaminationScore = Convert.ToDecimal((excelReader.GetString(83)));
                                theNewResult.FoodandNutrition_TotalScore = Convert.ToDecimal((excelReader.GetString(84)));

                            }
                            //Technical Drawing (Attendance)
                            if (!(string.IsNullOrEmpty((excelReader.GetString(88)))))
                            {
                                theNewResult.TechnicalDrawing_Attendance = Convert.ToInt16((excelReader.GetString(85)));
                                theNewResult.TechnicalDrawing_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(86)));
                                theNewResult.TechnicalDrawing_ExaminationScore = Convert.ToDecimal((excelReader.GetString(87)));
                                theNewResult.TechnicalDrawing_TotalScore = Convert.ToDecimal((excelReader.GetString(88)));

                            }

                            //Visual Art  (Attendance)
                            if (!(string.IsNullOrEmpty((excelReader.GetString(92)))))
                            {
                                theNewResult.VisualArt_Attendance = Convert.ToInt16((excelReader.GetString(89)));
                                theNewResult.VisualArt_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(90)));
                                theNewResult.VisualArt_ExaminationScore = Convert.ToDecimal((excelReader.GetString(91)));
                                theNewResult.VisualArt_TotalScore = Convert.ToDecimal((excelReader.GetString(92)));
                            }

                            //Home Economics 
                            if (!(string.IsNullOrEmpty((excelReader.GetString(96)))))
                            {
                                theNewResult.HomeEconomics_Attendance = Convert.ToInt16((excelReader.GetString(93)));
                                theNewResult.HomeEconomics_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(94)));
                                theNewResult.HomeEconomics_ExaminationScore = Convert.ToDecimal((excelReader.GetString(95)));
                                theNewResult.HomeEconomics_TotalScore = Convert.ToDecimal((excelReader.GetString(96)));

                            }
                            //Music
                            if (!(string.IsNullOrEmpty((excelReader.GetString(100)))))
                            {
                                theNewResult.Music_Attendance = Convert.ToInt16((excelReader.GetString(97)));
                                theNewResult.Music_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(98)));
                                theNewResult.Music_ExaminationScore = Convert.ToDecimal((excelReader.GetString(99)));
                                theNewResult.Music_TotalScore = Convert.ToDecimal((excelReader.GetString(100)));
                            }
                            //Economics  
                            if (!(string.IsNullOrEmpty((excelReader.GetString(104)))))
                            {
                                theNewResult.Economics_Attendance = Convert.ToInt16((excelReader.GetString(101)));
                                theNewResult.Economics_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(102)));
                                theNewResult.Economics_ExaminationScore = Convert.ToDecimal((excelReader.GetString(103)));
                                theNewResult.Economics_TotalScore = Convert.ToDecimal((excelReader.GetString(104)));
                            }


                            //Geography   
                            if (!(string.IsNullOrEmpty((excelReader.GetString(108)))))
                            {
                                theNewResult.Geography_Attendance = Convert.ToInt16((excelReader.GetString(105)));
                                theNewResult.Geography_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(106)));
                                theNewResult.Geography_ExaminationScore = Convert.ToDecimal((excelReader.GetString(107)));
                                theNewResult.Geography_TotalScore = Convert.ToDecimal((excelReader.GetString(108)));
                            }



                            //Financial Accounting   
                            if (!(string.IsNullOrEmpty((excelReader.GetString(112)))))
                            {
                                theNewResult.FinancialAccounting_Attendance = Convert.ToInt16((excelReader.GetString(109)));
                                theNewResult.FinancialAccounting_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(110)));
                                theNewResult.FinancialAccounting_ExaminationScore = Convert.ToDecimal((excelReader.GetString(111)));
                                theNewResult.FinancialAccounting_TotalScore = Convert.ToDecimal((excelReader.GetString(112)));

                            }
                            //History
                            if (!(string.IsNullOrEmpty((excelReader.GetString(116)))))
                            {
                                theNewResult.History_Attendance = Convert.ToInt16((excelReader.GetString(113)));
                                theNewResult.History_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(114)));
                                theNewResult.History_ExaminationScore = Convert.ToDecimal((excelReader.GetString(115)));
                                theNewResult.History_TotalScore = Convert.ToDecimal((excelReader.GetString(116)));
                            }


                            //Business Studies
                            if (!(string.IsNullOrEmpty((excelReader.GetString(120)))))
                            {
                                theNewResult.BusinessStudies_Attendance = Convert.ToInt16((excelReader.GetString(117)));
                                theNewResult.BusinessStudies_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(118)));
                                theNewResult.BusinessStudies_ExaminationScore = Convert.ToDecimal((excelReader.GetString(119)));
                                theNewResult.BusinessStudies_TotalScore = Convert.ToDecimal((excelReader.GetString(120)));
                            }


                            //Social Studies
                            if (!(string.IsNullOrEmpty((excelReader.GetString(124)))))
                            {
                                theNewResult.SocialStudies_Attendance = Convert.ToInt16((excelReader.GetString(121)));
                                theNewResult.SocialStudies_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(122)));
                                theNewResult.SocialStudies_ExaminationScore = Convert.ToDecimal((excelReader.GetString(123)));
                                theNewResult.SocialStudies_TotalScore = Convert.ToDecimal((excelReader.GetString(124)));
                            }


                            //Commerce
                            if (!(string.IsNullOrEmpty((excelReader.GetString(128)))))
                            {
                                theNewResult.Commerce_Attendance = Convert.ToInt16((excelReader.GetString(125)));
                                theNewResult.Commerce_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(126)));
                                theNewResult.Commerce_ExaminationScore = Convert.ToDecimal((excelReader.GetString(127)));
                                theNewResult.Commerce_TotalScore = Convert.ToDecimal((excelReader.GetString(128)));

                            }
                            //Government_Attendance
                            if (!(string.IsNullOrEmpty((excelReader.GetString(132)))))
                            {
                                theNewResult.Government_Attendance = Convert.ToInt16((excelReader.GetString(129)));
                                theNewResult.Government_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(130)));
                                theNewResult.Government_ExaminationScore = Convert.ToDecimal((excelReader.GetString(131)));
                                theNewResult.Government_TotalScore = Convert.ToDecimal((excelReader.GetString(132)));
                            }


                            //Christian Religious Knowledge
                            if (!(string.IsNullOrEmpty((excelReader.GetString(136)))))
                            {
                                theNewResult.ChristianReligiousKnowledge_Attendance = Convert.ToInt16((excelReader.GetString(133)));
                                theNewResult.ChristianReligiousKnowledge_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(134)));
                                theNewResult.ChristianReligiousKnowledge_ExaminationScore = Convert.ToDecimal((excelReader.GetString(135)));
                                theNewResult.ChristianReligiousKnowledge_TotalScore = Convert.ToDecimal((excelReader.GetString(136)));
                            }

                            //Islamic Religious Knowledge(Attendance
                            if (!(string.IsNullOrEmpty((excelReader.GetString(140)))))
                            {
                                theNewResult.IslamicReligiousKnowledge_Attendance = Convert.ToInt16((excelReader.GetString(137)));
                                theNewResult.IslamicReligiousKnowledge_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(138)));
                                theNewResult.IslamicReligiousKnowledge_ExaminationScore = Convert.ToDecimal((excelReader.GetString(139)));
                                theNewResult.IslamicReligiousKnowledge_TotalScore = Convert.ToDecimal((excelReader.GetString(140)));

                            }
                            //Royal English
                            if (!(string.IsNullOrEmpty((excelReader.GetString(144)))))
                            {
                                theNewResult.RoyalEnglish_Attendance = Convert.ToInt16((excelReader.GetString(141)));
                                theNewResult.RoyalEnglish_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(142)));
                                theNewResult.RoyalEnglish_ExaminationScore = Convert.ToDecimal((excelReader.GetString(143)));
                                theNewResult.RoyalEnglish_TotalScore = Convert.ToDecimal((excelReader.GetString(144)));

                            }


                            //Basic Science
                            if (!(string.IsNullOrEmpty((excelReader.GetString(148)))))
                            {
                                theNewResult.BasicScience_Attendance = Convert.ToInt16((excelReader.GetString(145)));
                                theNewResult.BasicScience_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(146)));
                                theNewResult.BasicScience_ExaminationScore = Convert.ToDecimal((excelReader.GetString(147)));
                                theNewResult.BasicScience_TotalScore = Convert.ToDecimal((excelReader.GetString(148)));
                            }
                            //Basic Technology
                            if (!(string.IsNullOrEmpty((excelReader.GetString(152)))))
                            {
                                theNewResult.BasicTechnology_Attendance = Convert.ToInt16((excelReader.GetString(149)));
                                theNewResult.BasicTechnology_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(150)));
                                theNewResult.BasicTechnology_ExaminationScore = Convert.ToDecimal((excelReader.GetString(151)));
                                theNewResult.BasicTechnology_TotalScore = Convert.ToDecimal((excelReader.GetString(152)));
                            }

                            //Civil Education
                            if (!(string.IsNullOrEmpty((excelReader.GetString(156)))))
                            {
                                theNewResult.CivicEducation_Attendance = Convert.ToInt16((excelReader.GetString(153)));
                                theNewResult.CivicEducation_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(154)));
                                theNewResult.CivicEducation_ExaminationScore = Convert.ToDecimal((excelReader.GetString(155)));
                                theNewResult.CivicEducation_TotalScore = Convert.ToDecimal((excelReader.GetString(156)));
                            }


                            //creative art 
                            if (!(string.IsNullOrEmpty((excelReader.GetString(160)))))
                            {
                                theNewResult.CreativeArt_Attendance = Convert.ToInt16((excelReader.GetString(157)));
                                theNewResult.CreativeArt_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(158)));
                                theNewResult.CreativeArt_ExaminationScore = Convert.ToDecimal((excelReader.GetString(159)));
                                theNewResult.CreativeArt_TotalScore = Convert.ToDecimal((excelReader.GetString(160)));
                            }

                            ////creative art 
                            //if (!(string.IsNullOrEmpty((excelReader.GetString(154)))))
                            //{
                            //    theNewResult.CreativeArt_Attendance = Convert.ToInt16((excelReader.GetString(151)));
                            //    theNewResult.CreativeArt_ContinuousAssessment = Convert.ToDecimal((excelReader.GetString(152)));
                            //    theNewResult.CreativeArt_ExaminationScore = Convert.ToDecimal((excelReader.GetString(153)));
                            //    theNewResult.CreativeArt_TotalScore = Convert.ToDecimal((excelReader.GetString(154)));
                            //}

                           // theNewResult.ClassUploaded = ;
                           // work.ResultRepository.Insert(theNewResult);

                            theResultList.Add(theNewResult);

                        }
                        catch (Exception e)
                        {

                        }

                        // but it herer
                    }
                    counter = counter + 1;
                }

                //6. Free resources (IExcelDataReader is IDisposable)
                excelReader.Close();

                foreach (Result r in theResultList)
                {
                    try
                    {
                        if (!(string.IsNullOrEmpty(r.StudentNo)))
                        {

                            work.ResultRepository.Insert(r);
                        }
                    }
                    catch(Exception e)
                    {

                    }
                   
                }
                work.Save();


            }

            catch (Exception e)
            {

            }



        }
    }
}