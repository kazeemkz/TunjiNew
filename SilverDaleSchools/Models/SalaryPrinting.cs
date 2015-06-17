using iTextSharp.text;
using iTextSharp.text.pdf;
using JobHustler.DAL;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class SalaryPrinting
    {
        UnitOfWork work = new UnitOfWork();
        public Document PrintPaySlip(List<SalaryPaymentHistory> thePaymentNow, ref StringWriter sw, ref Document itextDoc)
        {
           // thePaymentNow.

            // PdfPTable table = new PdfPTable(2);
            //  PdfPTable alphabet = new PdfPTable(11);
            iTextSharp.text.Font font_heading_3 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD);
            PdfPTable table1 = new PdfPTable(2);
            table1.DefaultCell.Border = iTextSharp.text.Rectangle.BOX;
            table1.AddCell("WEXFORD COLLEGE");
            table1.AddCell("FIRST GATE OBA ILE HOUSING ESTATE, AKURE, AKURE NORTH L.G.A");
            table1.AddCell("MOTTO:");
            table1.AddCell("INTELLIGENCE, INTEGRITY & INDUSTRY");


            table1.AddCell(".");
            table1.AddCell(".");
            itextDoc.Add(table1);

            itextDoc.Add(new Paragraph("   "));
            itextDoc.Add(new Paragraph("   "));

            BaseFont bfTimes = BaseFont.CreateFont(FontFactory.TIMES_ROMAN, BaseFont.CP1252, false);
            //   iTextSharp.text.Font font_heading_1 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 19, iTextSharp.text.Font.BOLD);

            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.NORMAL, BaseColor.RED);



            foreach (var s in thePaymentNow)
            {
                PdfPTable table = new PdfPTable(2);
                PdfPTable wexford = new PdfPTable(1);
                table.DefaultCell.Border = iTextSharp.text.Rectangle.BOX;
                decimal toTalDeduction = 0;
                toTalDeduction = Convert.ToDecimal(s.TotalLatenessDeduction) + toTalDeduction;
                toTalDeduction = Convert.ToDecimal(s.TotalLoan) + toTalDeduction;
                toTalDeduction = Convert.ToDecimal(s.TotalAbscentDeduction) + toTalDeduction;

                itextDoc.Add(new Paragraph("==========================================================================   "));
                // work.SalaryRepository.GetByID(s.)
                wexford.AddCell(new Paragraph("WexFord Akure, Pay Slip", font_heading_3));
                itextDoc.Add(wexford);
                table.AddCell(new Paragraph("SALARY FOR THE MONTH OF :", font_heading_3));
                table.AddCell(new Paragraph(string.Format("{0:MMMM-yyyy}", DateTime.Now), font_heading_3));
                //table.AddCell("                 ");

                table.AddCell(new Paragraph("NAME :", font_heading_3));
                table.AddCell(new Paragraph(s.LastName + " " + s.FirstName, font_heading_3));

                table.AddCell(new Paragraph("Staff ID", font_heading_3));
                table.AddCell(new Paragraph(Convert.ToString(s.StaffID), font_heading_3));


                table.AddCell(new Paragraph("Lateness Surcharge (NGN)", font_heading_3));

                table.AddCell(new Paragraph(Convert.ToString(s.TotalLatenessDeduction), font_heading_3));

                table.AddCell(new Paragraph("Abscent Surcharge (NGN)", font_heading_3));

                table.AddCell(new Paragraph(Convert.ToString(s.TotalAbscentDeduction), font_heading_3));

                table.AddCell(new Paragraph("Loan Repayment (NGN)", font_heading_3));

                table.AddCell(new Paragraph(Convert.ToString(s.TotalLoan), font_heading_3));

                foreach (var c in s.TheDeduction)
                {
                    toTalDeduction = Convert.ToDecimal(c.Amount) + toTalDeduction;
                    table.AddCell(new Paragraph(Convert.ToString(c.DeductionDescription + " (NGN)"), font_heading_3));
                    table.AddCell(new Paragraph(Convert.ToString(c.Amount), font_heading_3));
                }

                table.AddCell(new Paragraph("ACTUAL SALARY (NGN)", font_heading_3));

                table.AddCell(new Paragraph(Convert.ToString(s.ActualSalary), font_heading_3));
                table.AddCell(new Paragraph("TOTAL DEDUCTION (NGN) ", font_heading_3));

                table.AddCell(new Paragraph(Convert.ToString(toTalDeduction), font_heading_3));
                table.AddCell(new Paragraph("NET PAY (NGN)", font_heading_3));

                table.AddCell(new Paragraph(Convert.ToString(s.ActualSalary - toTalDeduction), font_heading_3));
                itextDoc.Add(table);
            }

            //  return itextDoc;
            //check for the student in exam2
            //  new SalaryPrinting().PrintPaySlip(thePaymentNow, ref oStringWriter1, ref document);

            // itextDoc.Add(new Paragraph("==============================================================================================================================================================   "));
            // account to bank 

            itextDoc.NewPage();

            PdfPTable table3 = new PdfPTable(2);
            table3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            iTextSharp.text.Image imgPDF = iTextSharp.text.Image.GetInstance(HttpRuntime.AppDomainAppPath + "\\Images\\wexford.jpg");
            imgPDF.ScaleToFit(128, 100);
            // imgPDF.ScaleToFit(200, 200);
            PdfPCell theImage = new PdfPCell(imgPDF);
            theImage.Border = iTextSharp.text.Rectangle.NO_BORDER;
            table3.AddCell(theImage);

            iTextSharp.text.Font font_heading_1 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.BOLD);

            iTextSharp.text.Font font_heading_2 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
            //  iTextSharp.text.Font font_heading_3 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD);

            PdfPTable theSchoolNameTable = new PdfPTable(1);

            PdfPCell theWexFord = new PdfPCell(new Paragraph("WEXFORD COLLEGE", font_heading_1));
            theWexFord.Border = iTextSharp.text.Rectangle.NO_BORDER;
            // theWexFord.w

            PdfPCell theWexFordFirstGate = new PdfPCell(new Paragraph(new Paragraph("FIRST GATE OBA ILE HOUSING ESTATE, AKURE, AKURE NORTH L.G.A,   ", font_heading_1)));
            theWexFordFirstGate.Border = iTextSharp.text.Rectangle.NO_BORDER;

            PdfPCell theWexFordMoto = new PdfPCell(new Paragraph("MOTTO: INTELLIGENCE, INTEGRITY & INDUSTRY", font_heading_1));
            theWexFordMoto.Border = iTextSharp.text.Rectangle.NO_BORDER;

            theSchoolNameTable.AddCell(theWexFord);
            theSchoolNameTable.AddCell(theWexFordFirstGate);
            theSchoolNameTable.AddCell(theWexFordMoto);
            table3.AddCell(theSchoolNameTable);



            itextDoc.Add(table3);

            itextDoc.Add(new Paragraph("   "));
            itextDoc.Add(new Paragraph("                 Date Generated   - "+(string.Format("{0:dd MMM-yyyy}", DateTime.Now))));
            itextDoc.Add(new Paragraph("   "));
            itextDoc.Add(new Paragraph("                   The Manager", font_heading_2));
            itextDoc.Add(new Paragraph("                   EcoBank Nig Plc,", font_heading_2));
            itextDoc.Add(new Paragraph("                   Alagbaka,", font_heading_2));
            itextDoc.Add(new Paragraph("                   Akure, Ondo State,", font_heading_2));
            //  itextDoc.Add(new Paragraph("                                                                                        REPORT SHEET            ", font_heading_1));

            itextDoc.Add(new Paragraph("   "));
            //   itextDoc.Add(table1);


            itextDoc.Add(new Paragraph("   "));
            itextDoc.Add(new Paragraph("   "));

            // BaseFont bfTimes = BaseFont.CreateFont(FontFactory.TIMES_ROMAN, BaseFont.CP1252, false);
            //   iTextSharp.text.Font font_heading_1 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 19, iTextSharp.text.Font.BOLD);

            //  iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.NORMAL, BaseColor.RED);

            PdfPTable table4 = new PdfPTable(6);


            table4.AddCell((new Paragraph("s/n", font_heading_3)));
            table4.AddCell((new Paragraph("Staff Name", font_heading_3)));
            table4.AddCell((new Paragraph("Account Name", font_heading_3)));
            table4.AddCell((new Paragraph("Account No", font_heading_3)));
            table4.AddCell((new Paragraph("Bank", font_heading_3)));
            table4.AddCell((new Paragraph("Amount (NGN)", font_heading_3)));

            int counter = 1;

            foreach (var s in thePaymentNow)
            {
                //PdfPTable table = new PdfPTable(2);
                PrimarySchoolStaff theStaff = work.PrimarySchoolStaffRepository.Get(a => a.UserID == s.StaffID).First();
                table4.DefaultCell.Border = iTextSharp.text.Rectangle.BOX;
                decimal toTalDeduction = 0;
                toTalDeduction = Convert.ToDecimal(s.TotalLatenessDeduction) + toTalDeduction;
                toTalDeduction = Convert.ToDecimal(s.TotalLoan) + toTalDeduction;
                toTalDeduction = Convert.ToDecimal(s.TotalAbscentDeduction) + toTalDeduction;

                table4.AddCell(new Paragraph(Convert.ToString(counter), font_heading_3));

                table4.AddCell(new Paragraph(s.LastName + " " + s.FirstName, font_heading_3));

                table4.AddCell(new Paragraph(theStaff.AccountName, font_heading_3));
                table4.AddCell(new Paragraph(theStaff.AccountNumber, font_heading_3));
                table4.AddCell(new Paragraph(theStaff.BankName, font_heading_3));
                // table.AddCell(theStaff.BankName);

                foreach (var c in s.TheDeduction)
                {
                    toTalDeduction = Convert.ToDecimal(c.Amount) + toTalDeduction;
                }

                counter = counter + 1;
                table4.AddCell(new Paragraph(Convert.ToString(s.ActualSalary - toTalDeduction), font_heading_3));

            }
            itextDoc.Add(table4);

            return itextDoc;
        }


      
    }
}