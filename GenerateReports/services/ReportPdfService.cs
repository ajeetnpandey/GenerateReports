using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using GenerateReports.Data;
using GenerateReports.Models;

namespace GenerateReports.services
{
    public class ReportPdfService : IReportPdfService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ReportPdfService(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        //public async Task<string> GenerateAndSavePdfReportAsync()
        //{
        //    var data = await _context.ReportItems.ToListAsync();
        //    var reportsPath = Path.Combine(_env.ContentRootPath, FileConstants.ReportsFolder);
        //    Directory.CreateDirectory(reportsPath);

        //    string fileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        //    string fullPath = Path.Combine(reportsPath, fileName);

        //    Document.Create(container =>
        //    {
        //        container.Page(page =>
        //        {
        //            page.Margin(30);
        //            page.Content()
        //                .Table(table =>
        //                {
        //                    table.ColumnsDefinition(columns =>
        //                    {
        //                        columns.RelativeColumn(1);
        //                        columns.RelativeColumn(3);
        //                        columns.RelativeColumn(2);
        //                        columns.RelativeColumn(3);
        //                    });

        //                    table.Header(header =>
        //                    {
        //                        header.Cell().Element(CellStyle).Text("ID");
        //                        header.Cell().Element(CellStyle).Text("Name");
        //                        header.Cell().Element(CellStyle).Text("Amount");
        //                        header.Cell().Element(CellStyle).Text("Date");

        //                        static IContainer CellStyle(IContainer container) =>
        //                            container.Padding(5).Background("#EEE").BorderBottom(1).BorderColor("#CCC");
        //                    });

        //                    foreach (var item in data)
        //                    {
        //                        table.Cell().Element(CellStyle).Text(item.Id.ToString());
        //                        table.Cell().Element(CellStyle).Text(item.Name);
        //                        table.Cell().Element(CellStyle).Text(item.Amount.ToString("C"));
        //                        table.Cell().Element(CellStyle).Text(item.Date.ToShortDateString());

        //                        static IContainer CellStyle(IContainer container) =>
        //                            container.Padding(5).BorderBottom(1).BorderColor("#DDD");
        //                    }
        //                });
        //        });
        //    }).GeneratePdf(fullPath);

        //    return fullPath;
        //}
        //}

        //public async Task<string> GenerateAndSavePdfReportAsync()
        //{
        //    // ✅ Set license type to avoid exception
        //    QuestPDF.Settings.License = LicenseType.Community;

        //    var data = await _context.ReportItems.ToListAsync();
        //    var reportsPath = Path.Combine(_env.ContentRootPath, "Reports");
        //    Directory.CreateDirectory(reportsPath);

        //    string fileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        //    string fullPath = Path.Combine(reportsPath, fileName);

        //    Document.Create(container =>
        //    {
        //        container.Page(page =>
        //        {
        //            int Sr = 1;
        //            page.Margin(30);
        //            page.Content()
        //                .Table(table =>
        //                {
        //                    table.ColumnsDefinition(columns =>
        //                    {
        //                        columns.RelativeColumn(1);
        //                        columns.RelativeColumn(3);
        //                        columns.RelativeColumn(2);
        //                        columns.RelativeColumn(3);
        //                    });

        //                    table.Header(header =>
        //                    {
        //                        header.Cell().Element(CellStyle).Text("Sr.No");
        //                        header.Cell().Element(CellStyle).Text("ID");
        //                        header.Cell().Element(CellStyle).Text("Name");
        //                        header.Cell().Element(CellStyle).Text("Amount");
        //                        header.Cell().Element(CellStyle).Text("Date");

        //                        static IContainer CellStyle(IContainer container) =>
        //                            container.Padding(5).Background("#EEE").BorderBottom(1).BorderColor("#CCC");
        //                    });

        //                    foreach (var item in data)
        //                    {
        //                        table.Cell().Element(CellStyle).Text(item.SrNo);
        //                        table.Cell().Element(CellStyle).Text(item.Id.ToString());
        //                        table.Cell().Element(CellStyle).Text(item.Name);
        //                        table.Cell().Element(CellStyle).Text(item.Amount.ToString("C"));
        //                        table.Cell().Element(CellStyle).Text(item.Date.ToShortDateString());

        //                        static IContainer CellStyle(IContainer container) =>
        //                            container.Padding(5).BorderBottom(1).BorderColor("#DDD");
        //                    }
        //                });
        //        });
        //    }).GeneratePdf(fullPath);

        //    return fullPath;
        //}

        //public async Task<string> GenerateAndSavePdfReportAsync()
        //{
        //    QuestPDF.Settings.License = LicenseType.Community;

        //    var data = await _context.ReportItems.ToListAsync();
        //    var reportsPath = Path.Combine(_env.ContentRootPath, "Reports");
        //    Directory.CreateDirectory(reportsPath);

        //    string fileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        //    string fullPath = Path.Combine(reportsPath, fileName);

        //    Document.Create(container =>
        //    {
        //        container.Page(page =>
        //        {
        //            page.Margin(30);
        //            page.Content()
        //                .Table(table =>
        //                {
        //                    table.ColumnsDefinition(columns =>
        //                    {
        //                        columns.RelativeColumn(1); // Sr. No.
        //                        columns.RelativeColumn(2); // ID
        //                        columns.RelativeColumn(3); // Name
        //                        columns.RelativeColumn(2); // Amount
        //                        columns.RelativeColumn(3); // Date
        //                    });

        //                    // Header row
        //                    table.Header(header =>
        //                    {
        //                        header.Cell().Element(CellStyle).Text("SrNo");
        //                        header.Cell().Element(CellStyle).Text("ID");
        //                        header.Cell().Element(CellStyle).Text("Name");
        //                        header.Cell().Element(CellStyle).Text("Amount");
        //                        header.Cell().Element(CellStyle).Text("Date");

        //                        static IContainer CellStyle(IContainer container) =>
        //                            container.Padding(5).Background("#EEE").BorderBottom(1).BorderColor("#CCC");
        //                    });

        //                    // Data rows with auto-incremented Sr. No
        //                    int srNo = 1;
        //                    foreach (var item in data)
        //                    {
        //                        table.Cell().Element(CellStyle).Text(srNo++.ToString()); // Sr.No
        //                        table.Cell().Element(CellStyle).Text(item.Id.ToString());
        //                        table.Cell().Element(CellStyle).Text(item.Name);
        //                        table.Cell().Element(CellStyle).Text(item.Amount.ToString("C"));
        //                        table.Cell().Element(CellStyle).Text(item.Date.ToShortDateString());

        //                        static IContainer CellStyle(IContainer container) =>
        //                            container.Padding(5).BorderBottom(1).BorderColor("#DDD");
        //                    }
        //                });
        //        });
        //    }).GeneratePdf(fullPath);

        //    return fullPath;
        //}
        public async Task<string> GenerateAndSavePdfReportAsync()
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var data = await _context.ReportItems.ToListAsync();
            var reportsPath = Path.Combine(_env.ContentRootPath, "Reports");
            Directory.CreateDirectory(reportsPath);

            string fileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string fullPath = Path.Combine(reportsPath, fileName);

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Content()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1); // Sr. No.
                                columns.RelativeColumn(2); // ID
                                columns.RelativeColumn(3); // Name
                                columns.RelativeColumn(2); // Amount
                                columns.RelativeColumn(3); // Date
                            });

                            // Header row
                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("SrNo");
                                header.Cell().Element(CellStyle).Text("ID");
                                header.Cell().Element(CellStyle).Text("Name");
                                header.Cell().Element(CellStyle).Text("Amount");
                                header.Cell().Element(CellStyle).Text("Date");

                                static IContainer CellStyle(IContainer container) =>
                                    container.Padding(5).Background("#EEE").BorderBottom(1).BorderColor("#CCC");
                            });

                            // Data rows with auto-incremented Sr. No
                            int srNo = 1;
                            foreach (var item in data)
                            {
                                table.Cell().Element(CellStyle).Text(srNo++.ToString()); // Auto-incremented Sr.No
                                table.Cell().Element(CellStyle).Text(item.Id.ToString());
                                table.Cell().Element(CellStyle).Text(item.Name);
                                table.Cell().Element(CellStyle).Text(item.Amount.ToString("C"));
                                table.Cell().Element(CellStyle).Text(item.Date.ToShortDateString());

                                static IContainer CellStyle(IContainer container) =>
                                    container.Padding(5).BorderBottom(1).BorderColor("#DDD");
                            }
                        });
                });
            }).GeneratePdf(fullPath);

            return fullPath;
        }


    }
}
