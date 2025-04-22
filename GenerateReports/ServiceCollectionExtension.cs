using GenerateReports.services;
namespace GenerateReportss
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Register your services here
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IReportService2, ReportService2>();
            services.AddScoped<IReportPdfService, ReportPdfService>();
            // Add other services as needed
            return services;
        }   
    }
}
