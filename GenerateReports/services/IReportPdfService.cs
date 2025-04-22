namespace GenerateReports.services
{
    public interface IReportPdfService
    {
        Task<string> GenerateAndSavePdfReportAsync();
    }
}
