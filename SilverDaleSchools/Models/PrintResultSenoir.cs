using iTextSharp.text;
using iTextSharp.text.pdf;
using SilverDaleSchools.DAL;
using SilverDaleSchools.Model;
//using SilverDaleSchools.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace SilverDaleSchools.Models
{
    public class PrintResultSenoir
    {
        UnitOfWork work = new UnitOfWork();
        public Document PrintSilverDaleResult(Result theResult, ref StringWriter sw, ref Document itextDoc)
        {

            //  itextDoc.NewPage();
            PdfPTable table3 = new PdfPTable(2);

            table3.HorizontalAlignment = 0;
            table3.TotalWidth = 500f;
            table3.LockedWidth = true;
            float[] widths = new float[] { 100f, 400f };
            table3.SetWidths(widths);

            table3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            iTextSharp.text.Image imgPDF = iTextSharp.text.Image.GetInstance(HttpRuntime.AppDomainAppPath + "\\Images\\sildaleresultlogo.jpg");
            imgPDF.ScaleToFit(70, 70);



            //   PdfPTable table = new PdfPTable(10);











            PdfPCell theImage = new PdfPCell(imgPDF);
            //  theImage.Width = 2;
            theImage.Border = iTextSharp.text.Rectangle.NO_BORDER;
            table3.AddCell(theImage);

            iTextSharp.text.Font font_heading_1 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 16, iTextSharp.text.Font.BOLD);

            iTextSharp.text.Font font_heading_2 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 7, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font_heading_3 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.BOLD);

            iTextSharp.text.Font font_heading_4 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD);

            PdfPTable theSchoolNameTable = new PdfPTable(1);

            PdfPCell theWexFord = new PdfPCell(new Paragraph("SILVERDALE HIGH SCHOOL", font_heading_1));
            theWexFord.Border = iTextSharp.text.Rectangle.NO_BORDER;
            // theWexFord.w

            PdfPCell theWexFordFirstGate = new PdfPCell(new Paragraph(new Paragraph("4 AKINRINLO STREET, OFF ALIMOSHO ROAD, IYANA-IPAJA, LAGOS", font_heading_3)));
            theWexFordFirstGate.Border = iTextSharp.text.Rectangle.NO_BORDER;

            PdfPCell theWexFordMoto = new PdfPCell(new Paragraph("Website:www.silverdaleschoolslagos.com  Email: info@silverdaleschoolslagos.com", font_heading_3));
            theWexFordMoto.Border = iTextSharp.text.Rectangle.NO_BORDER;

            theSchoolNameTable.AddCell(theWexFord);
            theSchoolNameTable.AddCell(theWexFordFirstGate);
            theSchoolNameTable.AddCell(theWexFordMoto);
            table3.AddCell(theSchoolNameTable);



            itextDoc.Add(table3);

            string theTermValue = null;
            if (theResult.Term == "1")
            {
                theTermValue = "FIRST TERM";
               // itextDoc.Add(new Paragraph("                                                                                                             FIRST TERM", font_heading_4));
            }

            if (theResult.Term == "2")
            {
                theTermValue = "SECOND TERM";
               // itextDoc.Add(new Paragraph("                                                                                                             SECOND TERM", font_heading_4));
            }

            if (theResult.Term == "3")
            {
                theTermValue = "THIRD TERM";
               // itextDoc.Add(new Paragraph("                                                                                                             THIRD TERM", font_heading_4));
            }

            PdfPTable theTerm = new PdfPTable(3);

            theTerm.HorizontalAlignment = 0;
            theTerm.TotalWidth = 500f;
            theTerm.LockedWidth = true;
            float[] widthstheTerm = new float[] { 250f, 250f, 250f };
            theTerm.SetWidths(widthstheTerm);
            theTerm.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            theTerm.AddCell(new Paragraph(new Paragraph("")));
            theTerm.AddCell(new Paragraph(new Paragraph(theTermValue, font_heading_3)));
            theTerm.AddCell(new Paragraph(new Paragraph("")));
            itextDoc.Add(theTerm);




            //term
            PdfPTable name = new PdfPTable(2);

            name.HorizontalAlignment = 0;
            name.TotalWidth = 500f;
            name.LockedWidth = true;
            float[] widthsname = new float[] { 250f, 250f };
            name.SetWidths(widthsname);

            name.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;


            name.AddCell(new Paragraph("STUDENT'S NAME:  " + theResult.Surname + " " + theResult.Firstname, font_heading_2));
            name.AddCell(new Paragraph(""));
            name.AddCell(new Paragraph(new Paragraph("DATE OF BIRTH ", font_heading_2)));
            name.AddCell(new Paragraph(new Paragraph("SEX: " + theResult.Sex, font_heading_2)));
            name.AddCell(new Paragraph(new Paragraph("CLASS: " + theResult.Class, font_heading_2)));
            name.AddCell(new Paragraph(new Paragraph("SESSION: " + theResult.Session, font_heading_2)));


            itextDoc.Add(name);

            PdfPTable attendance = new PdfPTable(3);

            attendance.HorizontalAlignment = 0;
            attendance.TotalWidth = 500f;
            attendance.LockedWidth = true;
            float[] widthsattendance = new float[] {250f,250f, 250f };
            attendance.SetWidths(widthsattendance);
            attendance.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            attendance.AddCell(new Paragraph(new Paragraph("")));
            attendance.AddCell(new Paragraph(new Paragraph("1. ATTENDANCE", font_heading_3)));
            attendance.AddCell(new Paragraph(new Paragraph("")));
            itextDoc.Add(attendance);

            PdfPTable attendanceopne = new PdfPTable(2);
            attendanceopne.HorizontalAlignment = 0;
            attendanceopne.TotalWidth = 500f;
            attendanceopne.LockedWidth = true;
            float[] widthsattendanceopne = new float[] {250f,250f};
            attendanceopne.SetWidths(widthsattendanceopne);
            attendanceopne.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            attendanceopne.AddCell(new Paragraph(new Paragraph("NO. OF TIMES SCHOOL OPENED:  " + theResult.NoofTimesSchoolOpened, font_heading_2)));

            attendanceopne.AddCell(new Paragraph(new Paragraph("NO. OF TIMES PRESENT:  " + theResult.NoofTimesPresent, font_heading_2)));
            attendanceopne.AddCell(new Paragraph(new Paragraph("NO. OF TIMES PUNCTUAL:  " + theResult.NoofTimesPunctual, font_heading_2)));
            attendanceopne.AddCell(new Paragraph(new Paragraph("NO. OF TIMES ABSENT:  " + theResult.NoofTimesAbsent, font_heading_2)));


            itextDoc.Add(attendanceopne);

            itextDoc.Add(new Paragraph("   "));



            PdfPTable table = new PdfPTable(23);

            table.TotalWidth = 1200f;
            table3.LockedWidth = true;
            float[] widthstable = new float[] { 50f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f, 52f };
            table.SetWidths(widthstable);

            iTextSharp.text.Font fntTableFont = FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            PdfPCell CellZero = new PdfPCell(new Phrase("", fntTableFont));
            CellZero.Rotation = 90;
            //  CellZero.BackgroundColor = Color.LightGray;
            CellZero.Rowspan = 1;
            CellZero.VerticalAlignment = Element.ALIGN_TOP;
            CellZero.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(CellZero);

            PdfPCell CellZero2 = new PdfPCell(new Phrase("Max Obtainable", fntTableFont));
            CellZero2.Rotation = 90;
            CellZero2.Rowspan = 1;
            CellZero2.VerticalAlignment = Element.ALIGN_TOP;
            CellZero2.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(CellZero2);


            PdfPCell english = new PdfPCell(new Phrase("Eng. Language", fntTableFont));
            english.Rotation = 90;
            english.Rowspan = 1;
            english.VerticalAlignment = Element.ALIGN_TOP;
            english.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(english);

            PdfPCell mathematics = new PdfPCell(new Phrase("Mathematics", fntTableFont));
            mathematics.Rotation = 90;
            mathematics.Rowspan = 1;
            mathematics.VerticalAlignment = Element.ALIGN_TOP;
            mathematics.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(mathematics);


            PdfPCell basic = new PdfPCell(new Phrase("Biology", fntTableFont));
            basic.Rotation = 90;
            basic.Rowspan = 1;
            basic.VerticalAlignment = Element.ALIGN_TOP;
            basic.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(basic);


            PdfPCell social = new PdfPCell(new Phrase("Physics", fntTableFont));
            social.Rotation = 90;
            social.Rowspan = 1;
            social.VerticalAlignment = Element.ALIGN_TOP;
            social.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(social);


            PdfPCell home = new PdfPCell(new Phrase("Chemistry", fntTableFont));
            home.Rotation = 90;
            home.Rowspan = 1;
            home.VerticalAlignment = Element.ALIGN_TOP;
            home.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(home);


            PdfPCell yoruba = new PdfPCell(new Phrase("Yoruba", fntTableFont));
            yoruba.Rotation = 90;
            yoruba.Rowspan = 1;
            yoruba.VerticalAlignment = Element.ALIGN_TOP;
            yoruba.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(yoruba);


            PdfPCell french = new PdfPCell(new Phrase("C.R.K", fntTableFont));
            french.Rotation = 90;
            french.Rowspan = 1;
            french.VerticalAlignment = Element.ALIGN_TOP;
            french.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(french);


            PdfPCell computer = new PdfPCell(new Phrase("Geography", fntTableFont));
            computer.Rotation = 90;
            computer.Rowspan = 1;
            computer.VerticalAlignment = Element.ALIGN_TOP;
            computer.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(computer);


            PdfPCell crk = new PdfPCell(new Phrase("Agric Sc.", fntTableFont));
            crk.Rotation = 90;
            crk.Rowspan = 1;
            crk.VerticalAlignment = Element.ALIGN_TOP;
            crk.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(crk);


            PdfPCell civil = new PdfPCell(new Phrase("Food & Nut.", fntTableFont));
            civil.Rotation = 90;
            civil.Rowspan = 1;
            civil.VerticalAlignment = Element.ALIGN_TOP;
            civil.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(civil);


            PdfPCell basicT = new PdfPCell(new Phrase("Economics", fntTableFont));
            basicT.Rotation = 90;
            basicT.Rowspan = 1;
            basicT.VerticalAlignment = Element.ALIGN_TOP;
            basicT.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(basicT);


            PdfPCell fineA = new PdfPCell(new Phrase("French", fntTableFont));
            fineA.Rotation = 90;
            fineA.Rowspan = 1;
            fineA.VerticalAlignment = Element.ALIGN_TOP;
            fineA.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(fineA);


            PdfPCell agric = new PdfPCell(new Phrase("Civil Edu.", fntTableFont));
            agric.Rotation = 90;
            agric.Rowspan = 1;
            agric.VerticalAlignment = Element.ALIGN_TOP;
            agric.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(agric);

            PdfPCell phe = new PdfPCell(new Phrase("Computer", fntTableFont));
            phe.Rotation = 90;
            phe.Rowspan = 1;
            phe.VerticalAlignment = Element.ALIGN_TOP;
            phe.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(phe);


            PdfPCell music = new PdfPCell(new Phrase("Lit. in Eng.", fntTableFont));
            music.Rotation = 90;
            music.Rowspan = 1;
            music.VerticalAlignment = Element.ALIGN_TOP;
            music.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(music);

            PdfPCell bus = new PdfPCell(new Phrase("F. Maths", fntTableFont));
            bus.Rotation = 90;
            bus.Rowspan = 1;
            bus.VerticalAlignment = Element.ALIGN_TOP;
            bus.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(bus);


            PdfPCell ro = new PdfPCell(new Phrase("Commerce", fntTableFont));
            ro.Rotation = 90;
            ro.Rowspan = 1;
            ro.VerticalAlignment = Element.ALIGN_TOP;
            bus.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(ro);

            PdfPCell rin = new PdfPCell(new Phrase("Royal. Eng.", fntTableFont));
            rin.Rotation = 90;
            rin.Rowspan = 1;
            rin.VerticalAlignment = Element.ALIGN_TOP;
            bus.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(rin);


            PdfPCell acc = new PdfPCell(new Phrase("Account", fntTableFont));
            acc.Rotation = 90;
            acc.Rowspan = 1;
            acc.VerticalAlignment = Element.ALIGN_TOP;
            acc.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(acc);

            //PdfPCell accc = new PdfPCell(new Phrase("Account", fntTableFont));
            //accc.Rotation = 90;
            //accc.Rowspan = 1;
            //accc.VerticalAlignment = Element.ALIGN_TOP;
            //accc.HorizontalAlignment = Element.ALIGN_CENTER;
            //table.AddCell(accc);

            PdfPCell govt = new PdfPCell(new Phrase("Govt.", fntTableFont));
            govt.Rotation = 90;
            govt.Rowspan = 1;
            govt.VerticalAlignment = Element.ALIGN_TOP;
            govt.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(govt);


            PdfPCell Tech = new PdfPCell(new Phrase("Tech. Draw.", fntTableFont));
            Tech.Rotation = 90;
            Tech.Rowspan = 1;
            Tech.VerticalAlignment = Element.ALIGN_TOP;
            Tech.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(Tech);


            //get the table creation to perspective


            // attendance record

            List<string> theStructuredAttendance = new StructureSecondarySchoolResult().StructureAttendance(theResult);
            table.AddCell(new Paragraph("Attd.", font_heading_2));
            table.AddCell(new Paragraph("%", font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[0], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[1], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[2], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[3], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[4], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[5], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[6], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[7], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[8], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[9], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[10], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[11], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[12], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[13], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[14], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[15], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[16], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[17], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[18], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[19], font_heading_2));
            table.AddCell(new Paragraph(theStructuredAttendance[20], font_heading_2));
            //table.AddCell(new Paragraph(theStructuredAttendance[21], font_heading_2));




            // attendance ca

            List<string> StructureCA = new StructureSecondarySchoolResult().StructureCA(theResult);

            table.AddCell(new Paragraph("C.A", font_heading_2));
            table.AddCell(new Paragraph("40", font_heading_2));
            table.AddCell(new Paragraph(StructureCA[0], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[1], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[2], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[3], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[4], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[5], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[6], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[7], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[8], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[9], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[10], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[11], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[12], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[13], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[14], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[15], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[16], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[17], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[18], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[19], font_heading_2));
            table.AddCell(new Paragraph(StructureCA[20], font_heading_2));
            //  table.AddCell(new Paragraph(StructureCA[21], font_heading_2));




            // attendance ca

            List<string> StructureExam = new StructureSecondarySchoolResult().StructureExam(theResult);
            table.AddCell(new Paragraph("Exam", font_heading_2));
            table.AddCell(new Paragraph("60", font_heading_2));

            table.AddCell(new Paragraph(StructureExam[0], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[1], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[2], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[3], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[4], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[5], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[6], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[7], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[8], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[9], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[10], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[11], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[12], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[13], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[14], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[15], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[16], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[17], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[18], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[19], font_heading_2));
            table.AddCell(new Paragraph(StructureExam[20], font_heading_2));
            // table.AddCell(new Paragraph(StructureExam[21], font_heading_2));


            //total
            List<string> StructureTotal = new StructureSecondarySchoolResult().StructureTotal(theResult);
            table.AddCell(new Paragraph("Total", font_heading_2));
            table.AddCell(new Paragraph("100", font_heading_2));

            table.AddCell(new Paragraph(StructureTotal[0], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[1], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[2], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[3], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[4], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[5], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[6], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[7], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[8], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[9], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[10], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[11], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[12], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[13], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[14], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[15], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[16], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[17], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[18], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[19], font_heading_2));
            table.AddCell(new Paragraph(StructureTotal[20], font_heading_2));
            // table.AddCell(new Paragraph(StructureTotal[21], font_heading_2));



            //average w

            if (theResult.Term == "2" || theResult.Term == "3")
            {
                List<string> StructureAverageW = new List<string>();
                if (theResult.Term == "2")
                {
                    StructureAverageW = new StructureSecondarySchoolResult().StructureWieghtAveSecondTerm(theResult);
                }

                else
                {
                    StructureAverageW = new StructureSecondarySchoolResult().StructureWieghtAveThirdTerm(theResult);
                }

                table.AddCell(new Paragraph("W.Average", font_heading_2));
                table.AddCell(new Paragraph("", font_heading_2));

                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[0]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[1]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[2]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[3]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[4]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[5]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[6]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[7]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[8]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[9]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[10]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[11]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[12]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[13]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[14]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[15]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[16]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[17]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[18]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[19]), font_heading_2));
                table.AddCell(new Paragraph(DecimalRounder.RoundDecimal(StructureAverageW[20]), font_heading_2));
                //  table.AddCell(new Paragraph(StructureAverageW[21], font_heading_2));
                // table.AddCell(new Paragraph(StructureAverageW[1], font_heading_2));
            }

            //total
            //  List<string> StructureTotal = new StructureSecondarySchoolResult().StructureTotal(theResult);
            table.AddCell(new Paragraph("Grade", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));

            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[0]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[1]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[2]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[3]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[4]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[5]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[6]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[7]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[8]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[9]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[10]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[11]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[12]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[13]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[14]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[15]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[16]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[17]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[18]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[19]), font_heading_2));
            table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[20]), font_heading_2));
            //  table.AddCell(new Paragraph(GradeCalculator.CalculateSenoir(StructureTotal[21]), font_heading_2));


            if (theResult.Term != "1")
            {

                if (theResult.Term != "2")
                {
                    // second term previos exam
                    List<Result> theSecondTermResult = work.ResultRepository.Get().Where(a => a.Term == "2" && a.StudentNo == theResult.StudentNo && a.Session == theResult.Session && a.Class == theResult.Class).ToList();

                    if (theSecondTermResult.Count > 0)
                    {
                        //total
                        List<string> StructureTotalSecondTerm = new StructureSecondarySchoolResult().StructureTotal(theSecondTermResult[0]);
                        table.AddCell(new Paragraph("Term 2", font_heading_2));
                        table.AddCell(new Paragraph("", font_heading_2));

                        table.AddCell(new Paragraph(StructureTotalSecondTerm[0], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[1], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[2], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[3], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[4], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[5], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[6], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[7], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[8], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[9], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[10], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[11], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[12], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[13], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[14], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[15], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[16], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[17], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[18], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[19], font_heading_2));
                        table.AddCell(new Paragraph(StructureTotalSecondTerm[20], font_heading_2));
                        //  table.AddCell(new Paragraph(StructureTotalSecondTerm[21], font_heading_2));
                    }


                }

                // first term previos exam
                List<Result> theFirstTermResult = work.ResultRepository.Get().Where(a => a.Term == "1" && a.StudentNo == theResult.StudentNo  && a.Session == theResult.Session && a.Class == theResult.Class).ToList();

                if (theFirstTermResult.Count > 0)
                {
                    //total
                    List<string> StructureTotalFirstTerm = new StructureSecondarySchoolResult().StructureTotal(theFirstTermResult[0]);
                    table.AddCell(new Paragraph("Term 1", font_heading_2));
                    table.AddCell(new Paragraph("", font_heading_2));

                    table.AddCell(new Paragraph(StructureTotalFirstTerm[0], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[1], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[2], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[3], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[4], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[5], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[6], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[7], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[8], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[9], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[10], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[11], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[12], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[13], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[14], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[15], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[16], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[17], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[18], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[19], font_heading_2));
                    table.AddCell(new Paragraph(StructureTotalFirstTerm[20], font_heading_2));
                    //   table.AddCell(new Paragraph(StructureTotalFirstTerm[21], font_heading_2));
                }

            }

            table.AddCell(new Paragraph("Teach. Sign.", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            table.AddCell(new Paragraph("", font_heading_2));
            itextDoc.Add(table);

            // cell2.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            // cell2.Phrase = new Phrase("Max Obtainable");
            // table.AddCell(CellZero2);
            itextDoc.Add(new Paragraph("   "));
            //   itextDoc.Add(table1);
            itextDoc.Add(new Paragraph("3. TOTAL SCORE OBTAINABLE: " + theResult.TotalScoreObtainable + "                                                                                                             TOTAL SCORE OBTAINED: " + theResult.TotalScoreObtained, font_heading_2));
            itextDoc.Add(new Paragraph("4. PERCENTAGE:  " + (theResult.Percentage / 100), font_heading_2));

            itextDoc.Add(new Paragraph("                                                                                                   2. COGNITIVE ASSESSMENT  ", font_heading_2));


            PdfPTable assessmentheader = new PdfPTable(1);

            assessmentheader.AddCell(new Phrase("PSYCHOMOTOR ASSESSMENT", font_heading_2));

            PdfPTable assessmentrecord = new PdfPTable(2);
            assessmentrecord.AddCell(new Phrase("Fluency", fntTableFont));
            assessmentrecord.AddCell(new Phrase(theResult.Fluency, fntTableFont));

            assessmentrecord.AddCell(new Phrase("Games", fntTableFont));
            assessmentrecord.AddCell(new Phrase(theResult.Games, fntTableFont));

            assessmentrecord.AddCell(new Phrase("Sports", fntTableFont));
            assessmentrecord.AddCell(new Phrase(theResult.Sports, fntTableFont));


            assessmentrecord.AddCell(new Phrase("Handling of Tools", fntTableFont));
            assessmentrecord.AddCell(new Phrase(theResult.HandlingofTools, fntTableFont));


            assessmentrecord.AddCell(new Phrase("Musical Skills", fntTableFont));
            assessmentrecord.AddCell(new Phrase(theResult.MusicalSkills, fntTableFont));



            PdfPTable assessmenteffectiveheader = new PdfPTable(1);

            assessmenteffectiveheader.AddCell(new Phrase("EFFECTIVE ASSESSMENT", font_heading_2));




            PdfPTable assessmenteffective = new PdfPTable(2);
            assessmenteffective.AddCell(new Phrase("Attentive and work Independently", fntTableFont));
            assessmenteffective.AddCell(new Phrase(theResult.AttentiveandWorkIndependently, fntTableFont));

            assessmenteffective.AddCell(new Phrase("Does homework regulary", fntTableFont));
            assessmenteffective.AddCell(new Phrase(theResult.DoesHomeworkRegularly, fntTableFont));

            assessmenteffective.AddCell(new Phrase("Is neat and orderly", fntTableFont));
            assessmenteffective.AddCell(new Phrase(theResult.IsNeatandOrderly, fntTableFont));


            assessmenteffective.AddCell(new Phrase("Respect authority", fntTableFont));
            assessmenteffective.AddCell(new Phrase(theResult.Respectauthority, fntTableFont));

            assessmenteffective.AddCell(new Phrase("Take care of Books and Property", fntTableFont));
            assessmenteffective.AddCell(new Phrase(theResult.TakeCareofBooksandProperty, fntTableFont));

            //assessmentrecord.AddCell(new Phrase("Musical Skills"));
            //assessmentrecord.AddCell(new Phrase(""));

            // PdfPTable assessment = new PdfPTable(1);

            //   itextDoc.Add(new Paragraph("   "));
            //  itextDoc.Add(new Paragraph("   "));


            PdfPTable meger = new PdfPTable(4);

            meger.HorizontalAlignment = 0;
            meger.TotalWidth = 500f;
            meger.LockedWidth = true;
            float[] widthsmeger = new float[] { 20f, 230f, 20f, 230f };
            meger.SetWidths(widthsmeger);
            meger.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            //   meger.AddCell("5");
            meger.AddCell((new Paragraph("5", font_heading_2)));
            meger.AddCell(assessmentheader);
            //  meger.AddCell("6");
            meger.AddCell(new Paragraph("6", font_heading_2));
            meger.AddCell(assessmenteffectiveheader);

            meger.AddCell(new Paragraph(""));
            meger.AddCell(assessmentrecord);
            meger.AddCell(new Paragraph(""));

            meger.AddCell(assessmenteffective);


            //  int counter = 1;



            //   itextDoc.Add(new Paragraph("   "));
            itextDoc.Add(new Paragraph("   "));
            itextDoc.Add(meger);

            itextDoc.Add(new Paragraph("   "));
            //   itextDoc.Add(table1);
            itextDoc.Add(new Paragraph("7. Club, Youth Organisation :", font_heading_2));
            itextDoc.Add(new Paragraph("8. Sport Activities ", font_heading_2));
            itextDoc.Add(new Paragraph("   "));


            PdfPTable comment = new PdfPTable(2);
            comment.HorizontalAlignment = 0;
            comment.TotalWidth = 500f;
            comment.LockedWidth = true;
            float[] widthscomment = new float[] { 400f, 100f };
            comment.SetWidths(widthscomment);
            comment.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            comment.AddCell(new Paragraph("FORM MASTER'S COMMENT: " + theResult.FormMastersComments, font_heading_2));

            comment.AddCell(new Paragraph("Master's Signature............", font_heading_2));

            comment.AddCell(new Paragraph("."));
            comment.AddCell(new Paragraph("."));

            comment.AddCell(new Paragraph("PRINCIPAL'S COMMENT: " + theResult.PrincipalsComment, font_heading_2));

            comment.AddCell(new Paragraph(" Signature, Sch. Stamp and Date........", font_heading_2));

            itextDoc.Add(comment);

            //  itextDoc.Add(new Paragraph("FORM MASTER'S COMMENT: " + theResult.FormMastersComments +          "     Master's Signature......................................", font_heading_2));
            // itextDoc.Add(new Paragraph(" Master's Signature ..................................................", font_heading_2));

            //  itextDoc.Add(new Paragraph("PRINCIPAL'S COMMENT : " + theResult.PrincipalsComment + "        Signature, Sch. Stamp and Date...............................", font_heading_2));

            // itextDoc.Add(new Paragraph("Signature, Sch. Stamp and Date...........................................", font_heading_2));
            return itextDoc;
        }
    }
}