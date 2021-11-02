using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using project.pole.Services.Base;

namespace project.pole.Services
{
    public class EstimateService: IEstimateService
    {
        /// <summary>
        /// Generates a estimate file and save file and info about file to DB
        /// </summary>
        /// <returns>Return estimate</returns>
        public void Generate()
        {
            var name = "test";
            var path = "C:/Estimate/";
            var fullPath = $"{path}{name}.pdf";

            var write = new PdfWriter(fullPath);

            var pdfDoc = new PdfDocument(write);

            using (pdfDoc)
            {
                var document = new Document(pdfDoc);

                var header = new Paragraph("СМЕТА")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(14);
                document.Add(header);

                var subheader = new Paragraph("на проектные (изыскательские) работы")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(12);

                document.Add(subheader);

                float [] pointColumnWidths = {150F, 150F, 150F};
                Table table = new(pointColumnWidths);

                table.AddCell("№ п/п");
                table.AddCell("Наименование вида работ");
                table.AddCell("Позиция по справочнику");
                table.AddCell("Кол-во");
                table.AddCell("Ед. измерения");
                table.AddCell("Ст-сть ед., руб");
                table.AddCell("Ст-сть ед., руб");
                table.AddCell("Всего, руб");
                table.AddCell("Примечания");

                document.Add(table);
                document.Close();
            }
        }
    }
}