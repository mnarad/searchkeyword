using Microsoft.Extensions.DependencyInjection;
using SearchEngine.Core;

namespace SearchEngine.API
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
