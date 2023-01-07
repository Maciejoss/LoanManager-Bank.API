using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Bank.API.Services.PdfService;

public class PdfCreator
{
    public PdfDocument CreateDocument(int offerId)
    {
        var document = new PdfDocument();
        var page = document.AddPage();
        
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
        
        gfx.DrawString($"Offer {offerId} document", font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height),
            XStringFormat.Center);
        
        string filename = $"{offerId}.pdf";

        return document;
    }
}