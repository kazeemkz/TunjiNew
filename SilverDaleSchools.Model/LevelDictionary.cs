using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SilverDaleSchools.Model
{
    public class LevelDictionary
    {


        public static List<string> LevelDicoListforFees
        {
            get { return levelListDic; }
        }

        private static readonly List<string> levelListDic = new List<string> { "KG1", "KG2", "NURSERY 1", "NURSERY 2",
        "PRIMARY 1","PRIMARY 2","PRIMARY 3","PRIMARY 4","PRIMARY 5","PRIMARY 6", "JSS 1", "JSS 2", "JSS 3", "SSS 1", "SSS 2", "SSS 3"};
        //{ 
        // {"KG1"},
        //  {"KG2"},
        //  {"NURSERY 1"},
        //  {"NURSERY 2"},
        //  {"PRIMARY 1"},
        //  {"PRIMARY 2"},
        //  {"PRIMARY 3"},
        //  {"PRIMARY 4","PRIMARY 4"},
        //  {"PRIMARY 5","PRIMARY 5"},
        //  {"PRIMARY 6","PRIMARY 6"},

        //};

        // public static SelectList StudentActionList
        // {
        //     get { return new SelectList(StudentAction, "Value", "Key"); }
        // }

        // private static readonly IDictionary<string, string> StudentAction = new Dictionary<string, string> 

        //{ {"Choose",""},
        //  {"Left","True"},
        //  {"NO","False"},

        //};

        public static SelectList ClasssListAbuad
        {
            get { return new SelectList(ClasssAbuad, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> ClasssAbuad = new Dictionary<string, string> 
      
       { {"Choose",""},
         {"100 Level","100Level"},
           {"200 Level","200Level"},
             {"300 Level","300Level"},
               {"400 Level","400Level"},
                 {"500 Level","500Level"},
                 //  {"BASIC 12","BASIC 12"},
        // {"Senior Class","Senior Class"},
           //{"Owing","Owing"},
                     
       };



        public static SelectList ClasssListSilverDale
        {
            get { return new SelectList(ClasssSivler, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> ClasssSivler = new Dictionary<string, string> 
      
       { {"Choose",""},
         {"BASIC 7","BASIC 7"},
           {"BASIC 8","BASIC 8"},
             {"BASIC 9","BASIC 9"},
               {"BASIC 10","BASIC 10"},
                 {"BASIC 11","BASIC 11"},
                   {"BASIC 12","BASIC 12"},
        // {"Senior Class","Senior Class"},
           //{"Owing","Owing"},
                     
       };


        public static SelectList ClasssDescriptiontList
        {
            get { return new SelectList(ClasssDescription, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> ClasssDescription = new Dictionary<string, string> 
      
       { {"Choose",""},
         {"Junior Class","Junior Class"},
         {"Senior Class","Senior Class"},
           //{"Owing","Owing"},
                     
       };
        public static SelectList SchoolFeesPaymentList
        {
            get { return new SelectList(SchoolFeesPayment, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> SchoolFeesPayment = new Dictionary<string, string> 
      
       { {"Choose",""},
         {"YES","True"},
         {"NO","False"},
           {"Owing","Owing"},
                     
       };

        public static SelectList Approved
        {
            get { return new SelectList(ApprovedList2, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> ApprovedList2 = new Dictionary<string, string> 
      
       { {"Choose",""},
         {"YES","True"},
         {"NO","False"},
                     
       };


        public static SelectList LevelType
        {
            get { return new SelectList(LevelTypeList2, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> LevelTypeList2 = new Dictionary<string, string> 
      
       { {"A","A"},
         {"B","B"},
         {"C","C "},
         {"D","D"},
         {"E","E"},
       
           {"F","F"},
          {"G","G"},
         
           {"H","H"},
             
       };


        public static SelectList HourDicList
        {
            get { return new SelectList(HourDick, "Value", "Key"); }
        }



        public static readonly IDictionary<string, string> HourDick = new Dictionary<string, string> 
       {{"Choose..",""} ,
           {"7am","07"},
             {"8am","08"},
               {"9am","09"},
                 {"10am","10"},
                   {"11am","11"},
                     {"12pm","12"},
                       {"1pm","13"},
                         {"2pm","14"},
                           {"3pm","15"},
                             {"4pm","16"},
                               {"5pm","17"},
                                 {"6pm","18"},
                                   {"7pm","19"},
                                     {"8pm","20"},
                                       {"9pm","21"},
                                         {"10pm","22"},
                                           {"11pm","23"},
                                             {"12am","24"},
      
       };












        public static SelectList MinuteDickDicList
        {
            get { return new SelectList(MinuteDick, "Value", "Key"); }
        }



        public static readonly IDictionary<string, string> MinuteDick = new Dictionary<string, string> 
       {{"Choose..",""} ,
            {"00","00"},
           {"01","01"},
        {"02","02"},
         {"03","03"},
          {"04","04"},
        {"05","05"},
         {"06","06"},
           {"07","07"},
             {"08","08"},
               {"09","09"},
                 {"10","10"},
                   {"11","11"},
                     {"12","12"},
                       {"13","13"},
                         {"14","14"},
                           {"15","15"},
                             {"16","16"},
                               {"17","17"},
                                 {"18","18"},
                                   {"19","19"},
                                     {"20","20"},
                                       {"21","21"},
                                         {"22","22"},
                                           {"23","23"},
                                             {"24","24"},
                                              {"25","25"},
                                                {"26","26"},
            {"27","27"},
              {"28","28"},
               {"29","29"},
                {"30","30"},
                {"31","31"},
                {"32","32"},
                {"33","33"},
                {"34","34"},
                {"35","35"},
                {"36","36"},
                {"37","37"},
                {"38","38"},
                {"39","39"},
                {"40","40"},
                 {"41","41"},
                  {"42","42"},
                   {"43","43"},
                    {"44","44"},
                     {"45","45"},
                      {"46","46"},
                      {"47","47"},
                      {"48","48"},
                      {"49","49"},
                      {"50","50"},
                       {"51","51"},
                        {"52","52"},
                         {"53","53"},
                          {"54","54"},
                           {"55","55"},
                            {"56","56"},
                             {"57","57"},
                              {"58","58"},
                               {"59","59"},
                               
      
       };





        public static SelectList SessionList
        {
            get { return new SelectList(session, "Value", "Key"); }
        }



        public static readonly IDictionary<string, string> session = new Dictionary<string, string> 
       {{"Choose..",""} ,
           {"2013/2014","2013/2014"},
        {"2014/2015","2014/2015"},
         {"2015/2016","2015/2016"},
         {"2016/2017","2016/2017"},
         {"2017/2018","2017/2018"},
           {"2018/2019","2018/2019"},
             {"2019/2020","2019/2020"},
                {"2020/2021","2020/2021"},
                 {"2021/2022","2021/2022"},
                   {"2022/2023","2022/2023"},
                    {"2023/2024","2023/2024"},
        //{"SSS 2","SSS 2"},
        // {"SSS 3","SSS 3"},
      
       };




















        public static SelectList LevelDicoListWithStaff
        {
            get { return new SelectList(LevelDicStaff, "Value", "Key"); }
        }



        public static readonly IDictionary<string, string> LevelDicStaff = new Dictionary<string, string> 
       {{"Choose..",""} ,
           {"Staff","Staff"},
        {"JSS 1","JSS 1"},
         {"JSS 2","JSS 2"},
         {"JSS 3","JSS 3"},
         {"SSS 1","SSS 1"},
        {"SSS 2","SSS 2"},
         {"SSS 3","SSS 3"},
      
       };




        public static SelectList PrimarySecList
        {
            get { return new SelectList(PrimarySec, "Value", "Key"); }
        }



        public static readonly IDictionary<string, string> PrimarySec = new Dictionary<string, string> 
       {{"Choose..",""} ,
           {"Primary","Primary"},
        {"Secondary","Secondary"},
            
       };














        public static SelectList LevelDicoListWithoutNone1
        {
            get { return new SelectList(levelDic3, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> levelDic3 = new Dictionary<string, string> 
      
       { {"PKG","PKG"},
         {"KG","KG"},
         {"NURSERY 1","NURSERY 1"},
         {"NURSERY 2","NURSERY 2"},
         {"PRIMARY 1","PRIMARY 1"},
         {"PRIMARY 2","PRIMARY 2"},
         {"PRIMARY 3","PRIMARY 3"},
         {"PRIMARY 4","PRIMARY 4"},
         {"PRIMARY 5","PRIMARY 5"},
         {"PRIMARY 6","PRIMARY 6"},
           {"JSS 1","JSS 1"},
           {"JSS 2","JSS 2"},
            {"JSS 3","JSS 3"},
             {"SSS 1","SSS 1"},
              {"SSS 2","SSS 2"},
               {"SSS 3","SSS 3"},
             
       };


        public static SelectList LevelDicoList
        {
            get { return new SelectList(levelDic, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> levelDic = new Dictionary<string, string> 
       {{"None",""} ,
         {"PKG","PKG"},
         {"KG","KG"},
         {"NURSERY 1","NURSERY 1"},
         {"NURSERY 2","NURSERY 2"},
         {"PRIMARY 1","PRIMARY 1"},
         {"PRIMARY 2","PRIMARY 2"},
         {"PRIMARY 3","PRIMARY 3"},
         {"PRIMARY 4","PRIMARY 4"},
         {"PRIMARY 5","PRIMARY 5"},
         {"PRIMARY 6","PRIMARY 6"},
           {"JSS 1","JSS 1"},
           {"JSS 2","JSS 2"},
            {"JSS 3","JSS 3"},
             {"SSS 1","SSS 1"},
              {"SSS 2","SSS 2"},
               {"SSS 3","SSS 3"},
                //{"Graduated","Graduated"},
                //{"Withdraw","Withdraw"},
                //  {"Left","Left"},
             
       };



        public static SelectList LevelDicoListAllStudent
        {
            get { return new SelectList(levelDicAllStudent, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> levelDicAllStudent = new Dictionary<string, string> 
       {{"None",""} ,
        {"All Students","All Students"},
         {"All Staff","All Staff"},
         {"PKG","PKG"},
         {"KG","KG"},
         {"NURSERY 1","NURSERY 1"},
         {"NURSERY 2","NURSERY 2"},
         {"PRIMARY 1","PRIMARY 1"},
         {"PRIMARY 2","PRIMARY 2"},
         {"PRIMARY 3","PRIMARY 3"},
         {"PRIMARY 4","PRIMARY 4"},
         {"PRIMARY 5","PRIMARY 5"},
         {"PRIMARY 6","PRIMARY 6"},
           {"JSS 1","JSS 1"},
           {"JSS 2","JSS 2"},
            {"JSS 3","JSS 3"},
             {"SSS 1","SSS 1"},
              {"SSS 2","SSS 2"},
               {"SSS 3","SSS 3"},

                 //theItem.Add(new SelectListItem() { Text = "All Students", Value = "AllStudents" });
         //   theItem.Add(new SelectListItem() { Text = "All Staff", Value = "All Staff" });
                //{"Graduated","Graduated"},
                //{"Withdraw","Withdraw"},
                //  {"Left","Left"},
             
       };

        public static SelectList LevelDicoListWithoutNone
        {
            get { return new SelectList(levelDic2, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> levelDic2 = new Dictionary<string, string> 
       {{"Choose",""} ,
         {"PKG","PKG"},
         {"KG","KG"},
         {"NURSERY 1","NURSERY 1"},
         {"NURSERY 2","NURSERY 2"},
         {"PRIMARY 1","PRIMARY 1"},
         {"PRIMARY 2","PRIMARY 2"},
         {"PRIMARY 3","PRIMARY 3"},
         {"PRIMARY 4","PRIMARY 4"},
         {"PRIMARY 5","PRIMARY 5"},
         {"PRIMARY 6","PRIMARY 6"},
           {"JSS 1","JSS 1"},
           {"JSS 2","JSS 2"},
            {"JSS 3","JSS 3"},
             {"SSS 1","SSS 1"},
              {"SSS 2","SSS 2"},
               {"SSS 3","SSS 3"},
             
       };


        public static SelectList Genotype
        {
            get { return new SelectList(GenotypeList, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> GenotypeList = new Dictionary<string, string> 
         {{"Dont want to Disclose",""},
        {"AA","AA"},
         {"AS","AS"},
         {"SS","SS"},
       
                   
       };


        public static SelectList LevelOfPaticipation
        {
            get { return new SelectList(LevelOfPaticipationList, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> LevelOfPaticipationList = new Dictionary<string, string> 
         {{"Choose..",""},
         {"Poor","Poor"},
             {"Fair","Fair"},
        {"Good","Good"},
         {"Very Good","Very Good"},
         {"Excellent","Excellent"},
       
                   
       };


        public static SelectList Qualifications
        {
            get { return new SelectList(QualificationsList, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> QualificationsList = new Dictionary<string, string> 
         { {"Not Applicable","Not Applicable"},
         {"Professor","Professor"},
        {"PhD","PhD"},
         {"MSc","MSc"},
          {"M.Ed","M.Ed"},
         {"BSc","BSc"},
          {"B.Ed","B.Ed"},
           {"B.TECH","B.TECH"},
            {"B.ENG","B.ENG"},
              {"OND","OND"},
               {"HND","HND"},
                 {"NCE","NCE"},
                  {"WAEC","WAEC"},
              {"NECO","NECO"},
                  {"Technical Sch. Cert.","Technical Sch. Cert."},
                {"Primary Sch. Cert.","Primary Sch. Cert."},
                 

       
                   
       };


        public static SelectList TermYearList
        {
            get { return new SelectList(TermYear, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> TermYear = new Dictionary<string, string> 
         {{"Choose",""},
         {"2013","2013"},
        {"2014","2014"},
        {"2015","2015"},
         {"2016","2016"},
          {"2017","2017"},
           {"2018","2018"},
            {"2019","2019"},
               {"2020","2020"},
                {"2021","2021"},
                 {"2022","2022"},
                  {"2023","2023"},
                   {"2024","2024"},
                    {"2025","2025"},
                     {"2026","2026"},
                      {"2027","2027"},
                       {"2028","2028"},
                        {"2029","2029"},
                          {"2030","2030"},
                           {"2031","2031"},
                            {"2032","2032"},
                             {"2033","2033"},
                              {"2034","2034"},
                               {"2035","2035"},
                               {"2036","2036"},
                             {"2037","2037"},
                            {"2038","2038"},
                            {"2039","2039"},
                              {"2040","2040"},
                   
       };


        public static SelectList TermWithNullRegistration
        {
            get { return new SelectList(TermListNullRegistration, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> TermListNullRegistration = new Dictionary<string, string> 
         {{"Choose",""},
         {"FIRST","First"},
        {"SECOND","Second"},
         {"THIRD","Third"},      
                   
       };



        public static SelectList TermWithNull
        {
            get { return new SelectList(TermListNull, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> TermListNull = new Dictionary<string, string> 
         {{"Choose",""},
         {"FIRST","1"},
        {"SECOND","2"},
         {"THIRD","3"},      
                   
       };


        public static SelectList TestType
        {
            get { return new SelectList(Test, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> Test = new Dictionary<string, string> 
         {{"Choose",""},
         {"EXAM","Exam"},
        {"TEST 1","TEST 1"},
         {"TEST 2","TEST 2"},    
          {"QUIZ","Practise"}, 
            {"QUIZ-RECORD","PractiseRecord"}, 
                   
       };

        public static SelectList Term
        {
            get { return new SelectList(TermList, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> TermList = new Dictionary<string, string> 
         {{"FIRST","1"},
        {"SECOND","2"},
         {"THIRD","3"},      
                   
       };


        public static SelectList BloodGroup
        {
            get { return new SelectList(BloodGroupList, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> BloodGroupList = new Dictionary<string, string> 
      {{"Dont want to Disclose",""},
        {"A","A"},
         {"B","B"},
         {"AB","AB"},
         {"O ","O"},
                   
       };

        public static SelectList DayList
        {
            get { return new SelectList(DayDic, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> DayDic = new Dictionary<string, string> 
     
        {{"NONE",""},
        {"SUNDAY","SUNDAY"},
         {"MONDAY","MONDAY"},
         {"TUESDAY","TUESDAY"},
         {"WEDNESDAY ","WEDNESDAY"},
           {"THURSDAY","THURSDAY"},
             {"FRIDAY","FRIDAY"},
               {"SATURDAY","SATURDAY"},
                   
       };


        public static SelectList HairColor
        {
            get { return new SelectList(HairColorList, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> HairColorList = new Dictionary<string, string> 
     
        {{"BLACK","BLACK"},
         {"WHITE","WHITE"},
         {"BROWN","BROWN"},
         {"RED ","RED"},
                   
       };


        public static SelectList PositioninFamily
        {
            get { return new SelectList(PositioninFamilyList, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> PositioninFamilyList = new Dictionary<string, string> 
      {{"0","0"},
        {"1","1"},
         {"2","2"},
         {"3","3"},
         {"4","4"},
            {"5","5"},
               {"6","6"},
                  {"7","7"},
                  {"8","8"},
                  {"9","9"},
                  {"10","10"},
                  {"11","11"},
                  {"12","12"},
                  {"13","13"},
                  {"14","14"},
                  {"15","15"},
                  {"16","16"},
                  {"17","17"},
                  {"18","18"},
                  {"19","19"},
                  {"20","20"},
                   {"21","21"},
                    {"22","22"},
                     {"23","23"},
                      {"24","24"},
                    {"25","25"},
                     {"26","26"},
                      {"27","27"},
                       {"28","28"},
                        {"29","29"},
                         {"30","30"},
       };


        public static SelectList LevelTypeList
        {
            get { return new SelectList(LevelTypeDic, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> LevelTypeDic = new Dictionary<string, string> 
       {{"Choose..",""} ,
        {"A","A"},
        {"B","B"} ,
         {"C","C"},
         {"D","D"},
         {"E","E"},
         {"F","F"},
         {"G","G"},
         {"H","H"},
         {"I","I"},
         {"J","J"},
         {"K","K"},
         {"L","L"},
         {"M","M"},
         {"O","O"},
         {"P","P"},
         {"Q","Q"},
         {"R","R"},
         {"S","S"},
         {"T","T"},
         {"U","U"},
         {"V","V"},
         {"W","W"},
         {"X","X"},
         {"Y","Y"},
         {"Z","Z"},
         
             
       };



        public static SelectList Visible
        {
            get { return new SelectList(VisibleList, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> VisibleList = new Dictionary<string, string> 
            {{"Choose..",""} ,
         {"True","True"},
        {"False","False"},
        
                   
       };


        public static SelectList HasQuestionImage
        {
            get { return new SelectList(HasQuestionImageList, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> HasQuestionImageList = new Dictionary<string, string> 
            {  {"False","false"},
         {"True","true"},
      
        
                   
       };






    }
}
