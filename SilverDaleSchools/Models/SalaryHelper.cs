using JobHustler.DAL;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class SalaryHelper
    {
        UnitOfWork work = new UnitOfWork();
        public SalaryPaymentHistory Loan(SalaryPaymentHistory model)
        {

            List<Loan> theLoan = new List<Model.Loan>();
            PrimarySchoolStaff theStaff = work.PrimarySchoolStaffRepository.Get(a => a.UserID == model.StaffID).First();
            theLoan = work.LoanRepository.Get(a => a.StaffID == model.StaffID).ToList();
            // theLoan[0].
            model.TheLoan = theLoan;
            model.TotalLoan = 0;
            if (theLoan.Count > 0)
            {
                foreach (var l in theLoan)
                {

                    DateTime theTime = DateHelper.NigeriaTime(DateTime.Now);

                    if (l.FirstMonthPayment != null)
                    {
                        if (l.FirstMonthPayment.Value.Month == theTime.Month && l.FirstMonthPayment.Value.Year == theTime.Year)
                        {
                            if (l.FirstAmountPayment != null)
                            {
                                model.TotalLoan = l.FirstAmountPayment + model.TotalLoan;

                            }
                        }
                    }
                    if (l.SecondMonthPayment != null)
                    {

                        if (l.SecondMonthPayment.Value.Month == theTime.Month && l.SecondMonthPayment.Value.Year == theTime.Year)
                        {
                            if (l.SecondAmountPayment != null)
                            {
                                model.TotalLoan = l.SecondAmountPayment + model.TotalLoan;
                            }
                        }
                    }

                    if (l.ThirdMonthPayment != null)
                    {
                        if (l.ThirdMonthPayment.Value.Month == theTime.Month && l.ThirdMonthPayment.Value.Year == theTime.Year)
                        {
                            if (l.ThirdAmountPayment != null)
                            {
                                model.TotalLoan = l.ThirdAmountPayment + model.TotalLoan;
                            }
                        }
                    }

                    if (l.ForthMonthPayment != null)
                    {
                        if (l.ForthMonthPayment.Value.Month == theTime.Month && l.ForthMonthPayment.Value.Year == theTime.Year)
                        {
                            if (l.ForthAmountPayment != null)
                            {

                                model.TotalLoan = l.ForthAmountPayment + model.TotalLoan;
                            }
                        }
                    }

                    if (l.FifthMonthPayment != null)
                    {

                        if (l.FifthMonthPayment.Value.Month == theTime.Month && l.FifthMonthPayment.Value.Year == theTime.Year)
                        {
                            if (l.FifthAmountPayment != null)
                            {
                                model.TotalLoan = l.FifthAmountPayment + model.TotalLoan;
                            }
                        }
                    }

                    if (l.SixthMonthPayment != null)
                    {
                        if (l.SixthMonthPayment.Value.Month == theTime.Month && l.SixthMonthPayment.Value.Year == theTime.Year)
                        {
                            if (l.SixthAmountPayment != null)
                            {

                                model.TotalLoan = l.SixthAmountPayment + model.TotalLoan;
                            }
                        }
                    }

                    if (l.SeventhMonthPayment != null)
                    {
                        if (l.SeventhMonthPayment.Value.Month == theTime.Month && l.SeventhMonthPayment.Value.Year == theTime.Year)
                        {
                            if (l.SeventhAmountPayment != null)
                            {
                                model.TotalLoan = l.SeventhAmountPayment + model.TotalLoan;
                            }
                        }
                    }

                    if (l.EighthMonthPayment != null)
                    {
                        if (l.EighthMonthPayment.Value.Month == theTime.Month && l.EighthMonthPayment.Value.Year == theTime.Year)
                        {
                            if (l.EightAmountPayment != null)
                            {
                                model.TotalLoan = l.EightAmountPayment + model.TotalLoan;
                            }
                        }
                    }

                    if (l.NinthMonthPayment != null)
                    {
                        if (l.NinthMonthPayment.Value.Month == theTime.Month && l.NinthMonthPayment.Value.Year == theTime.Year)
                        {
                            if (l.NinthAmountPayment != null)
                            {
                                model.TotalLoan = l.NinthAmountPayment + model.TotalLoan;
                            }
                        }
                    }
                    if (l.TenthMonthPayment != null)
                    {
                        if (l.TenthMonthPayment.Value.Month == theTime.Month && l.TenthMonthPayment.Value.Year == theTime.Year)
                        {
                            if (l.TenthAmountPayment != null)
                            {
                                model.TotalLoan = l.TenthAmountPayment + model.TotalLoan;
                            }
                        }
                    }

                    if (l.EleventhMonthPayment != null)
                    {
                        if (l.EleventhMonthPayment.Value.Month == theTime.Month && l.EleventhMonthPayment.Value.Year == theTime.Year)
                        {
                            if (l.EleventhAmountPayment != null)
                            {
                                model.TotalLoan = l.EleventhAmountPayment + model.TotalLoan;
                            }
                        }
                    }
                    if (l.TwelfthMonthPayment != null)
                    {
                        if (l.TwelfthMonthPayment.Value.Month == theTime.Month && l.TwelfthMonthPayment.Value.Year == theTime.Year)
                        {
                            if (l.TwelfthAmountPayment != null)
                            {
                                model.TotalLoan = l.TwelfthAmountPayment + model.TotalLoan;
                            }
                        }
                    }

                }

            }
            return model;

        }

        public SalaryPaymentHistory Lateness(SalaryPaymentHistory model)
        {
            // model.TotalLatenessDeduction
            model.TotalLatenessDeduction = 0;
            DateTime theTime = DateHelper.NigeriaTime(DateTime.Now);
            List<LatenessDeduction> theLatenessDeduction = new List<LatenessDeduction>();
            theLatenessDeduction = work.LatenessDeductionRepository.Get().ToList();
            //  List<AttendanceStaff> theAttendanceFortheMonth = work.AttendanceStaffRepository.Get(a =>a.DateTaken.Month == theTime.Month && a.DateTaken.Year == theTime.Month).OrderByDescending(a=>a.DateTaken).ToList();
            PrimarySchoolStaff theCurrentStaff = work.PrimarySchoolStaffRepository.Get(a => a.UserID == model.StaffID).First();
            if (theLatenessDeduction.Count > 0 && theCurrentStaff.LatenessDeduction == true)
            {
                // int numberOfAbsentDays = 0;
                for (int k = 1; k < 31; k++)
                {
                    List<AttendanceStaff> theAttendanceFortheMonth = work.AttendanceStaffRepository.Get(a => a.DateTaken.Month == theTime.Month && a.DateTaken.Year == theTime.Year).OrderByDescending(a => a.DateTaken).ToList();

                    theAttendanceFortheMonth = theAttendanceFortheMonth.Where(a => a.DateTaken.Day == k).ToList();

                    if (theAttendanceFortheMonth.Count > 0)
                    {
                        theAttendanceFortheMonth = theAttendanceFortheMonth.Where(a => a.StaffID == Convert.ToString(model.StaffID)).ToList();
                        if (theAttendanceFortheMonth.Count > 0)
                        {
                            AttendanceStaff theStaffAttendance = theAttendanceFortheMonth[0];
                            if (theStaffAttendance.Present == true)
                            {
                                AttendanceStaff attendanceForthisDay = theAttendanceFortheMonth[0];

                                int theHour = Convert.ToInt16(theLatenessDeduction[0].Hour);
                                int theMinute = Convert.ToInt16(theLatenessDeduction[0].Minute);
                                double setTime = Convert.ToDouble(theHour + "." + theMinute);
                                double timeTaken = Convert.ToDouble(attendanceForthisDay.DateTaken.Hour + "." + attendanceForthisDay.DateTaken.Minute);
                                if (timeTaken > setTime)
                                // if (setTime < timeTaken )
                                {
                                    model.TotalLatenessDeduction = model.TotalLatenessDeduction + theLatenessDeduction[0].AmountToBeDeducted;
                                }
                            }
                            else
                            {
                                // model.TotalLatenessDeduction = model.TotalLatenessDeduction + 100;
                            }
                        }

                    }
                }
                return model;
            }
            else
            {
                return model;
            }
        }

        public SalaryPaymentHistory Abscent(SalaryPaymentHistory model)
        {
            model.TotalAbscentDeduction = 0;
            DateTime theTime = DateHelper.NigeriaTime(DateTime.Now);
            List<LatenessDeduction> theLatenessDeduction = work.LatenessDeductionRepository.Get().ToList();
            //  List<AttendanceStaff> theAttendanceFortheMonth = work.AttendanceStaffRepository.Get(a =>a.DateTaken.Month == theTime.Month && a.DateTaken.Year == theTime.Month).OrderByDescending(a=>a.DateTaken).ToList();

            List<AbscentDeduction> theAbscentDeduction = new List<AbscentDeduction>();
            theAbscentDeduction = work.AbscentDeductionRepository.Get().ToList();
            //  List<AttendanceStaff> theAttendanceFortheMonth = work.AttendanceStaffRepository.Get(a =>a.DateTaken.Month == theTime.Month && a.DateTaken.Year == theTime.Month).OrderByDescending(a=>a.DateTaken).ToList();
            PrimarySchoolStaff theCurrentStaff = work.PrimarySchoolStaffRepository.Get(a => a.UserID == model.StaffID).First();
            if (theAbscentDeduction.Count > 0 && theCurrentStaff.AbscentDeduction == true)
            {
                // int numberOfAbsentDays = 0;
                for (int k = 1; k < 31; k++)
                {
                    List<AttendanceStaff> theAttendanceFortheMonth = work.AttendanceStaffRepository.Get(a => a.DateTaken.Month == theTime.Month && a.DateTaken.Year == theTime.Year).OrderByDescending(a => a.DateTaken).ToList();

                    theAttendanceFortheMonth = theAttendanceFortheMonth.Where(a => a.DateTaken.Day == k).ToList();

                    if (theAttendanceFortheMonth.Count > 0)
                    {
                        theAttendanceFortheMonth = theAttendanceFortheMonth.Where(a => a.StaffID == Convert.ToString(model.StaffID)).ToList();
                        if (theAttendanceFortheMonth.Count > 0)
                        {
                            AttendanceStaff theStaffAttendance = theAttendanceFortheMonth[0];
                            if (theStaffAttendance.Present == true || theStaffAttendance.NotPresentButTookPermission == true)
                            {

                            }
                            else
                            {
                                model.TotalAbscentDeduction = model.TotalAbscentDeduction + theAbscentDeduction[0].AmountToBeDeducted;
                            }
                        }

                    }
                }
            }
            return model;
        }

        public SalaryPaymentHistory ContributionsOrDeductions(SalaryPaymentHistory model)
        {
            int theStaffID = model.StaffID;
            PrimarySchoolStaff theStaff = work.PrimarySchoolStaffRepository.Get(a => a.UserID == theStaffID).First();
            //get deductions out
            String[] theContributionId;// = new StringBuilder();
            List<Deduction> theDeductiong = new List<Deduction>();
            if (!(string.IsNullOrEmpty(theStaff.ContributionIDs)))
            {

                theContributionId = theStaff.ContributionIDs.Split(' ');

                foreach (var c in theContributionId)
                {
                    if (!(string.IsNullOrEmpty(c)))
                    {
                        int theContributionID = Convert.ToInt16(c);

                        Deduction thed = work.DeductionRepository.GetByID(theContributionID);
                        if (thed != null)
                        {
                            theDeductiong.Add(thed);
                        }
                    }

                }
            }
            model.TheDeduction = theDeductiong;
            return model;
        }
    }
}