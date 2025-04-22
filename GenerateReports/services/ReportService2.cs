using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using System;
using GenerateReports.Data;
using GenerateReports.Models;

namespace GenerateReports.services
{
    public class ReportService2 : IReportService2
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ReportService2(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<string> GenerateAndSaveExcelReportAsync()
        {
            var data = await _context.ReportItems.ToListAsync();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Report");

            // Column headers
            worksheet.Cell(1, 1).Value = "Sr No";
            worksheet.Cell(1, 2).Value = "ID";
            worksheet.Cell(1, 3).Value = "Name";
            worksheet.Cell(1, 4).Value = "Amount";
            worksheet.Cell(1, 5).Value = "Date";

            // Populating the rows with data
            for (int i = 0; i < data.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = i + 1;  // Sr No
                worksheet.Cell(i + 2, 2).Value = data[i].Id;
                worksheet.Cell(i + 2, 3).Value = data[i].Name;
                worksheet.Cell(i + 2, 4).Value = data[i].Amount;
                worksheet.Cell(i + 2, 5).Value = data[i].Date.ToShortDateString();
            }

            var reportsPath = Path.Combine(_env.ContentRootPath, FileConstants.ReportsFolder);
            Directory.CreateDirectory(reportsPath);

            string fileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            string fullPath = Path.Combine(reportsPath, fileName);

            workbook.SaveAs(fullPath);

            return fullPath;
        }
    }
}
