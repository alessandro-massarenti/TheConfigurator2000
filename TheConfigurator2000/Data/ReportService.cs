using PdfSharp.Drawing;
using PdfSharp.Pdf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheConfigurator2000.Classes;

namespace TheConfigurator2000.Data
{
    public class ReportService : IReportService
    {

        public void GenerateReport(Quotation quotation)
        {
            PdfDocument document = new();
            document.Info.Title = quotation.Name;

            XFont titleFont = new("Arial", 20);
            XFont tableHeaderFont = new("Arial", 12, XFontStyle.Bold);
            XFont bodyFont = new("Arial", 12);

            XPen blackPen = new(XColor.FromArgb(0, 0, 0));


            PdfPage page = document.AddPage();


            XGraphics gfx = XGraphics.FromPdfPage(page);



            //Title
            gfx.DrawString(quotation.Name, titleFont, XBrushes.Black,
                new XPoint(200, 70));
            gfx.DrawString("€ " + quotation.GetTotalPrice().ToString(), bodyFont, XBrushes.Black,
                new XPoint(400, 70));
            gfx.DrawLine(blackPen,
                new XPoint(100, 100),
                new XPoint(500, 100));

            //Table header
            gfx.DrawString("Nome", tableHeaderFont, XBrushes.Black, new XPoint(100, 280));
            gfx.DrawString("Prezzo", tableHeaderFont, XBrushes.Black, new XPoint(400, 280));

            gfx.DrawLine(blackPen, new XPoint(50, 290), new XPoint(550, 290));

            int currentYposition_values = 303;
            int currentYposition_line = 310;
            int counter = 0;

            //table body
            foreach (var quotationProduct in quotation.QuotationProducts)
            {
                if (counter == 25)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    currentYposition_values = 33;
                    currentYposition_line = 40;
                    counter = 0;
                }

                

                gfx.DrawString("Quantity: " + quotationProduct.Count.ToString(), bodyFont,
                    XBrushes.Black,
                    new XPoint(100, currentYposition_values));
                gfx.DrawString("Total of row: €" + quotationProduct.GetTotal(), bodyFont,
                    XBrushes.Black,
                    new XPoint(400, currentYposition_values));

                gfx.DrawString(quotationProduct.Product.Name, bodyFont,
                    XBrushes.Black,
                    new XPoint(100, currentYposition_values + 20));
                gfx.DrawString("€" + quotationProduct.Product.Price, bodyFont,
                    XBrushes.Black,
                    new XPoint(400, currentYposition_values + 20));

                gfx.DrawLine(blackPen,
                    new XPoint(50, currentYposition_line + 20),
                    new XPoint(550, currentYposition_line + 20));

                currentYposition_values += 40;
                currentYposition_line += 40;
                counter++;
            }

            document.Save("C:\\Users\\amc002\\Downloads\\" + quotation.Name + ".pdf");
        }
    }
}
