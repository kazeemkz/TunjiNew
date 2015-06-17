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
    public class SchoolFeesPrinting
    {
        UnitOfWork work = new UnitOfWork();

        public Document FeesPrinting(List<TermRegistration> registration, ref StringWriter sw, ref Document itextDoc)
        {
           
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

            itextDoc.Add(new Paragraph("  "));

            itextDoc.Add(new Paragraph("  "));

            iTextSharp.text.Font font_heading_3 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD);

             PdfPTable table4 = new PdfPTable(8);


            table4.AddCell((new Paragraph("S/N", font_heading_3)));
            table4.AddCell((new Paragraph("Name", font_heading_3)));
            table4.AddCell((new Paragraph("Sex", font_heading_3)));
            table4.AddCell((new Paragraph("Class", font_heading_3)));
            table4.AddCell((new Paragraph("Session", font_heading_3)));
            table4.AddCell((new Paragraph("School Fees Category", font_heading_3)));
            table4.AddCell((new Paragraph("School Fees  (NGN)", font_heading_3)));
            table4.AddCell((new Paragraph("Owing  (NGN)", font_heading_3)));

            int counter = 1;

            foreach (var s in registration)
            {
              // s.
                
                //PdfPTable table = new PdfPTable(2);
                List<SchoolFeePayment> theStudentPayments = new List<SchoolFeePayment>();
               theStudentPayments = work.SchoolFeePaymentRepository.Get(a => a.StudentID == s.StudentID).ToList() ;
               SchoolFeePayment theStudentPayment = new SchoolFeePayment();
              // theStudentPayment.Owing = 0;
               if (theStudentPayments.Count > 0)
               {
                 theStudentPayment =  theStudentPayments.OrderByDescending(a => a.DatePaid).First();
                // theStudentPayment.Owing = 0;
               }
                table4.DefaultCell.Border = iTextSharp.text.Rectangle.BOX;
                decimal toTalDeduction = 0;
               /// toTalDeduction = Convert.ToDecimal(s.TotalLatenessDeduction) + toTalDeduction;
               // toTalDeduction = Convert.ToDecimal(s.TotalLoan) + toTalDeduction;
               // toTalDeduction = Convert.ToDecimal(s.TotalAbscentDeduction) + toTalDeduction;

                table4.AddCell(new Paragraph(Convert.ToString(counter), font_heading_3));

                table4.AddCell(new Paragraph(s.LastName + " " + s.FirstName, font_heading_3));
                table4.AddCell(new Paragraph(s.Sex, font_heading_2));
                table4.AddCell(new Paragraph(s.Level, font_heading_2));
                table4.AddCell(new Paragraph(s.Session, font_heading_2));
                table4.AddCell(new Paragraph(s.SchoolFeesKind, font_heading_2));
                table4.AddCell(new Paragraph(Convert.ToString(s.Cost), font_heading_2));
                table4.AddCell(new Paragraph(Convert.ToString(theStudentPayment.Owing), font_heading_2));
              
               
                counter = counter + 1;
            }
            itextDoc.Add(table4);
            return itextDoc;
        }
        
    }
}