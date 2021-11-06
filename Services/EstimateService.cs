using System.IO;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using project.pole.Data.Base;
using project.pole.Data.Repositories;
using project.pole.Models;

namespace project.pole.Services
{
    public class EstimateService : IEstimateService
    {
        private readonly IObjectWorkRepository _objectWorkRepository;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objectWorkRepository"></param>
        /// <param name="customerRepository"></param>
        public EstimateService(IObjectWorkRepository objectWorkRepository, ICustomerRepository customerRepository)
        {
            _objectWorkRepository = objectWorkRepository;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Generates a estimate file
        /// </summary>
        /// <returns>Byte estimate file</returns>
        public byte[] Generate(long objectWorkId)
        {
            var customerName1 = _customerRepository.Find(2);
            var objectWork = _objectWorkRepository.Find(objectWorkId);
            var customerName = _customerRepository.Find(objectWork.CustomerId);

            byte[] estimateFile;

            using (var memoryStream = new MemoryStream())
            {
                var pdfWriter = new PdfWriter(memoryStream);
                var pdfDoc = new PdfDocument(pdfWriter);

                var pathFont = @$"{Directory.GetCurrentDirectory()}\wwwroot\fonts\arial.ttf";
                var fontProgram = FontProgramFactory.CreateFont(pathFont);
                var arial = PdfFontFactory.CreateFont(fontProgram);

                var document = new Document(pdfDoc);

                var header = new Paragraph($"СМЕТА")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(12)
                    .SetFont(arial);
                document.Add(header);

                var subheader = new Paragraph("на проектные (изыскательские) работы")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(10)
                    .SetFont(arial);
                document.Add(subheader);

                Table tableNoBorder = new(new[] {300F, 300F});
                tableNoBorder.SetBorder(Border.NO_BORDER);
                tableNoBorder.SetFont(arial).SetFontSize(10);
                tableNoBorder
                    .AddCell(
                        "Наименование предприятия, здания, сооружения, стадии проектирования, этапа, вида проектных или изыскательских работ")
                    .SetBorder(Border.NO_BORDER);
                tableNoBorder.AddCell("").SetBorder(Border.NO_BORDER);

                tableNoBorder.AddCell("ИСПОЛНИТЕЛЬ:");
                tableNoBorder.AddCell("ООО ГеоГрадСтрой");

                tableNoBorder.AddCell("ЗАКАЗЧИК:");
                tableNoBorder.AddCell($"{customerName}");

                tableNoBorder.AddCell("Площадь участка, Га");
                tableNoBorder.AddCell($"{objectWork.PlotArea}");

                tableNoBorder.AddCell("Площадь зданий, кв. м");
                tableNoBorder.AddCell($"{objectWork.BuildingArea}");

                tableNoBorder.AddCell("Глубина котлована, м");
                tableNoBorder.AddCell($"{objectWork.PitDepth}");
                document.Add(tableNoBorder);

                var subheaderTable =
                    new Paragraph(
                            "Расчет стоимости работ произведен по справочнику базовых цен на инженерно-геологические и инженерно-экологические изыскания для строительства ВНИИС (1999 г.)")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(10)
                        .SetFont(arial);
                document.Add(subheaderTable);

                float[] pointColumnWidths = {50F, 150F, 100F, 75F, 75F, 80F, 80F, 100F};
                Table table = new(pointColumnWidths);
                table.SetFont(arial).SetTextAlignment(TextAlignment.CENTER).SetFontSize(10);
                table.AddCell("№ п/п");
                table.AddCell("Наименование вида работ");
                table.AddCell("Позиция по справочнику");
                table.AddCell("Кол-во");
                table.AddCell("Ед. измерения");
                table.AddCell("Ст-сть ед., руб");
                table.AddCell("Всего, руб");
                table.AddCell("Примечания");

                document.Add(table);
                document.Close();

                estimateFile = memoryStream.ToArray();
            }

            return estimateFile;
        }
    }
}