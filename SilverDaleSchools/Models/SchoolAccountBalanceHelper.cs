using JobHustler.DAL;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{


    public class SchoolAccountBalanceHelper
    {
        UnitOfWork work = new UnitOfWork();
        private Object thisLock = new Object();
        decimal totalAmount = 0;
        decimal totalBalance = 0;
        public decimal getSchoolAccountBalance(decimal theCurrentAmounttoBeDeductedOrAdded)
        {

            lock (thisLock)
            {
                List<SchoolAccount> theSchoolFeesAccount = new List<SchoolAccount>();
                theSchoolFeesAccount = work.SchoolAccountRepository.Get().OrderByDescending(a => a.DateApproved).ToList();

                if (theSchoolFeesAccount.Count > 0)
                {
                    if (theSchoolFeesAccount[0].Balance != null)
                    {
                        totalBalance = Convert.ToDecimal( theSchoolFeesAccount[0].Balance ) + theCurrentAmounttoBeDeductedOrAdded;
                    }
                    else
                    {
                        var account = from s in work.SchoolAccountRepository.Get().OrderByDescending(a => a.DateApproved)
                                          select s;

                            foreach (SchoolAccount aF in account)
                            {
                                totalBalance += aF.Amount;
                            }

                            totalBalance += theCurrentAmounttoBeDeductedOrAdded;
                    }
                }
                else
                {
                    totalBalance = theCurrentAmounttoBeDeductedOrAdded;
                }

            }
            //var account = from s in work.SchoolAccountRepository.Get().OrderByDescending(a => a.DateApproved)
            //                  select s;

            //    foreach (SchoolAccount aF in account)
            //    {
            //        totalAmount += aF.Amount;
            //    }

            //    totalAmount += theCurrentAmounttoBeDeductedOrAdded;

            return totalBalance;
        }
    }
}