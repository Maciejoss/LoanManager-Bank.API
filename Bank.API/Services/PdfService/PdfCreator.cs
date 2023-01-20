using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Bank.API.Services.PdfService;

public class PdfCreator
{
    public MemoryStream CreateDocument(int offerId)
    {
        var document = GeneratePdf(offerId);

        return ConvertPdfToMemoryStream(document);
    }

    public PdfDocument GeneratePdf(int offerId)
    {
        var document = new PdfDocument();
        var page = document.AddPage();
        
        var gfx = XGraphics.FromPdfPage(page);
        
        XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode);
        
        XFont font = new XFont("Arial", 20, XFontStyle.Bold, options);
        
        gfx.DrawString($"Offer {offerId} document", font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height),
            XStringFormats.Center);
        
        string filename = $"{offerId}.pdf";

        return document;
    }

    public MemoryStream ConvertPdfToMemoryStream(PdfDocument document)
    {
        var stream = new MemoryStream();
        document.Save(stream, false);
        return stream;
    }
}