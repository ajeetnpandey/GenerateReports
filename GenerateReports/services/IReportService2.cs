using ClosedXML.Excel;
using System;

namespace GenerateReports.services
{
    public interface IReportService2
    {
        Task<string> GenerateAndSaveExcelReportAsync();
    }
}
