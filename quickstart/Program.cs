using App.Metrics;
using App.Metrics.AspNetCore.Health;
using App.Metrics.Formatters.Prometheus;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Quickstart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureMetricsWithDefaults(builder =>
                    {
                        builder.OutputMetrics.AsPrometheusPlainText();
                    })
                .UseMetricsEndpoints(
                    options =>
                    {
                        options.MetricsEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                    })
                .UseMetricsWebTracking()
                .UseHealth()
                .UseStartup<Startup>();
    }
}
