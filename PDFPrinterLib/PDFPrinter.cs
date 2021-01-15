using IronPdf;
using System;

namespace PDFPrinterLib
{
    public class PDFPrinter
    {
        static PDFPrinter()
        {
            License.LicenseKey = @"your-lisc-key-here";
        }

        /// <summary>
        /// Prints HTML document into PDF byte array
        /// </summary>
        public static byte[] GetPDFData(string html, string baseurl)
        {
            bool usesMetric = System.Globalization.RegionInfo.CurrentRegion.IsMetric;
            var pagesize = (usesMetric) ? PdfPrintOptions.PdfPaperSize.A4 : PdfPrintOptions.PdfPaperSize.Letter;

            if (string.IsNullOrEmpty(html) || string.IsNullOrEmpty(baseurl))
            {
                return null;
            }

            var renderer = new HtmlToPdf();
            renderer.PrintOptions = new PdfPrintOptions
            {
                CssMediaType = PdfPrintOptions.PdfCssMediaType.Print,
                EnableJavaScript = true,
                PaperSize = pagesize,
                PrintHtmlBackgrounds = true,
                FitToPaperWidth = true,
                MarginBottom = 0,
                MarginLeft = 0,
                MarginRight = 0,
                MarginTop = 0,
                Zoom = 100,
            };

            Log($@"Sending to PDF Generator with options {renderer.PrintOptions}");
            Log(@"");

            var PDF = renderer.RenderHtmlAsPdf(html, baseurl);

            Log($@"Returned the PDF document as response {PDF.BinaryData.Length}");
            Log(@"");

            return PDF.BinaryData;
        }

        #region helpers
        static void Log(string message)
        {
            Console.WriteLine(message);
        }
        #endregion
    }
}
