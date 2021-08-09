using System;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;


namespace LeitorPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(ExtrairTextodoPdf("TEST PDF TEXT.pdf"));
            Console.ReadKey();
        }
        static string ExtrairTextodoPdf(string NomedoArquivo)
        {
            string result=null;
            PdfReader pdfReader = new PdfReader(NomedoArquivo);
            PdfDocument pdfDoc = new PdfDocument(pdfReader);
            for (int page =1; page<=pdfDoc.GetNumberOfPages(); page++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                string conteudo = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
                result += conteudo;
            }
            pdfDoc.Close();
            pdfReader.Close();
            return result;
        }
    }
}
