using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverDaleSchools.Model
{
    public class Result
    {
        public int ResultID { get; set; }

      //  public string ClassUploaded { get; set; }
        [Required]
        public string StudentNo { get; set; }

        [Required]
        public string Session { get; set; }
        [Required]
        public string Term { get; set; }

        [Required]
        public string Class { get; set; }

        [Display(Name = "Surame")]
        public string Surname { get; set; }
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Display(Name = "Other names")]
        public string Othernames { get; set; }

        //[Required]
        public string Sex { get; set; }

       // public string Class { get; set; }

        [Display(Name = "No. of Times School Opened")]
        public int NoofTimesSchoolOpened { get; set; }

        [Display(Name = "No. of Times Present")]
        public int NoofTimesPresent { get; set; }

        [Display(Name = "No of Times Punctual")]
        public int NoofTimesPunctual { get; set; }

        [Display(Name = "No. of Times Absent")]
        public int NoofTimesAbsent { get; set; }

        //  [Display(Name = "No. of Times Absent")]
        public string Fluency { get; set; }

        public string Games { get; set; }

        public string Sports { get; set; }

        [Display(Name = "Handling of Tools")]
        public string HandlingofTools { get; set; }

        [Display(Name = "Musical Skills")]
        public string MusicalSkills { get; set; }

        [Display(Name = "Attentive and Works Independently")]
        public string AttentiveandWorkIndependently { get; set; }

        [Display(Name = "Does Homework Regularly")]
        public string DoesHomeworkRegularly { get; set; }

        [Display(Name = "Is Neat and Orderly")]
        public string IsNeatandOrderly { get; set; }

        [Display(Name = "Respect authority")]
        public string Respectauthority { get; set; }

        [Display(Name = "Take Care of Books and Property")]
        public string TakeCareofBooksandProperty { get; set; }


        [Display(Name = "Form Master's Comments")]
        public string FormMastersComments { get; set; }


        [Display(Name = "Principal's Comment")]
        public string PrincipalsComment { get; set; }


        [Display(Name = "Total Score Obtainable")]
        public decimal TotalScoreObtainable { get; set; }

        [Display(Name = "Total Score Obtained")]
        public decimal TotalScoreObtained { get; set; }

        [Display(Name = "Percentage")]
        public decimal Percentage { get; set; }

        //English
        [Display(Name = "English Language (Attendance)")]
        public int EnglishLanguage_Attendance { get; set; }

        [Display(Name = "English Language (Continuous Assessment)")]
        public decimal EnglishLanguage_ContinuousAssessment { get; set; }

        [Display(Name = "English Language (Examination Score)")]
        public decimal EnglishLanguage_ExaminationScore { get; set; }

        [Display(Name = "English Language (Total Score)")]
        public decimal EnglishLanguage_TotalScore { get; set; }


        //

        //Yoruba
        [Display(Name = "Yoruba (Attendance)")]
        public int Yoruba_Attendance { get; set; }

        [Display(Name = "Yoruba (Continuous Assessment)")]
        public decimal Yoruba_ContinuousAssessment { get; set; }

        [Display(Name = "Yoruba (Examination Score)")]
        public decimal Yoruba_ExaminationScore { get; set; }

        [Display(Name = "Yoruba (Total Score)")]
        public decimal Yoruba_TotalScore { get; set; }


        //French
        [Display(Name = "French (Attendance)")]
        public int French_Attendance { get; set; }

        [Display(Name = "French (Continuous Assessment)")]
        public decimal French_ContinuousAssessment { get; set; }

        [Display(Name = "French (Examination Score)")]
        public decimal French_ExaminationScore { get; set; }

        [Display(Name = "French (Total Score)")]
        public decimal French_TotalScore { get; set; }



        //Literature in English
        [Display(Name = "Literature in English (Attendance)")]
        public int LiteratureinEnglish_Attendance { get; set; }

        [Display(Name = "Literature in English (Continuous Assessment)")]
        public decimal LiteratureinEnglish_ContinuousAssessment { get; set; }

        [Display(Name = "Literature in English (Examination Score)")]
        public decimal LiteratureinEnglish_ExaminationScore { get; set; }

        [Display(Name = "Literature in English (Total Score)")]
        public decimal LiteratureinEnglish_TotalScore { get; set; }


        //Igbo
        [Display(Name = "Igbo (Attendance)")]
        public int Igbo_Attendance { get; set; }

        [Display(Name = "Igbo (Continuous Assessment)")]
        public decimal Igbo_ContinuousAssessment { get; set; }

        [Display(Name = "Igbo (Examination Score)")]
        public decimal Igbo_ExaminationScore { get; set; }

        [Display(Name = "Igbo (Total Score)")]
        public decimal Igbo_TotalScore { get; set; }

        //Hausa
        [Display(Name = "Hausa (Attendance)")]
        public int Hausa_Attendance { get; set; }

        [Display(Name = "Hausa (Continuous Assessment)")]
        public decimal Hausa_ContinuousAssessment { get; set; }

        [Display(Name = "Hausa (Examination Score)")]
        public decimal Hausa_ExaminationScore { get; set; }

        [Display(Name = "Hausa (Total Score)")]
        public decimal Hausa_TotalScore { get; set; }


        //Physics
        [Display(Name = "Physics (Attendance)")]
        public int Physics_Attendance { get; set; }

        [Display(Name = "Physics (Continuous Assessment)")]
        public decimal Physics_ContinuousAssessment { get; set; }

        [Display(Name = "Physics (Examination Score)")]
        public decimal Physics_ExaminationScore { get; set; }

        [Display(Name = "Physics (Total Score)")]
        public decimal Physics_TotalScore { get; set; }


        //Chemistry
        [Display(Name = "Chemistry (Attendance)")]
        public int Chemistry_Attendance { get; set; }

        [Display(Name = "Chemistry (Continuous Assessment)")]
        public decimal Chemistry_ContinuousAssessment { get; set; }

        [Display(Name = "Chemistry (Examination Score)")]
        public decimal Chemistry_ExaminationScore { get; set; }

        [Display(Name = "Chemistry (Total Score)")]
        public decimal Chemistry_TotalScore { get; set; }


        //Biology
        [Display(Name = "Biology (Attendance)")]
        public int Biology_Attendance { get; set; }

        [Display(Name = "Biology (Continuous Assessment)")]
        public decimal Biology_ContinuousAssessment { get; set; }

        [Display(Name = "Biology (Examination Score)")]
        public decimal Biology_ExaminationScore { get; set; }

        [Display(Name = "Biology (Total Score)")]
        public decimal Biology_TotalScore { get; set; }

        //Computer
        [Display(Name = "Computer (Attendance)")]
        public int Computer_Attendance { get; set; }

        [Display(Name = "Computer (Continuous Assessment)")]
        public decimal Computer_ContinuousAssessment { get; set; }

        [Display(Name = "Computer (Examination Score)")]
        public decimal Computer_ExaminationScore { get; set; }

        [Display(Name = "Computer (Total Score)")]
        public decimal Computer_TotalScore { get; set; }


        //Physical Health Education
        [Display(Name = "Physical Health Education (Attendance)")]
        public int PhysicalHealthEducation_Attendance { get; set; }

        [Display(Name = "Physical Health Education (Continuous Assessment)")]
        public decimal PhysicalHealthEducation_ContinuousAssessment { get; set; }

        [Display(Name = "Physical Health Education (Examination Score)")]
        public decimal PhysicalHealthEducation_ExaminationScore { get; set; }

        [Display(Name = "Physical Health Education (Total Score)")]
        public decimal PhysicalHealthEducation_TotalScore { get; set; }


        //Mathematics
        [Display(Name = "Mathematics (Attendance)")]
        public int Mathematics_Attendance { get; set; }

        [Display(Name = "Mathematics (Continuous Assessment)")]
        public decimal Mathematics_ContinuousAssessment { get; set; }

        [Display(Name = "Mathematics (Examination Score)")]
        public decimal Mathematics_ExaminationScore { get; set; }

        [Display(Name = "Mathematics (Total Score)")]
        public decimal Mathematics_TotalScore { get; set; }



        //Further Mathematics
        [Display(Name = "Further Mathematics (Attendance)")]
        public int FurtherMathematics_Attendance { get; set; }

        [Display(Name = "FurtherMathematics (Continuous Assessment)")]
        public decimal FurtherMathematics_ContinuousAssessment { get; set; }

        [Display(Name = "FurtherMathematics (Examination Score)")]
        public decimal FurtherMathematics_ExaminationScore { get; set; }

        [Display(Name = "Further Mathematics (Total Score)")]
        public decimal FurtherMathematics_TotalScore { get; set; }


      

        //Agricultural Science (Attendance)
        [Display(Name = "Agricultural Science (Attendance)")]
        public int AgriculturalScience_Attendance { get; set; }

        [Display(Name = "Agricultural Science (Continuous Assessment)")]
        public decimal AgriculturalScience_ContinuousAssessment { get; set; }

        [Display(Name = "Agricultural Science (Examination Score)")]
        public decimal AgriculturalScience_ExaminationScore { get; set; }

        [Display(Name = "Agricultural Science (Total Score)")]
        public decimal AgriculturalScience_TotalScore { get; set; }


       


        //Food and Nutrition (Attendance)
        [Display(Name = "Food and Nutrition (Attendance)")]
        public int FoodandNutrition_Attendance { get; set; }

        [Display(Name = "Food and Nutrition (Continuous Assessment)")]
        public decimal FoodandNutrition_ContinuousAssessment { get; set; }

        [Display(Name = "Food and Nutrition (Examination Score)")]
        public decimal FoodandNutrition_ExaminationScore { get; set; }

        [Display(Name = "Food and Nutrition (Total Score)")]
        public decimal FoodandNutrition_TotalScore { get; set; }


        //Technical Drawing (Attendance)
        [Display(Name = "Technical Drawing (Attendance)")]
        public int TechnicalDrawing_Attendance { get; set; }

        [Display(Name = "Technical Drawing (Continuous Assessment)")]
        public decimal TechnicalDrawing_ContinuousAssessment { get; set; }

        [Display(Name = "Technical Drawing (Examination Score)")]
        public decimal TechnicalDrawing_ExaminationScore { get; set; }

        [Display(Name = "Technical Drawing (Total Score)")]
        public decimal TechnicalDrawing_TotalScore { get; set; }


        //Visual Art  (Attendance)
        [Display(Name = "Visua lArt (Attendance)")]
        public int VisualArt_Attendance { get; set; }

        [Display(Name = "Visual Art (Continuous Assessment)")]
        public decimal VisualArt_ContinuousAssessment { get; set; }

        [Display(Name = "Visual Art (Examination Score)")]
        public decimal VisualArt_ExaminationScore { get; set; }

        [Display(Name = "Visual Art (Total Score)")]
        public decimal VisualArt_TotalScore { get; set; }


        //Home Economics  (Attendance)
        [Display(Name = "Home Economics (Attendance)")]
        public int HomeEconomics_Attendance { get; set; }

        [Display(Name = "Home Economics (Continuous Assessment)")]
        public decimal HomeEconomics_ContinuousAssessment { get; set; }

        [Display(Name = "Home Economics (Examination Score)")]
        public decimal HomeEconomics_ExaminationScore { get; set; }

        [Display(Name = "Home Economics (Total Score)")]
        public decimal HomeEconomics_TotalScore { get; set; }


        //Music  (Attendance)
        [Display(Name = "Music (Attendance)")]
        public int Music_Attendance { get; set; }

        [Display(Name = "Music (Continuous Assessment)")]
        public decimal Music_ContinuousAssessment { get; set; }

        [Display(Name = "Music (Examination Score)")]
        public decimal Music_ExaminationScore { get; set; }

        [Display(Name = "Music (Total Score)")]
        public decimal Music_TotalScore { get; set; }




        //Economics  
        [Display(Name = "Economics (Attendance)")]
        public int Economics_Attendance { get; set; }

        [Display(Name = "Economics (Continuous Assessment)")]
        public decimal Economics_ContinuousAssessment { get; set; }

        [Display(Name = "Economics (Examination Score)")]
        public decimal Economics_ExaminationScore { get; set; }

        [Display(Name = "Economics (Total Score)")]
        public decimal Economics_TotalScore { get; set; }



        //Geography   
        [Display(Name = "Geography  (Attendance)")]
        public int Geography_Attendance { get; set; }

        [Display(Name = "Geography  (Continuous Assessment)")]
        public decimal Geography_ContinuousAssessment { get; set; }

        [Display(Name = "Geography  (Examination Score)")]
        public decimal Geography_ExaminationScore { get; set; }

        [Display(Name = "Geography (Total Score)")]
        public decimal Geography_TotalScore { get; set; }


        //Financial Accounting   
        [Display(Name = "Financial Accounting (Attendance)")]
        public int FinancialAccounting_Attendance { get; set; }

        [Display(Name = "Financial Accounting  (Continuous Assessment)")]
        public decimal FinancialAccounting_ContinuousAssessment { get; set; }

        [Display(Name = "Financial Accounting  (Examination Score)")]
        public decimal FinancialAccounting_ExaminationScore { get; set; }

        [Display(Name = "Financial Accounting (Total Score)")]
        public decimal FinancialAccounting_TotalScore { get; set; }



        //History 
        [Display(Name = "History (Attendance)")]
        public int History_Attendance { get; set; }

        [Display(Name = "History  (Continuous Assessment)")]
        public decimal History_ContinuousAssessment { get; set; }

        [Display(Name = "History  (Examination Score)")]
        public decimal History_ExaminationScore { get; set; }

        [Display(Name = "History (Total Score)")]
        public decimal History_TotalScore { get; set; }



        //Business Studies
        [Display(Name = "Business Studies (Attendance)")]
        public int BusinessStudies_Attendance { get; set; }

        [Display(Name = "Business Studies  (Continuous Assessment)")]
        public decimal BusinessStudies_ContinuousAssessment { get; set; }

        [Display(Name = "Business Studies  (Examination Score)")]
        public decimal BusinessStudies_ExaminationScore { get; set; }

        [Display(Name = "Business Studies (Total Score)")]
        public decimal BusinessStudies_TotalScore { get; set; }


        //Social Studies
        [Display(Name = "Social Studies (Attendance)")]
        public int SocialStudies_Attendance { get; set; }

        [Display(Name = "Social Studies  (Continuous Assessment)")]
        public decimal SocialStudies_ContinuousAssessment { get; set; }

        [Display(Name = "Social Studies  (Examination Score)")]
        public decimal SocialStudies_ExaminationScore { get; set; }

        [Display(Name = "Social Studies (Total Score)")]
        public decimal SocialStudies_TotalScore { get; set; }



        //Commerce
        [Display(Name = "Commerce(Attendance)")]
        public int Commerce_Attendance { get; set; }

        [Display(Name = "Commerce (Continuous Assessment)")]
        public decimal Commerce_ContinuousAssessment { get; set; }

        [Display(Name = "Commerce (Examination Score)")]
        public decimal Commerce_ExaminationScore { get; set; }

        [Display(Name = "Commerce (Total Score)")]
        public decimal Commerce_TotalScore { get; set; }



        //Commerce
        [Display(Name = "Government(Attendance)")]
        public int Government_Attendance { get; set; }

        [Display(Name = "Government (Continuous Assessment)")]
        public decimal Government_ContinuousAssessment { get; set; }

        [Display(Name = "Government (Examination Score)")]
        public decimal Government_ExaminationScore { get; set; }

        [Display(Name = "Government (Total Score)")]
        public decimal Government_TotalScore { get; set; }



        //Christian Religious Knowledge
        [Display(Name = "Christian Religious Knowledge(Attendance)")]
        public int ChristianReligiousKnowledge_Attendance { get; set; }

        [Display(Name = "Christian Religious Knowledge (Continuous Assessment)")]
        public decimal ChristianReligiousKnowledge_ContinuousAssessment { get; set; }

        [Display(Name = "Christian Religious Knowledge (Examination Score)")]
        public decimal ChristianReligiousKnowledge_ExaminationScore { get; set; }

        [Display(Name = "Christian Religious Knowledge (Total Score)")]
        public decimal ChristianReligiousKnowledge_TotalScore { get; set; }



        //Commerce
        [Display(Name = "Islamic Religious Knowledge(Attendance)")]
        public int IslamicReligiousKnowledge_Attendance { get; set; }

        [Display(Name = "Islamic Religious Knowledge (Continuous Assessment)")]
        public decimal IslamicReligiousKnowledge_ContinuousAssessment { get; set; }

        [Display(Name = "Islamic Religious Knowledge (Examination Score)")]
        public decimal IslamicReligiousKnowledge_ExaminationScore { get; set; }

        [Display(Name = "Islamic Religious Knowledge (Total Score)")]
        public decimal IslamicReligiousKnowledge_TotalScore { get; set; }




        //Royal English
        [Display(Name = "Royal English(Attendance)")]
        public int RoyalEnglish_Attendance { get; set; }

        [Display(Name = "Royal English (Continuous Assessment)")]
        public decimal RoyalEnglish_ContinuousAssessment { get; set; }

        [Display(Name = "Royal English (Examination Score)")]
        public decimal RoyalEnglish_ExaminationScore { get; set; }

        [Display(Name = "Royal English (Total Score)")]
        public decimal RoyalEnglish_TotalScore { get; set; }


        //Basic Science
        [Display(Name = "Basic Science(Attendance)")]
        public int BasicScience_Attendance { get; set; }

        [Display(Name = "Basic Science (Continuous Assessment)")]
        public decimal BasicScience_ContinuousAssessment { get; set; }

        [Display(Name = "Basic Science(Examination Score)")]
        public decimal BasicScience_ExaminationScore { get; set; }

        [Display(Name = "Basic Science (Total Score)")]
        public decimal BasicScience_TotalScore { get; set; }




        //Basic Technology
        [Display(Name = "Basic Technology(Attendance)")]
        public int BasicTechnology_Attendance { get; set; }

        [Display(Name = "Basic Technology(Continuous Assessment)")]
        public decimal BasicTechnology_ContinuousAssessment { get; set; }

        [Display(Name = "Basic Technology(Examination Score)")]
        public decimal BasicTechnology_ExaminationScore { get; set; }

        [Display(Name = "Basic Technology (Total Score)")]
        public decimal BasicTechnology_TotalScore { get; set; }



        ////Basic Technology
        //[Display(Name = "Basic Technology(Attendance)")]
        //public int BasicTechnology_Attendance { get; set; }

        //[Display(Name = "Basic Technology(Continuous Assessment)")]
        //public decimal BasicTechnology_ContinuousAssessment { get; set; }

        //[Display(Name = "Basic Technology(Examination Score)")]
        //public decimal BasicTechnology_ExaminationScore { get; set; }

        //[Display(Name = "Basic Technology (Total Score)")]
        //public decimal BasicTechnology_TotalScore { get; set; }



        //Civic Education
        [Display(Name = "Civic Education(Attendance)")]
        public int CivicEducation_Attendance { get; set; }

        [Display(Name = "Civic Education(Continuous Assessment)")]
        public decimal CivicEducation_ContinuousAssessment { get; set; }

        [Display(Name = "Civic Education(Examination Score)")]
        public decimal CivicEducation_ExaminationScore { get; set; }

        [Display(Name = "Civic Education(Total Score)")]
        public decimal CivicEducation_TotalScore { get; set; }




        //Creative Art 
        [Display(Name = "Creative Art(Attendance)")]
        public int CreativeArt_Attendance { get; set; }

        [Display(Name = "Creative Art(Continuous Assessment)")]
        public decimal CreativeArt_ContinuousAssessment { get; set; }

        [Display(Name = "Creative Art(Examination Score)")]
        public decimal CreativeArt_ExaminationScore { get; set; }

        [Display(Name = "Creative Art(Total Score)")]
        public decimal CreativeArt_TotalScore { get; set; }
    }
}
