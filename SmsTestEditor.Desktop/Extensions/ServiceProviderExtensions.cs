using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SmsTestEditor.Desktop.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IConfiguration GetConfigururation(this IServiceProvider serviceProvider)
            => serviceProvider.GetRequiredService<IConfiguration>();
    }
}
