using GenerateReports.services;
using Microsoft.AspNetCore.Mvc;

namespace TestApiAttendence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("excel")]
        public IActionResult GetExcelReport()
        {
            var file = _reportService.GenerateExcelReport();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
        }
    }
}
