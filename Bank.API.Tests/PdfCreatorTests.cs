using System.IO;
using Bank.API.Services.PdfService;
using NUnit.Framework;
using PdfSharp.Pdf;

namespace Bank.API.Tests;

public class PdfCreatorTests
{
    [SetUp]
    public void Setup()
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
    }

    [Test]
    [TestCase(1)]
    [TestCase(15220)]
    public void GeneratePdfShouldSuccessWhenValidIdWasPassed(int id)
    {
        PdfCreator pdfCreator = new PdfCreator();
        
        var document = pdfCreator.GeneratePdf(id);
        
        Assert.IsNotNull(document);
        Assert.IsInstanceOf<PdfDocument>(document);
    }

    [Test]
    public void ConvertPdfToMemoryStreamShouldReturnMemoryStreamWithValidInput()
    {
        var pdfCreator = new PdfCreator();
        var document = pdfCreator.GeneratePdf(10);

        var result = pdfCreator.ConvertPdfToMemoryStream(document);
        
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<MemoryStream>(result);
    }
    
    [Test]
    public void ConvertPdfToMemoryStreamShouldReturnNonEmptyResult()
    {
        var pdfCreator = new PdfCreator();
        var document = pdfCreator.GeneratePdf(10);

        var result = pdfCreator.ConvertPdfToMemoryStream(document);
        
        Assert.IsTrue(result.Length > 0);
    }
}