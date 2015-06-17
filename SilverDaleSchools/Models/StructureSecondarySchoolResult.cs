using SilverDaleSchools.DAL;
using SilverDaleSchools.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverDaleSchools.Models
{
    public class StructureSecondarySchoolResult
    {
        List<string> theStudentAttendance = new List<string>();
        List<string> theStudentCA = new List<string>();
        List<string> theStudentExam = new List<string>();
        List<string> theStudentTotal = new List<string>();
        List<string> theStudentAveweight = new List<string>();
        public List<string> StructureAttendance(Result theResult)
        {

            if (theResult.EnglishLanguage_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.EnglishLanguage_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.Mathematics_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.Mathematics_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }


            if (theResult.Biology_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.Biology_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }


            if (theResult.Physics_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.Physics_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.Chemistry_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.Chemistry_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.Yoruba_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.Yoruba_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.ChristianReligiousKnowledge_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.ChristianReligiousKnowledge_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.Geography_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.Geography_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.AgriculturalScience_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.AgriculturalScience_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.FoodandNutrition_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.FoodandNutrition_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.Economics_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.Economics_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.French_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.French_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.CivicEducation_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.CivicEducation_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.Computer_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.Computer_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.LiteratureinEnglish_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.LiteratureinEnglish_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }



            if (theResult.FurtherMathematics_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.FurtherMathematics_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.Commerce_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.Commerce_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.RoyalEnglish_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.RoyalEnglish_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }

            if (theResult.FinancialAccounting_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.FinancialAccounting_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }


            if (theResult.Government_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.Government_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }
            if (theResult.TechnicalDrawing_Attendance > 0)
            {
                theStudentAttendance.Add(theResult.TechnicalDrawing_Attendance.ToString());
            }
            else
            {
                theStudentAttendance.Add("");
            }
            return theStudentAttendance;
        }


        public List<string> StructureCA(Result theResult)
        {

            if (theResult.EnglishLanguage_Attendance > 0)
            {
                theStudentCA.Add(theResult.EnglishLanguage_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.Mathematics_Attendance > 0)
            {
                theStudentCA.Add(theResult.Mathematics_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }


            if (theResult.Biology_Attendance > 0)
            {
                theStudentCA.Add(theResult.Biology_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }


            if (theResult.Physics_Attendance > 0)
            {
                theStudentCA.Add(theResult.Physics_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.Chemistry_Attendance > 0)
            {
                theStudentCA.Add(theResult.Chemistry_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.Yoruba_Attendance > 0)
            {
                theStudentCA.Add(theResult.Yoruba_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.ChristianReligiousKnowledge_Attendance > 0)
            {
                theStudentCA.Add(theResult.ChristianReligiousKnowledge_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.Geography_Attendance > 0)
            {
                theStudentCA.Add(theResult.Geography_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.AgriculturalScience_Attendance > 0)
            {
                theStudentCA.Add(theResult.AgriculturalScience_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.FoodandNutrition_Attendance > 0)
            {
                theStudentCA.Add(theResult.FoodandNutrition_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.Economics_Attendance > 0)
            {
                theStudentCA.Add(theResult.Economics_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.French_Attendance > 0)
            {
                theStudentCA.Add(theResult.French_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.CivicEducation_Attendance > 0)
            {
                theStudentCA.Add(theResult.CivicEducation_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.Computer_Attendance > 0)
            {
                theStudentCA.Add(theResult.Computer_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.LiteratureinEnglish_Attendance > 0)
            {
                theStudentCA.Add(theResult.LiteratureinEnglish_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }


            if (theResult.FurtherMathematics_Attendance > 0)
            {
                theStudentCA.Add(theResult.FurtherMathematics_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.Commerce_Attendance > 0)
            {
                theStudentCA.Add(theResult.Commerce_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.RoyalEnglish_Attendance > 0)
            {
                theStudentCA.Add(theResult.RoyalEnglish_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.FinancialAccounting_Attendance > 0)
            {
                theStudentCA.Add(theResult.FinancialAccounting_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }

            if (theResult.Government_Attendance > 0)
            {
                theStudentCA.Add(theResult.Government_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }
            if (theResult.TechnicalDrawing_Attendance > 0)
            {
                theStudentCA.Add(theResult.TechnicalDrawing_ContinuousAssessment.ToString());
            }
            else
            {
                theStudentCA.Add("");
            }
            return theStudentCA;
        }



        public List<string> StructureExam(Result theResult)
        {

            if (theResult.EnglishLanguage_Attendance > 0)
            {
                theStudentExam.Add(theResult.EnglishLanguage_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.Mathematics_Attendance > 0)
            {
                theStudentExam.Add(theResult.Mathematics_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }


            if (theResult.Biology_Attendance > 0)
            {
                theStudentExam.Add(theResult.Biology_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }


            if (theResult.Physics_Attendance > 0)
            {
                theStudentExam.Add(theResult.Physics_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.Chemistry_Attendance > 0)
            {
                theStudentExam.Add(theResult.Chemistry_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.Yoruba_Attendance > 0)
            {
                theStudentExam.Add(theResult.Yoruba_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.ChristianReligiousKnowledge_Attendance > 0)
            {
                theStudentExam.Add(theResult.ChristianReligiousKnowledge_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.Geography_Attendance > 0)
            {
                theStudentExam.Add(theResult.Geography_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.AgriculturalScience_Attendance > 0)
            {
                theStudentExam.Add(theResult.AgriculturalScience_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.FoodandNutrition_Attendance > 0)
            {
                theStudentExam.Add(theResult.FoodandNutrition_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.Economics_Attendance > 0)
            {
                theStudentExam.Add(theResult.Economics_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.French_Attendance > 0)
            {
                theStudentExam.Add(theResult.French_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.CivicEducation_Attendance > 0)
            {
                theStudentExam.Add(theResult.CivicEducation_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.Computer_Attendance > 0)
            {
                theStudentExam.Add(theResult.Computer_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.LiteratureinEnglish_Attendance > 0)
            {
                theStudentExam.Add(theResult.LiteratureinEnglish_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }


            if (theResult.FurtherMathematics_Attendance > 0)
            {
                theStudentExam.Add(theResult.FurtherMathematics_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.Commerce_Attendance > 0)
            {
                theStudentExam.Add(theResult.Commerce_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.RoyalEnglish_Attendance > 0)
            {
                theStudentExam.Add(theResult.RoyalEnglish_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.FinancialAccounting_Attendance > 0)
            {
                theStudentExam.Add(theResult.FinancialAccounting_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.Government_Attendance > 0)
            {
                theStudentExam.Add(theResult.Government_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }
            if (theResult.TechnicalDrawing_Attendance > 0)
            {
                theStudentExam.Add(theResult.TechnicalDrawing_ExaminationScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }
            return theStudentExam;
        }


        public List<string> StructureTotal(Result theResult)
        {

            if (theResult.EnglishLanguage_Attendance > 0)
            {
                theStudentTotal.Add(theResult.EnglishLanguage_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.Mathematics_Attendance > 0)
            {
                theStudentTotal.Add(theResult.Mathematics_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }


            if (theResult.Biology_Attendance > 0)
            {
                theStudentTotal.Add(theResult.Biology_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }


            if (theResult.Physics_Attendance > 0)
            {
                theStudentTotal.Add(theResult.Physics_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.Chemistry_Attendance > 0)
            {
                theStudentTotal.Add(theResult.Chemistry_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.Yoruba_Attendance > 0)
            {
                theStudentTotal.Add(theResult.Yoruba_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.ChristianReligiousKnowledge_Attendance > 0)
            {
                theStudentTotal.Add(theResult.ChristianReligiousKnowledge_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.Geography_Attendance > 0)
            {
                theStudentTotal.Add(theResult.Geography_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.AgriculturalScience_Attendance > 0)
            {
                theStudentTotal.Add(theResult.AgriculturalScience_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.FoodandNutrition_Attendance > 0)
            {
                theStudentTotal.Add(theResult.FoodandNutrition_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.Economics_Attendance > 0)
            {
                theStudentTotal.Add(theResult.Economics_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.French_Attendance > 0)
            {
                theStudentTotal.Add(theResult.French_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.CivicEducation_Attendance > 0)
            {
                theStudentTotal.Add(theResult.CivicEducation_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.Computer_Attendance > 0)
            {
                theStudentTotal.Add(theResult.Computer_TotalScore.ToString());
            }
            else
            {
                theStudentExam.Add("");
            }

            if (theResult.LiteratureinEnglish_Attendance > 0)
            {
                theStudentTotal.Add(theResult.LiteratureinEnglish_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }


            if (theResult.FurtherMathematics_Attendance > 0)
            {
                theStudentTotal.Add(theResult.FurtherMathematics_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.Commerce_Attendance > 0)
            {
                theStudentTotal.Add(theResult.Commerce_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.RoyalEnglish_Attendance > 0)
            {
                theStudentTotal.Add(theResult.RoyalEnglish_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.FinancialAccounting_Attendance > 0)
            {
                theStudentTotal.Add(theResult.FinancialAccounting_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }

            if (theResult.Government_Attendance > 0)
            {
                theStudentTotal.Add(theResult.Government_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }
            if (theResult.TechnicalDrawing_Attendance > 0)
            {
                theStudentTotal.Add(theResult.TechnicalDrawing_TotalScore.ToString());
            }
            else
            {
                theStudentTotal.Add("");
            }
            return theStudentTotal;
        }

        public List<string> StructureWieghtAveSecondTerm(Result theResult)
        {
            UnitOfWork work = new UnitOfWork();
            string theTerm = theResult.Term;
            List<Result> secondSemeterResult = new List<Result>();

            //if (theTerm == "3")
            //{
            //  secondSemeterResult =  work.ResultRepository.Get(a => a.Session == theResult.Session && a.Term == "2" && theResult.StudentNo == theResult.StudentNo).ToList();
            //}

            if (theTerm == "2")
            {
                secondSemeterResult = work.ResultRepository.Get(a => a.Session == theResult.Session && a.StudentNo == theResult.StudentNo && a.Class == theResult.Class && a.Term == "1" && theResult.StudentNo == theResult.StudentNo).ToList();
            }


            if (secondSemeterResult.Count == 0)
            {
                if (theResult.EnglishLanguage_Attendance > 0)
                {

                    // StructureWieghtAve
                    theStudentAveweight.Add(theResult.EnglishLanguage_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Mathematics_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Mathematics_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.Biology_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Biology_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.Physics_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Physics_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Chemistry_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Chemistry_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Yoruba_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Yoruba_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.ChristianReligiousKnowledge_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.ChristianReligiousKnowledge_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Geography_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Geography_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.AgriculturalScience_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.AgriculturalScience_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.FoodandNutrition_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.FoodandNutrition_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Economics_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Economics_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.French_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.French_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.CivicEducation_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.CivicEducation_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Computer_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Computer_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.LiteratureinEnglish_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.LiteratureinEnglish_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.FurtherMathematics_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.FurtherMathematics_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Commerce_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Commerce_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.RoyalEnglish_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.RoyalEnglish_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.FinancialAccounting_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.FinancialAccounting_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Government_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Government_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }
                if (theResult.TechnicalDrawing_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.TechnicalDrawing_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }
                return theStudentAveweight;
            }
            else
            {



                Result thePastResult = secondSemeterResult[0];





                if (theResult.EnglishLanguage_Attendance > 0)
                {

                    // StructureWieghtAve
                    theStudentAveweight.Add((((theResult.EnglishLanguage_TotalScore + thePastResult.EnglishLanguage_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Mathematics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Mathematics_TotalScore + thePastResult.Mathematics_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.Biology_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Biology_TotalScore + thePastResult.Biology_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.Physics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Physics_TotalScore + thePastResult.Physics_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Chemistry_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Chemistry_TotalScore + thePastResult.Chemistry_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Yoruba_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Yoruba_TotalScore + thePastResult.Yoruba_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.ChristianReligiousKnowledge_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.ChristianReligiousKnowledge_TotalScore + thePastResult.ChristianReligiousKnowledge_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Geography_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Geography_TotalScore + thePastResult.Geography_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.AgriculturalScience_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.AgriculturalScience_TotalScore + thePastResult.AgriculturalScience_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.FoodandNutrition_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.FoodandNutrition_TotalScore + thePastResult.FoodandNutrition_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Economics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Economics_TotalScore + thePastResult.Economics_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.French_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.French_TotalScore + thePastResult.French_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.CivicEducation_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.CivicEducation_TotalScore + thePastResult.CivicEducation_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Computer_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Computer_TotalScore + thePastResult.Computer_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.LiteratureinEnglish_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.LiteratureinEnglish_TotalScore + thePastResult.LiteratureinEnglish_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.FurtherMathematics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.FurtherMathematics_TotalScore + thePastResult.FurtherMathematics_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Commerce_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Commerce_TotalScore + thePastResult.Commerce_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.RoyalEnglish_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.RoyalEnglish_TotalScore + thePastResult.RoyalEnglish_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.FinancialAccounting_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.FinancialAccounting_TotalScore + thePastResult.FinancialAccounting_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Government_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Government_TotalScore + thePastResult.Government_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }
                if (theResult.TechnicalDrawing_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.TechnicalDrawing_TotalScore + thePastResult.TechnicalDrawing_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }
                return theStudentAveweight;
            }

        }




        public List<string> StructureWieghtAveThirdTerm(Result theResult)
        {
            UnitOfWork work = new UnitOfWork();
            string theTerm = theResult.Term;
            List<Result> secondSemeterResult = new List<Result>();
            List<Result> firstSemeterResult = new List<Result>();

            if (theTerm == "3")
            {
                firstSemeterResult = work.ResultRepository.Get(a => a.Session == theResult.Session && a.StudentNo == theResult.StudentNo && a.Class == theResult.Class && a.Term == "1" && theResult.StudentNo == theResult.StudentNo).ToList();
                secondSemeterResult = work.ResultRepository.Get(a => a.Session == theResult.Session && a.StudentNo == theResult.StudentNo && a.Class == theResult.Class && a.Term == "2" && theResult.StudentNo == theResult.StudentNo).ToList();
            }

            //if (theTerm == "2")
            //{
            //    secondSemeterResult = work.ResultRepository.Get(a => a.Session == theResult.Session && a.Term == "2" && theResult.StudentNo == theResult.StudentNo).ToList();
            //}


            if (secondSemeterResult.Count == 0 && firstSemeterResult.Count == 0)
            {
                if (theResult.EnglishLanguage_Attendance > 0)
                {

                    // StructureWieghtAve
                    theStudentAveweight.Add(theResult.EnglishLanguage_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Mathematics_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Mathematics_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.Biology_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Biology_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.Physics_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Physics_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Chemistry_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Chemistry_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Yoruba_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Yoruba_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.ChristianReligiousKnowledge_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.ChristianReligiousKnowledge_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Geography_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Geography_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.AgriculturalScience_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.AgriculturalScience_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.FoodandNutrition_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.FoodandNutrition_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Economics_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Economics_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.French_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.French_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.CivicEducation_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.CivicEducation_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Computer_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Computer_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.LiteratureinEnglish_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.LiteratureinEnglish_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.FurtherMathematics_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.FurtherMathematics_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Commerce_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Commerce_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.RoyalEnglish_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.RoyalEnglish_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.FinancialAccounting_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.FinancialAccounting_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Government_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.Government_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }
                if (theResult.TechnicalDrawing_Attendance > 0)
                {
                    theStudentAveweight.Add(theResult.TechnicalDrawing_TotalScore.ToString());
                }
                else
                {
                    theStudentAveweight.Add("");
                }
                return theStudentAveweight;
            }
            if (secondSemeterResult.Count > 0 && firstSemeterResult.Count == 0)
            {



                Result thePastResult = secondSemeterResult[0];





                if (theResult.EnglishLanguage_Attendance > 0)
                {

                    // StructureWieghtAve
                    theStudentAveweight.Add((((theResult.EnglishLanguage_TotalScore + thePastResult.EnglishLanguage_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Mathematics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Mathematics_TotalScore + thePastResult.Mathematics_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.Biology_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Biology_TotalScore + thePastResult.Biology_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.Physics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Physics_TotalScore + thePastResult.Physics_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Chemistry_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Chemistry_TotalScore + thePastResult.Chemistry_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Yoruba_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Yoruba_TotalScore + thePastResult.Yoruba_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.ChristianReligiousKnowledge_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.ChristianReligiousKnowledge_TotalScore + thePastResult.ChristianReligiousKnowledge_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Geography_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Geography_TotalScore + thePastResult.Geography_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.AgriculturalScience_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.AgriculturalScience_TotalScore + thePastResult.AgriculturalScience_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.FoodandNutrition_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.FoodandNutrition_TotalScore + thePastResult.FoodandNutrition_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Economics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Economics_TotalScore + thePastResult.Economics_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.French_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.French_TotalScore + thePastResult.French_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.CivicEducation_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.CivicEducation_TotalScore + thePastResult.CivicEducation_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Computer_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Computer_TotalScore + thePastResult.Computer_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.LiteratureinEnglish_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.LiteratureinEnglish_TotalScore + thePastResult.LiteratureinEnglish_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.FurtherMathematics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.FurtherMathematics_TotalScore + thePastResult.FurtherMathematics_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Commerce_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Commerce_TotalScore + thePastResult.Commerce_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.RoyalEnglish_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.RoyalEnglish_TotalScore + thePastResult.RoyalEnglish_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.FinancialAccounting_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.FinancialAccounting_TotalScore + thePastResult.FinancialAccounting_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Government_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Government_TotalScore + thePastResult.Government_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }
                if (theResult.TechnicalDrawing_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.TechnicalDrawing_TotalScore + thePastResult.TechnicalDrawing_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }
                return theStudentAveweight;
            }


            if (secondSemeterResult.Count == 0 && firstSemeterResult.Count > 0)
            {



                Result thePastResult = firstSemeterResult[0];





                if (theResult.EnglishLanguage_Attendance > 0)
                {

                    // StructureWieghtAve
                    theStudentAveweight.Add((((theResult.EnglishLanguage_TotalScore + thePastResult.EnglishLanguage_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Mathematics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Mathematics_TotalScore + thePastResult.Mathematics_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.Biology_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Biology_TotalScore + thePastResult.Biology_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.Physics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Physics_TotalScore + thePastResult.Physics_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Chemistry_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Chemistry_TotalScore + thePastResult.Chemistry_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Yoruba_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Yoruba_TotalScore + thePastResult.Yoruba_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.ChristianReligiousKnowledge_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.ChristianReligiousKnowledge_TotalScore + thePastResult.ChristianReligiousKnowledge_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Geography_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Geography_TotalScore + thePastResult.Geography_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.AgriculturalScience_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.AgriculturalScience_TotalScore + thePastResult.AgriculturalScience_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.FoodandNutrition_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.FoodandNutrition_TotalScore + thePastResult.FoodandNutrition_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Economics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Economics_TotalScore + thePastResult.Economics_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.French_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.French_TotalScore + thePastResult.French_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.CivicEducation_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.CivicEducation_TotalScore + thePastResult.CivicEducation_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Computer_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Computer_TotalScore + thePastResult.Computer_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.LiteratureinEnglish_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.LiteratureinEnglish_TotalScore + thePastResult.LiteratureinEnglish_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.FurtherMathematics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.FurtherMathematics_TotalScore + thePastResult.FurtherMathematics_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Commerce_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Commerce_TotalScore + thePastResult.Commerce_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.RoyalEnglish_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.RoyalEnglish_TotalScore + thePastResult.RoyalEnglish_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.FinancialAccounting_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.FinancialAccounting_TotalScore + thePastResult.FinancialAccounting_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Government_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Government_TotalScore + thePastResult.Government_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }
                if (theResult.TechnicalDrawing_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.TechnicalDrawing_TotalScore + thePastResult.TechnicalDrawing_TotalScore) / 2).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }
                return theStudentAveweight;
            }






            if (secondSemeterResult.Count > 0 && firstSemeterResult.Count > 0)
            {



                Result thePastResult = firstSemeterResult[0];

                Result thePastResult2 = secondSemeterResult[0];





                if (theResult.EnglishLanguage_Attendance > 0)
                {

                    // StructureWieghtAve
                    theStudentAveweight.Add((((theResult.EnglishLanguage_TotalScore + thePastResult.EnglishLanguage_TotalScore + thePastResult2.EnglishLanguage_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Mathematics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Mathematics_TotalScore + thePastResult.Mathematics_TotalScore + thePastResult2.Mathematics_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.Biology_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Biology_TotalScore + thePastResult.Biology_TotalScore + thePastResult2.Biology_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.Physics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Physics_TotalScore + thePastResult.Physics_TotalScore + thePastResult2.Physics_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Chemistry_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Chemistry_TotalScore + thePastResult.Chemistry_TotalScore + thePastResult2.Chemistry_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Yoruba_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Yoruba_TotalScore + thePastResult.Yoruba_TotalScore + thePastResult2.Chemistry_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.ChristianReligiousKnowledge_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.ChristianReligiousKnowledge_TotalScore + thePastResult.ChristianReligiousKnowledge_TotalScore + thePastResult2.ChristianReligiousKnowledge_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Geography_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Geography_TotalScore + thePastResult.Geography_TotalScore + thePastResult2.Geography_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.AgriculturalScience_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.AgriculturalScience_TotalScore + thePastResult.AgriculturalScience_TotalScore + thePastResult2.AgriculturalScience_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.FoodandNutrition_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.FoodandNutrition_TotalScore + thePastResult.FoodandNutrition_TotalScore + thePastResult2.FoodandNutrition_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Economics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Economics_TotalScore + thePastResult.Economics_TotalScore + thePastResult2.Economics_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.French_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.French_TotalScore + thePastResult.French_TotalScore + thePastResult2.French_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.CivicEducation_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.CivicEducation_TotalScore + thePastResult.CivicEducation_TotalScore + thePastResult2.CivicEducation_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Computer_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Computer_TotalScore + thePastResult.Computer_TotalScore + thePastResult2.Computer_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.LiteratureinEnglish_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.LiteratureinEnglish_TotalScore + thePastResult.LiteratureinEnglish_TotalScore + thePastResult2.LiteratureinEnglish_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }


                if (theResult.FurtherMathematics_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.FurtherMathematics_TotalScore + thePastResult.FurtherMathematics_TotalScore + thePastResult2.FurtherMathematics_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Commerce_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Commerce_TotalScore + thePastResult.Commerce_TotalScore + thePastResult2.Commerce_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.RoyalEnglish_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.RoyalEnglish_TotalScore + thePastResult.RoyalEnglish_TotalScore + thePastResult2.RoyalEnglish_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.FinancialAccounting_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.FinancialAccounting_TotalScore + thePastResult.FinancialAccounting_TotalScore + thePastResult2.FinancialAccounting_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }

                if (theResult.Government_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.Government_TotalScore + thePastResult.Government_TotalScore + thePastResult2.Government_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }
                if (theResult.TechnicalDrawing_Attendance > 0)
                {
                    theStudentAveweight.Add((((theResult.TechnicalDrawing_TotalScore + thePastResult.TechnicalDrawing_TotalScore + thePastResult.TechnicalDrawing_TotalScore) / 3).ToString()));
                }
                else
                {
                    theStudentAveweight.Add("");
                }
                return theStudentAveweight;
            }
            return theStudentAveweight;


           

        }
    }
}