namespace Lib.FeatureConfig
{
    using Microsoft.Extensions.DependencyInjection;
    public static class FeatureExtension
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services, string configPath = "appsettings.json")
        {
            services.AddTransient<IFeatureService>(f => new FeaturesService(configPath));

            return services;
        }
    }
}
