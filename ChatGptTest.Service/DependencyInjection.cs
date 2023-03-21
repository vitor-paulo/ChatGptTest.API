using ChatGptTest.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChatGptTest.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<IEnglishTutorService, EnglishTutorService>();
            return services;
        }
    }
}
