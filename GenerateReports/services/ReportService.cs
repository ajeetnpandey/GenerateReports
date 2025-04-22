using ClosedXML.Excel;
using GenerateReports.Data;

namespace GenerateReports.services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public byte[] GenerateExcelReport()
        {
            var data = _context.ReportItems.ToList();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Report");

            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Name";
            worksheet.Cell(1, 3).Value = "Amount";
            worksheet.Cell(1, 4).Value = "Date";

            for (int i = 0; i < data.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = data[i].Id;
                worksheet.Cell(i + 2, 2).Value = data[i].Name;
                worksheet.Cell(i + 2, 3).Value = data[i].Amount;
                worksheet.Cell(i + 2, 4).Value = data[i].Date.ToShortDateString();
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}