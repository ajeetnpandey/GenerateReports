using Microsoft.AspNetCore.Mvc;
using GenerateReports.Models;
using GenerateReports.services;

namespace GenerateReports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Report2Controller : ControllerBase
    {
        private readonly IReportService2 _reportService;
        private readonly IWebHostEnvironment _env;
        private readonly IReportPdfService _pdfService;

        public Report2Controller(IReportService2 reportService,
            IWebHostEnvironment env,
            IReportPdfService pdfService)
        {
            _reportService = reportService;
            _env = env;
            _pdfService = pdfService;
        }

        [HttpGet("excel")]
        public async Task<IActionResult> GenerateExcel()
        {
            var filePath = await _reportService.GenerateAndSaveExcelReportAsync();

            if (!System.IO.File.Exists(filePath))
                return NotFound("Report generatiosn failed.");

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            var fileName = Path.GetFileName(filePath);
            return File(fileBytes, FileConstants.ExcelMimeType, fileName);
        }


        [HttpGet("download")]
        public async Task<IActionResult> DownloadReport([FromQuery] string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return BadRequest("Filename is required.");

            var reportsPath = Path.Combine(_env.ContentRootPath, FileConstants.ReportsFolder);
            var filePath = Path.Combine(reportsPath, fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found.");

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, FileConstants.ExcelMimeType, fileName);
        }

        [HttpGet("pdf")]
        public async Task<IActionResult> GeneratePdf()
        {
            var filePath = await _pdfService.GenerateAndSavePdfReportAsync();
            if (!System.IO.File.Exists(filePath))
                return NotFound("Failed to generate PDF report.");

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, "application/pdf", Path.GetFileName(filePath));
        }
    }
}