using SilverDaleSchools.DAL;
using SilverDaleSchools.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SilverDaleSchools.Models
{
    public static class TimeTableCollisionAviodance
    {

        public static string CheckDaySlotAvialability(string levels)
        {
            //var theValue = $('#Subject').val() + ";" + $('#Class').val() + ";" + $('#StratTimeHour').val() + ";" + $('#StratTimeMinute').val() + ";" + $('#Teacher').val() + ";" + $('#Day').val();
            string[] theLEvel = levels.Split(';');
            string subject = theLEvel[0];
            string level = theLEvel[1];
            string StartHourclinet = theLEvel[2];
            string StartMinuteclinet = theLEvel[3];
            string day1 = theLEvel[5];
            //  string day1 = theLEvel[5];
            Day day = DayHelper.GetDay(day1);
            sdContext db = new sdContext();


            List<TeachingDay> theTeachingDay = db.TeachingDay.Include("TeachingSubject").Where(a => a.TeachingClass.ClassName == level && a.theDay == day).ToList();
            foreach (TeachingDay td in theTeachingDay)
            {
                string theClass = td.TeachingClass.ClassName;
                foreach (TeachingSubject ts in td.TeachingSubject)
                {
                    String Day = ts.TeachingDay.theDay.ToString();
                    string theSubject = ts.SubjectName;
                    string EndHour = ts.TeachingDay.EndTimeHour;
                    string EndMinutes = ts.TeachingDay.EndTimeMinute;

                    string StartHour = ts.TeachingDay.StratTimeHour;
                    string StartMinutes = ts.TeachingDay.StratTimeMinute;

                    StringBuilder EndHourEndMinutes = new StringBuilder();

                    EndHourEndMinutes.Append(EndHour);
                    EndHourEndMinutes.Append(EndMinutes);


                    int time = Convert.ToInt16(EndHourEndMinutes.ToString()); //= Convert.ToInt16(EndHour) + Convert.ToInt16(EndMinutes);
                    StringBuilder StartHourStartMinuteclinets = new StringBuilder();
                    StartHourStartMinuteclinets.Append(StartHourclinet).Append(StartMinuteclinet);
                    int timeClient = Convert.ToInt16(StartHourStartMinuteclinets.ToString());//Convert.ToInt16(StartHourclinet) + Convert.ToInt16(StartMinuteclinet);

                    if (timeClient < time)
                    {
                        string theAlert = theSubject + "  has been fixed  for " + theClass + " which starts " + StartHour + ":" + StartMinutes + " ends at " + EndHour + ":" + EndMinutes;
                        return theAlert;

                    }
                }

            }


            return "";
        }

        public static string CheckSubjectSlotAvialability(string levels)
        {
            string[] theLEvel = levels.Split(';');
            string subject = theLEvel[0];
            string level = theLEvel[1];
            string StartHourclinet = theLEvel[2];
            string StartMinuteclinet = theLEvel[3];
            string day1 = theLEvel[4];
            //  string day1 = theLEvel[5];
            Day day = DayHelper.GetDay(day1);
            sdContext db = new sdContext();

            // db.TeachingClass.Include("TheTeachingDay").Where(a => a.ClassName == level).ToList();

            //  List<TeachingSubject> theTeachingSubject = work.TeachingSubjectRepository.Get().ToList();
            List<TeachingClass> theTeachingClass = db.TeachingClass.Include("TheTeachingDay").Where(a => a.ClassName == level).ToList(); //work.TeachingClassRepository.Get(a => a.ClassName == level).ToList();
            foreach (TeachingClass c in theTeachingClass)
            {

                //  foreach (TeachingDay td in c.TheTeachingDay)
                // {
                List<TeachingDay> theTeachingDay = db.TeachingDay.Include("TeachingSubject").Where(a => a.TeachingClass.TeachingClassID == c.TeachingClassID && a.theDay == day).ToList();

                foreach (TeachingDay td in theTeachingDay)
                {
                    foreach (TeachingSubject ts in td.TeachingSubject)
                    {
                        String Day = ts.TeachingDay.theDay.ToString();
                        string theSubject = ts.SubjectName;
                        string EndHour = ts.TeachingDay.EndTimeHour;
                        string EndMinutes = ts.TeachingDay.EndTimeMinute;

                        string StartHour = ts.TeachingDay.StratTimeHour;
                        string StartMinutes = ts.TeachingDay.StratTimeMinute;

                        StringBuilder EndHourEndMinutes = new StringBuilder();

                        EndHourEndMinutes.Append(EndHour);
                        EndHourEndMinutes.Append(EndMinutes);


                        int time = Convert.ToInt16(EndHourEndMinutes.ToString()); //= Convert.ToInt16(EndHour) + Convert.ToInt16(EndMinutes);
                        StringBuilder StartHourStartMinuteclinets = new StringBuilder();
                        StartHourStartMinuteclinets.Append(StartHourclinet).Append(StartMinuteclinet);
                        int timeClient = Convert.ToInt16(StartHourStartMinuteclinets.ToString());//Conve

                        if (theSubject == subject && timeClient < time)
                        {
                            string theAlert = theSubject + " " + "has been fixed  for this class and which ends at " + EndHour + ":" + EndMinutes;
                            return theAlert;
                        }
                    }




                }

            }


            return "";
        }

        public static string CheckStaffSlotAvialability(string levels)
        {
            string[] theLEvel = levels.Split(';');
            string subject = theLEvel[0];
            string level = theLEvel[1];
            string StartHourclinet = theLEvel[2];
            string StartMinuteclinet = theLEvel[3];
            string teacher = theLEvel[4];
            string day1 = theLEvel[5];
            Day day = DayHelper.GetDay(day1);
            sdContext db = new sdContext();

            List<Teacher> Teacher = db.Teacher.Include("TheTeachingClass").Where(a => a.TeacherName == teacher).ToList();
            foreach (Teacher t in Teacher)
            {

                //  List<TeachingSubject> theTeachingSubject = work.TeachingSubjectRepository.Get().ToList();
                // List<TeachingClass> theTeachingClass = db.TeachingClass.Include("TheTeachingDay").Where(a => a.ClassName == level && a.Teacher.TeacherID == t.TeacherID).ToList(); //work.TeachingClassRepository.Get(a => a.ClassName == level).ToList();
                List<TeachingClass> theTeachingClass = db.TeachingClass.Include("TheTeachingDay").Where(a => a.Teacher.TeacherID == t.TeacherID).ToList(); //work.TeachingClassRepository.Get(a => a.ClassName == level).ToList();
                foreach (TeachingClass c in theTeachingClass)
                {
                    string ClassName = c.ClassName;
                    //  foreach (TeachingDay td in c.TheTeachingDay)
                    // {
                    List<TeachingDay> theTeachingDay = db.TeachingDay.Include("TeachingSubject").Where(a => a.TeachingClass.TeachingClassID == c.TeachingClassID && a.theDay == day).ToList();

                    foreach (TeachingDay td in theTeachingDay)
                    {
                        foreach (TeachingSubject ts in td.TeachingSubject)
                        {
                            String Day = ts.TeachingDay.theDay.ToString();
                            string theSubject = ts.SubjectName;
                            string EndHour = ts.TeachingDay.EndTimeHour;
                            string EndMinutes = ts.TeachingDay.EndTimeMinute;

                            string StartHour = ts.TeachingDay.StratTimeHour;
                            string StartMinutes = ts.TeachingDay.StratTimeMinute;

                            StringBuilder EndHourEndMinutes = new StringBuilder();

                            EndHourEndMinutes.Append(EndHour);
                            EndHourEndMinutes.Append(EndMinutes);


                            int time = Convert.ToInt16(EndHourEndMinutes.ToString()); //= Convert.ToInt16(EndHour) + Convert.ToInt16(EndMinutes);
                            StringBuilder StartHourStartMinuteclinets = new StringBuilder();
                            StartHourStartMinuteclinets.Append(StartHourclinet).Append(StartMinuteclinet);
                            int timeClient = Convert.ToInt16(StartHourStartMinuteclinets.ToString());//Conve

                            if (theSubject == subject && timeClient < time)
                            {
                                string theAlert = theSubject + " " + "has been fixed  for " + teacher + " on " + Day + " for class " + ClassName + " which starts at " + StartHour + ":" + StartMinutes + " and which ends at " + EndHour + ":" + EndMinutes;
                                return theAlert;
                            }

                            if (theSubject != subject && timeClient < time)
                            {
                                string theAlert = theSubject + " " + "has been fixed  for " + teacher + " on " + Day + " for class " + ClassName + " which starts at " + StartHour + ":" + StartMinutes + " and which ends at " + EndHour + ":" + EndMinutes;
                                // string theAlert = teacher + " " + "has been fixed  for this day and ends " + EndHour + ":" + EndMinutes;
                                return theAlert;
                            }
                        }




                    }

                }
            }


            return "";
        }


        public static List<List<TimeTable>> DisplayTimeTable(string levels)
        {
            List<TimeTable> timeTable = new List<TimeTable>();

            List<List<TimeTable>> timeTableOverAll = new List<List<TimeTable>>();
            string level = levels;

            sdContext db = new sdContext();

            // List<Teacher> Teacher = db.Teacher.Include("TheTeachingClass").ToList();
            //  foreach (Teacher t in Teacher)
            // {
            // List<TeachingClass> theTeachingClass = db.TeachingClass.Include("TheTeachingDay").Where(a =>a.ClassName == level).ToList(); //work.TeachingClassRepository.Get(a => a.ClassName == level).ToList();
            //List<TeachingClass> theTeachingClass = db.TeachingClass.Include("TheTeachingDay").Where(a=> a.ClassName == level).ToList(); //work.TeachingClassRepository.Get(a => a.ClassName == level).ToList();
            //foreach (TeachingClass c in theTeachingClass)
            //{

            // string theTeacherName = c.Teacher.TeacherName;
            // string ClassName = c.ClassName;
            Day theDay = Day.SUNDAY;

            int counter = 0;
            for (int k = 0; k < 7; k++)
            {

                if (counter == 0)
                {
                    theDay = Day.SUNDAY;
                }

                if (counter == 1)
                {
                    theDay = Day.MONDAY;
                }
                if (counter == 2)
                {
                    theDay = Day.TUESDAY;
                }

                if (counter == 3)
                {
                    theDay = Day.WEDNESDAY;
                }

                if (counter == 4)
                {
                    theDay = Day.THURSDAY;
                }

                if (counter == 5)
                {
                    theDay = Day.FRIDAY;
                }

                if (counter == 6)
                {
                    theDay = Day.SATURDAY;
                }

                //   List<TeachingDay> theTeachingDay = db.TeachingDay.Include("TeachingSubject").Where(a => a.TeachingClass.TeachingClassID == c.TeachingClassID && a.theDay == theDay).OrderBy(a => a.StratTimeHour).ToList();


                List<TeachingDay> theTeachingDay = db.TeachingDay.Include("TeachingSubject").Where(a => a.TeachingClass.ClassName == level && a.theDay == theDay).OrderBy(a => a.StratTimeHour).ToList();
                foreach (TeachingDay td in theTeachingDay)
                {

                    foreach (TeachingSubject ts in td.TeachingSubject)
                    {

                        TimeTable tt = new TimeTable();
                        tt.Day = theDay.ToString();
                        //  if (ts.TeachingDay.TeachingClass != null)
                        //  {
                        int theTeachingClassID = ts.TeachingDay.TeachingClassID;
                        List<TeachingClass> theTeachingClass = db.TeachingClass.Where(a => a.TeachingClassID == theTeachingClassID).ToList();
                        string[] theSplitedName = null;
                        if (theTeachingClass.Count > 0)
                        {
                            int teacherID = theTeachingClass[0].TeacherID;
                            List<Teacher> theTeacher = db.Teacher.Where(a => a.TeacherID == teacherID).ToList();
                            theSplitedName = theTeacher[0].TeacherName.Split(' ');
                        }
                        // = ts.TeachingDay.TeachingClass.Teacher.TeacherName.Split(' ');// theTeacherName;
                        tt.Subject = Truncate(ts.SubjectName, 21);
                        if (theSplitedName.Count() >= 2)
                        {
                            tt.Teacher = theSplitedName[0] + " " + theSplitedName[2];

                            tt.Teacher = Truncate(tt.Teacher, 16);
                            // tt.Teacher = tt.Teacher.Truncate();
                        }
                        if (theSplitedName.Count() < 2)
                        {
                            tt.Teacher = theSplitedName[0] + " " + theSplitedName[2];

                            tt.Teacher = Truncate(tt.Teacher, 16);
                        }
                        //ts.TeachingDay.TeachingClass.Teacher.TeacherName;// theTeacherName;
                        tt.StratTimeHour = ts.TeachingDay.StratTimeHour + ":" + ts.TeachingDay.StratTimeMinute;
                        tt.EndTimeHour = ts.TeachingDay.EndTimeHour + ":" + ts.TeachingDay.EndTimeMinute;
                        tt.TeachingSubjectID = ts.TeachingSubjectID;
                        timeTable.Add(tt);
                        // }

                    }

                }
                if (timeTable.Count() != 0)
                {

                    timeTableOverAll.Add(timeTable);
                    timeTable = new List<TimeTable>();
                }
                counter = counter + 1;

            }

            //         break;
            //     }
            //// }


            return timeTableOverAll;
        }

        public static List<List<TimeTable>> DisplayTimeTableCustomisedForStaff(int personID)
        {
            List<TimeTable> timeTable = new List<TimeTable>();

            List<List<TimeTable>> timeTableOverAll = new List<List<TimeTable>>();
            int thePersonID = Convert.ToInt16(personID);

            sdContext db = new sdContext();

            // List<Teacher> Teacher = db.Teacher.Include("TheTeachingClass").ToList();
            //  foreach (Teacher t in Teacher)
            // {
            // List<TeachingClass> theTeachingClass = db.TeachingClass.Include("TheTeachingDay").Where(a =>a.ClassName == level).ToList(); //work.TeachingClassRepository.Get(a => a.ClassName == level).ToList();
            //List<TeachingClass> theTeachingClass = db.TeachingClass.Include("TheTeachingDay").Where(a=> a.ClassName == level).ToList(); //work.TeachingClassRepository.Get(a => a.ClassName == level).ToList();
            //foreach (TeachingClass c in theTeachingClass)
            //{

            // string theTeacherName = c.Teacher.TeacherName;
            // string ClassName = c.ClassName;
            Day theDay = Day.SUNDAY;

            int counter = 0;
            for (int k = 0; k < 7; k++)
            {

                if (counter == 0)
                {
                    theDay = Day.SUNDAY;
                }

                if (counter == 1)
                {
                    theDay = Day.MONDAY;
                }
                if (counter == 2)
                {
                    theDay = Day.TUESDAY;
                }

                if (counter == 3)
                {
                    theDay = Day.WEDNESDAY;
                }

                if (counter == 4)
                {
                    theDay = Day.THURSDAY;
                }

                if (counter == 5)
                {
                    theDay = Day.FRIDAY;
                }

                if (counter == 6)
                {
                    theDay = Day.SATURDAY;
                }

                //   List<TeachingDay> theTeachingDay = db.TeachingDay.Include("TeachingSubject").Where(a => a.TeachingClass.TeachingClassID == c.TeachingClassID && a.theDay == theDay).OrderBy(a => a.StratTimeHour).ToList();


                List<TeachingDay> theTeachingDay = db.TeachingDay.Include("TeachingSubject").Where(a => a.TeachingClass.Teacher.ThePersonID == thePersonID && a.theDay == theDay).OrderBy(a => a.StratTimeHour).ToList();
                foreach (TeachingDay td in theTeachingDay)
                {

                    foreach (TeachingSubject ts in td.TeachingSubject)
                    {

                        TimeTable tt = new TimeTable();
                        tt.Day = theDay.ToString();
                        tt.Class = ts.TeachingDay.TeachingClass.ClassName;
                        string[] theSplitedName = ts.TeachingDay.TeachingClass.Teacher.TeacherName.Split(' ');// theTeacherName;
                        tt.Subject = Truncate(ts.SubjectName, 21);
                        if (theSplitedName.Count() >= 2)
                        {
                            tt.Teacher = theSplitedName[0] + " " + theSplitedName[2];

                            tt.Teacher = Truncate(tt.Teacher, 16);
                            // tt.Teacher = tt.Teacher.Truncate();
                        }
                        if (theSplitedName.Count() < 2)
                        {
                            tt.Teacher = theSplitedName[0] + " " + theSplitedName[2];

                            tt.Teacher = Truncate(tt.Teacher, 16);
                        }
                        //ts.TeachingDay.TeachingClass.Teacher.TeacherName;// theTeacherName;
                        tt.StratTimeHour = ts.TeachingDay.StratTimeHour + ":" + ts.TeachingDay.StratTimeMinute;
                        tt.EndTimeHour = ts.TeachingDay.EndTimeHour + ":" + ts.TeachingDay.EndTimeMinute;

                        timeTable.Add(tt);

                    }

                }
                if (timeTable.Count() != 0)
                {

                    timeTableOverAll.Add(timeTable);
                    timeTable = new List<TimeTable>();
                }
                counter = counter + 1;

            }

            //         break;
            //     }
            //// }


            return timeTableOverAll;
        }

        public static string Truncate(string input, int length)
        {
            string inputv = input;
            if (input.Length <= length)
            {
                return inputv;
            }
            else
            {
                inputv = input.Substring(0, length);
                inputv = inputv + "..";
                return inputv;
            }
        }


    }


}