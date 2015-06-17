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
    public class PrintResult
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

            PdfPCell theWexFord = new PdfPCell(new Paragraph("SILVERDALE JUNIOR HIGH SCHOOL", font_heading_1));
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
            float[] widthsattendance = new float[] { 250f, 250f, 250f };
            attendance.SetWidths(widthsattendance);
            attendance.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            attendance.AddCell(new Paragraph(new Paragraph("")));
            attendance.AddCell(new Paragraph(new Paragraph("1. ATTENDANCE", font_heading_3)));
            attendance.AddCell(new Paragraph(new Paragraph("")));
            itextDoc.Add(attendance);

            PdfPTable attendanceopne = new PdfPTable(1);
            attendanceopne.HorizontalAlignment = 0;
            attendanceopne.TotalWidth = 500f;
            attendanceopne.LockedWidth = true;
            float[] widthsattendanceopne = new float[] { 500f };
            attendanceopne.SetWidths(widthsattendanceopne);
            attendanceopne.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            attendanceopne.AddCell(new Paragraph(new Paragraph("NO. OF TIMES SCHOOL OPENED:  " + theResult.NoofTimesSchoolOpened, font_heading_2)));

            attendanceopne.AddCell(new Paragraph(new Paragraph("NO. OF TIMES PRESENT:  " + theResult.NoofTimesPresent, font_heading_2)));
            attendanceopne.AddCell(new Paragraph(new Paragraph("NO. OF TIMES PUNCTUAL:  " + theResult.NoofTimesPunctual, font_heading_2)));
            attendanceopne.AddCell(new Paragraph(new Paragraph("NO. OF TIMES ABSENT:  " + theResult.NoofTimesAbsent, font_heading_2)));


            itextDoc.Add(attendanceopne);



            PdfPTable table = new PdfPTable(19);

            table.TotalWidth = 700f;
            table3.LockedWidth = true;
            float[] widthstable = new float[] { 50f, 36f, 36f, 36f, 36f, 36f, 36f, 36f, 36f, 36f, 36f, 36f, 36f, 36f, 36f, 36f, 36f, 36f, 36f };
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


            PdfPCell english = new PdfPCell(new Phrase("English Language", fntTableFont));
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


            PdfPCell basic = new PdfPCell(new Phrase("Basic Sci.", fntTableFont));
            basic.Rotation = 90;
            basic.Rowspan = 1;
            basic.VerticalAlignment = Element.ALIGN_TOP;
            basic.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(basic);


            PdfPCell social = new PdfPCell(new Phrase("Social Studies", fntTableFont));
            social.Rotation = 90;
            social.Rowspan = 1;
            social.VerticalAlignment = Element.ALIGN_TOP;
            social.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(social);


            PdfPCell home = new PdfPCell(new Phrase("Home Econs.", fntTableFont));
            home.Rotation = 90;
            home.Rowspan = 1;
            home.VerticalAlignment = Element.ALIGN_TOP;
            home.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(home);


            PdfPCell yoruba = new PdfPCell(new Phrase("Yor/Igbo/Hausa", fntTableFont));
            yoruba.Rotation = 90;
            yoruba.Rowspan = 1;
            yoruba.VerticalAlignment = Element.ALIGN_TOP;
            yoruba.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(yoruba);


            PdfPCell french = new PdfPCell(new Phrase("French", fntTableFont));
            french.Rotation = 90;
            french.Rowspan = 1;
            french.VerticalAlignment = Element.ALIGN_TOP;
            french.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(french);


            PdfPCell computer = new PdfPCell(new Phrase("Computer", fntTableFont));
            computer.Rotation = 90;
            computer.Rowspan = 1;
            computer.VerticalAlignment = Element.ALIGN_TOP;
            computer.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(computer);


            PdfPCell crk = new PdfPCell(new Phrase("C.R.K/I.R.K", fntTableFont));
            crk.Rotation = 90;
            crk.Rowspan = 1;
            crk.VerticalAlignment = Element.ALIGN_TOP;
            crk.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(crk);


            PdfPCell civil = new PdfPCell(new Phrase("Civil Education", fntTableFont));
            civil.Rotation = 90;
            civil.Rowspan = 1;
            civil.VerticalAlignment = Element.ALIGN_TOP;
            civil.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(civil);


            PdfPCell basicT = new PdfPCell(new Phrase("Basic Tech.", fntTableFont));
            basicT.Rotation = 90;
            basicT.Rowspan = 1;
            basicT.VerticalAlignment = Element.ALIGN_TOP;
            basicT.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(basicT);


            PdfPCell fineA = new PdfPCell(new Phrase("Fine Art", fntTableFont));
            fineA.Rotation = 90;
            fineA.Rowspan = 1;
            fineA.VerticalAlignment = Element.ALIGN_TOP;
            fineA.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(fineA);


            PdfPCell agric = new PdfPCell(new Phrase("Agric. Sci.", fntTableFont));
            agric.Rotation = 90;
            agric.Rowspan = 1;
            agric.VerticalAlignment = Element.ALIGN_TOP;
            agric.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(agric);

            PdfPCell phe = new PdfPCell(new Phrase("P.H.E", fntTableFont));
            phe.Rotation = 90;
            phe.Rowspan = 1;
            phe.VerticalAlignment = Element.ALIGN_TOP;
            phe.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(phe);


            PdfPCell music = new PdfPCell(new Phrase("Music", fntTableFont));
            music.Rotation = 90;
            music.Rowspan = 1;
            music.VerticalAlignment = Element.ALIGN_TOP;
            music.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(music);

            PdfPCell bus = new PdfPCell(new Phrase("Bus Stud.", fntTableFont));
            bus.Rotation = 90;
            bus.Rowspan = 1;
            bus.VerticalAlignment = Element.ALIGN_TOP;
            bus.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(bus);


            PdfPCell ro = new PdfPCell(new Phrase("Royal English", fntTableFont));
            ro.Rotation = 90;
            ro.Rowspan = 1;
            ro.VerticalAlignment = Element.ALIGN_TOP;
            bus.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(ro);

            //get the table creation to perspective


            // attendance record
            for (int t = 1; t <= 19; t++)
            {
                if (t == 1)
                {
                    table.AddCell(new PdfPCell(new Phrase("Attendance (%)", fntTableFont)));
                }
                if (t == 2)
                {
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                }
                if (t == 3)
                {
                    if (theResult.EnglishLanguage_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.EnglishLanguage_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 4)
                {
                    if (theResult.Mathematics_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Mathematics_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 5)
                {
                    if (theResult.BasicScience_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.BasicScience_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 6)
                {
                    if (theResult.SocialStudies_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.SocialStudies_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 7)
                {
                    if (theResult.HomeEconomics_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.HomeEconomics_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 8)
                {
                    if (theResult.Yoruba_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Yoruba_Attendance.ToString(), fntTableFont)));
                    }
                    if (theResult.Igbo_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Igbo_Attendance.ToString(), fntTableFont)));
                    }
                    if (theResult.Hausa_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Hausa_Attendance.ToString(), fntTableFont)));
                    }
                    //else
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //}

                }

                if (t == 9)
                {
                    if (theResult.French_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.French_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 10)
                {
                    if (theResult.Computer_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Computer_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 11)
                {
                    if (theResult.ChristianReligiousKnowledge_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.ChristianReligiousKnowledge_Attendance.ToString(), fntTableFont)));
                    }
                    if (theResult.IslamicReligiousKnowledge_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.IslamicReligiousKnowledge_Attendance.ToString(), fntTableFont)));
                    }
                    //else
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //}

                }

                if (t == 12)
                {
                    if (theResult.CivicEducation_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.CivicEducation_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 13)
                {
                    if (theResult.BasicTechnology_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.BasicTechnology_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 14)
                {
                    if (theResult.CreativeArt_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.CreativeArt_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }
                if (t == 15)
                {
                    if (theResult.AgriculturalScience_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.AgriculturalScience_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 16)
                {
                    if (theResult.PhysicalHealthEducation_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.PhysicalHealthEducation_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }


                if (t == 17)
                {
                    if (theResult.Music_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Music_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 18)
                {
                    if (theResult.BusinessStudies_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.BusinessStudies_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 19)
                {
                    if (theResult.RoyalEnglish_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.RoyalEnglish_Attendance.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }
            }
            // ContinuousAssessment


            for (int t = 1; t <= 19; t++)
            {
                if (t == 1)
                {
                    table.AddCell(new PdfPCell(new Phrase("Con. Asses. Score.", fntTableFont)));
                }
                if (t == 2)
                {
                    table.AddCell(new PdfPCell(new Phrase("40", fntTableFont)));
                }
                if (t == 3)
                {
                    if (theResult.EnglishLanguage_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.EnglishLanguage_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 4)
                {
                    if (theResult.Mathematics_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Mathematics_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 5)
                {
                    if (theResult.BasicScience_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.BasicScience_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 6)
                {
                    if (theResult.SocialStudies_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.SocialStudies_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 7)
                {
                    if (theResult.HomeEconomics_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.HomeEconomics_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 8)
                {
                    if (theResult.Yoruba_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Yoruba_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    if (theResult.Igbo_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Igbo_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    if (theResult.Hausa_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Hausa_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    //else
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //}

                }

                if (t == 9)
                {
                    if (theResult.French_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.French_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 10)
                {
                    if (theResult.Computer_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Computer_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 11)
                {
                    if (theResult.ChristianReligiousKnowledge_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.ChristianReligiousKnowledge_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    if (theResult.IslamicReligiousKnowledge_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.IslamicReligiousKnowledge_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    //else
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //}

                }

                if (t == 12)
                {
                    if (theResult.CivicEducation_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.CivicEducation_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 13)
                {
                    if (theResult.BasicTechnology_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.BasicTechnology_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 14)
                {
                    if (theResult.CreativeArt_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.CreativeArt_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }
                if (t == 15)
                {
                    if (theResult.AgriculturalScience_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.AgriculturalScience_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 16)
                {
                    if (theResult.PhysicalHealthEducation_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.PhysicalHealthEducation_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }


                if (t == 17)
                {
                    if (theResult.Music_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Music_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 18)
                {
                    if (theResult.BusinessStudies_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.BusinessStudies_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 19)
                {
                    if (theResult.RoyalEnglish_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.RoyalEnglish_ContinuousAssessment.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }
            }




            //eXAM SCORE
            for (int t = 1; t <= 19; t++)
            {
                if (t == 1)
                {
                    table.AddCell(new PdfPCell(new Phrase("Exam Score", fntTableFont)));
                }
                if (t == 2)
                {
                    table.AddCell(new PdfPCell(new Phrase("60", fntTableFont)));
                }
                if (t == 3)
                {
                    if (theResult.EnglishLanguage_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.EnglishLanguage_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 4)
                {
                    if (theResult.Mathematics_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Mathematics_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 5)
                {
                    if (theResult.BasicScience_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.BasicScience_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 6)
                {
                    if (theResult.SocialStudies_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.SocialStudies_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 7)
                {
                    if (theResult.HomeEconomics_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.HomeEconomics_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 8)
                {
                    if (theResult.Yoruba_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Yoruba_ExaminationScore.ToString(), fntTableFont)));
                    }
                    if (theResult.Igbo_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Igbo_ExaminationScore.ToString(), fntTableFont)));
                    }
                    if (theResult.Hausa_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Hausa_ExaminationScore.ToString(), fntTableFont)));
                    }
                    //else
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //}

                }

                if (t == 9)
                {
                    if (theResult.French_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.French_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 10)
                {
                    if (theResult.Computer_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Computer_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 11)
                {
                    if (theResult.ChristianReligiousKnowledge_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.ChristianReligiousKnowledge_ExaminationScore.ToString(), fntTableFont)));
                    }
                    if (theResult.IslamicReligiousKnowledge_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.IslamicReligiousKnowledge_ExaminationScore.ToString(), fntTableFont)));
                    }
                    //else
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //}

                }

                if (t == 12)
                {
                    if (theResult.CivicEducation_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.CivicEducation_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 13)
                {
                    if (theResult.BasicTechnology_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.BasicTechnology_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 14)
                {
                    if (theResult.CreativeArt_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.CreativeArt_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }
                if (t == 15)
                {
                    if (theResult.AgriculturalScience_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.AgriculturalScience_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 16)
                {
                    if (theResult.PhysicalHealthEducation_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.PhysicalHealthEducation_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }


                if (t == 17)
                {
                    if (theResult.Music_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Music_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 18)
                {
                    if (theResult.BusinessStudies_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.BusinessStudies_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 19)
                {
                    if (theResult.RoyalEnglish_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.RoyalEnglish_ExaminationScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }
            }









            //Total Score
            for (int t = 1; t <= 19; t++)
            {
                if (t == 1)
                {
                    table.AddCell(new PdfPCell(new Phrase("Total Score", fntTableFont)));
                }
                if (t == 2)
                {
                    table.AddCell(new PdfPCell(new Phrase("100", fntTableFont)));
                }
                if (t == 3)
                {
                    if (theResult.EnglishLanguage_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.EnglishLanguage_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 4)
                {
                    if (theResult.Mathematics_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Mathematics_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 5)
                {
                    if (theResult.BasicScience_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.BasicScience_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 6)
                {
                    if (theResult.SocialStudies_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.SocialStudies_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 7)
                {
                    if (theResult.HomeEconomics_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.HomeEconomics_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 8)
                {
                    if (theResult.Yoruba_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Yoruba_TotalScore.ToString(), fntTableFont)));
                    }
                    if (theResult.Igbo_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Igbo_TotalScore.ToString(), fntTableFont)));
                    }
                    if (theResult.Hausa_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Hausa_TotalScore.ToString(), fntTableFont)));
                    }
                    //else
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //}

                }

                if (t == 9)
                {
                    if (theResult.French_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.French_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 10)
                {
                    if (theResult.Computer_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Computer_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 11)
                {
                    if (theResult.ChristianReligiousKnowledge_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.ChristianReligiousKnowledge_TotalScore.ToString(), fntTableFont)));
                    }
                    if (theResult.IslamicReligiousKnowledge_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.IslamicReligiousKnowledge_TotalScore.ToString(), fntTableFont)));
                    }
                    //else
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //}

                }

                if (t == 12)
                {
                    if (theResult.CivicEducation_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.CivicEducation_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 13)
                {
                    if (theResult.BasicTechnology_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.BasicTechnology_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 14)
                {
                    if (theResult.CreativeArt_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.CreativeArt_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }
                if (t == 15)
                {
                    if (theResult.AgriculturalScience_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.AgriculturalScience_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 16)
                {
                    if (theResult.PhysicalHealthEducation_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.PhysicalHealthEducation_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }


                if (t == 17)
                {
                    if (theResult.Music_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.Music_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 18)
                {
                    if (theResult.BusinessStudies_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.BusinessStudies_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 19)
                {
                    if (theResult.RoyalEnglish_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(theResult.RoyalEnglish_TotalScore.ToString(), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }
            }





            //Grade / subject
            for (int t = 1; t <= 19; t++)
            {
                if (t == 1)
                {
                    table.AddCell(new PdfPCell(new Phrase("Grade Per Subject", fntTableFont)));
                }
                if (t == 2)
                {
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                }
                if (t == 3)
                {
                    if (theResult.EnglishLanguage_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.EnglishLanguage_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 4)
                {
                    if (theResult.Mathematics_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.Mathematics_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 5)
                {
                    if (theResult.BasicScience_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.BasicScience_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 6)
                {
                    if (theResult.SocialStudies_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.SocialStudies_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 7)
                {
                    if (theResult.HomeEconomics_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.HomeEconomics_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 8)
                {
                    if (theResult.Yoruba_Attendance > 0 || theResult.Igbo_Attendance > 0 || theResult.Hausa_Attendance > 0)
                    {
                        if (theResult.Yoruba_Attendance > 0)
                        {
                            table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.Yoruba_TotalScore), fntTableFont)));
                        }
                        if (theResult.Igbo_Attendance > 0)
                        {
                            table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.Igbo_TotalScore), fntTableFont)));
                        }
                        if (theResult.Hausa_Attendance > 0)
                        {
                            table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.Hausa_TotalScore), fntTableFont)));
                        }
                    }

                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 9)
                {
                    if (theResult.French_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.French_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 10)
                {
                    if (theResult.Computer_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.Computer_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 11)
                {
                    if (theResult.ChristianReligiousKnowledge_Attendance > 0 || theResult.IslamicReligiousKnowledge_Attendance > 0)
                    {
                        if (theResult.ChristianReligiousKnowledge_Attendance > 0)
                        {
                            table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.ChristianReligiousKnowledge_TotalScore), fntTableFont)));
                        }
                        if (theResult.IslamicReligiousKnowledge_Attendance > 0)
                        {
                            table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.ChristianReligiousKnowledge_TotalScore), fntTableFont)));
                        }
                    }
                   
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 12)
                {
                    if (theResult.CivicEducation_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.CivicEducation_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 13)
                {
                    if (theResult.BasicTechnology_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.BasicTechnology_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 14)
                {
                    if (theResult.CreativeArt_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.CreativeArt_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }
                if (t == 15)
                {
                    if (theResult.AgriculturalScience_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.AgriculturalScience_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 16)
                {
                    if (theResult.PhysicalHealthEducation_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.PhysicalHealthEducation_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }


                if (t == 17)
                {
                    if (theResult.Music_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.Music_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 18)
                {
                    if (theResult.BusinessStudies_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.BusinessStudies_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }

                if (t == 19)
                {
                    if (theResult.RoyalEnglish_Attendance > 0)
                    {
                        table.AddCell(new PdfPCell(new Phrase(GradeCalculator.Calculate(theResult.RoyalEnglish_TotalScore), fntTableFont)));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    }

                }
            }

            //Grade / subject
            for (int t = 1; t <= 19; t++)
            {
                if (t == 1)
                {
                    table.AddCell(new PdfPCell(new Phrase("Teacher's Sign", fntTableFont)));
                }
                if (t == 2)
                {
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                }
                if (t == 3)
                {
                    //if (theResult.EnglishLanguage_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.EnglishLanguage_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //   }

                }

                if (t == 4)
                {
                    //if (theResult.Mathematics_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.Mathematics_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    // }

                }

                if (t == 5)
                {
                    //if (theResult.BasicScience_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.BasicScience_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    // }

                }

                if (t == 6)
                {
                    //if (theResult.SocialStudies_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.SocialStudies_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //  }

                }

                if (t == 7)
                {
                    //if (theResult.HomeEconomics_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.HomeEconomics_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //    }

                }

                if (t == 8)
                {
                    //if (theResult.Yoruba_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.Yoruba_TotalScore.ToString(), fntTableFont)));
                    //}
                    //if (theResult.Igbo_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.Igbo_TotalScore.ToString(), fntTableFont)));
                    //}
                    //if (theResult.Hausa_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.Hausa_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //}

                }

                if (t == 9)
                {
                    //if (theResult.French_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.French_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    ////{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    // }

                }

                if (t == 10)
                {
                    //    if (theResult.Computer_Attendance > 0)
                    //    {
                    //        table.AddCell(new PdfPCell(new Phrase(theResult.Computer_TotalScore.ToString(), fntTableFont)));
                    //    }
                    //    else
                    //    {
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //  }

                }

                if (t == 11)
                {
                    //if (theResult.ChristianReligiousKnowledge_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.ChristianReligiousKnowledge_TotalScore.ToString(), fntTableFont)));
                    //}
                    //if (theResult.IslamicReligiousKnowledge_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.IslamicReligiousKnowledge_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //}

                }

                if (t == 12)
                {
                    //if (theResult.CivicEducation_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.CivicEducation_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //  }

                }

                if (t == 13)
                {
                    //if (theResult.BasicTechnology_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.BasicTechnology_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //}

                }

                if (t == 14)
                {
                    //if (theResult.CreativeArt_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.CreativeArt_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //  }

                }
                if (t == 15)
                {
                    //if (theResult.AgriculturalScience_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.AgriculturalScience_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //   }

                }

                if (t == 16)
                {
                    //if (theResult.PhysicalHealthEducation_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.PhysicalHealthEducation_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    // }

                }


                if (t == 17)
                {
                    //if (theResult.Music_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.Music_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    // }

                }

                if (t == 18)
                {
                    //if (theResult.BusinessStudies_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.BusinessStudies_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    // }

                }

                if (t == 19)
                {
                    //if (theResult.RoyalEnglish_Attendance > 0)
                    //{
                    //    table.AddCell(new PdfPCell(new Phrase(theResult.RoyalEnglish_TotalScore.ToString(), fntTableFont)));
                    //}
                    //else
                    //{
                    table.AddCell(new PdfPCell(new Phrase("", fntTableFont)));
                    //}

                }
            }





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