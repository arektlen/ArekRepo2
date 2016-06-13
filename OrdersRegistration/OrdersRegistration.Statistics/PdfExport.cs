using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;

namespace OrdersRegistration.Statistics
{
    public class PdfExport
    {
        Statistic1 statistic1 = new Statistic1();

        /// <summary>
        /// Eksport do pliku PDF
        /// </summary>
        public void Statistic1ExportToPdf()
        {
            // Tworzenie nowego dokumentu PDF
            PdfDocument document = new PdfDocument();

            // Tworzenie pustej strony
            PdfPage page = document.AddPage();

            // Objekt XGraphics do rysowania
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Tworzenie czcionki
            XFont font = new XFont("Verdana", 14, XFontStyle.Bold);
            XFont font2 = new XFont("Vardana", 12, XFontStyle.Regular);
            XFont font3 = new XFont("Verdana", 18, XFontStyle.BoldItalic);

            // Rysowanie tekstu
            gfx.DrawString("STATYSTYKI PROGRAMU VOICEOVER", font3, XBrushes.Black,
              new XRect(20, 50, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("OGÓLNA liczba zleceń: ", font, XBrushes.Black,
              new XRect(40, 110, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(statistic1.GetOrdersCount().ToString(), font, XBrushes.Black,
             new XRect(240, 110, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Na łączną kwotę:", font2, XBrushes.Black,
             new XRect(40, 150, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(string.Format("{0:c}", statistic1.GetAllOrdersPrice()), font, XBrushes.Black,
             new XRect(240, 148, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Liczba zleceń nieopłaconych: ", font2, XBrushes.Black,
              new XRect(40, 190, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(statistic1.GetAllOrdersNonPaid().ToString(), font, XBrushes.Black,
             new XRect(240, 188, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Na łączną kwotę:", font2, XBrushes.Black,
             new XRect(40, 230, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(string.Format("{0:c}", statistic1.GetAllOrdersPriceNonPaid()), font, XBrushes.Black,
             new XRect(240, 228, page.Width, page.Height), XStringFormats.TopLeft);

            gfx.DrawString("LICZBA ZLECEŃ W BIEŻĄCYM MIESIĄCU:", font, XBrushes.Black,
             new XRect(40, 300, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(statistic1.GetOrdersCountInCurrentMonth().ToString(), font, XBrushes.Black,
             new XRect(380, 300, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Na łączną kwotę:", font2, XBrushes.Black,
             new XRect(40, 340, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(string.Format("{0:c}", statistic1.GetOrdersPriceInCurrentMonth()), font, XBrushes.Black,
             new XRect(240, 338, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Liczba zleceń nieopłaconych:", font2, XBrushes.Black,
             new XRect(40, 380, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(statistic1.GetOrdersCountNonPaidInMonth().ToString(), font, XBrushes.Black,
             new XRect(240, 378, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Na łączną kwotę:", font2, XBrushes.Black,
             new XRect(40, 420, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(string.Format("{0:c}", statistic1.GetOrdersPriceNonPaidInMonth()), font, XBrushes.Black,
             new XRect(240, 418, page.Width, page.Height), XStringFormats.TopLeft);

            // Zapis dokumentu
            string filename = "VoiceOver statystyki.pdf";
            document.Save(filename);

            // Start przeglądarki.
            Process.Start(filename);
        }
    }
}
