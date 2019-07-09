using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Lib.FeatureConfigTest")]

namespace Lib.FeatureConfig
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class FeaturesService : IFeatureService
    {
        IConfigurationRoot _configuration;
        internal List<Feature> _features;

        public FeaturesService(string file)
        {
            if (string.IsNullOrEmpty(file))
                throw new ArgumentException("Invalid file name.");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(file, optional: true, reloadOnChange: true);

            _configuration = builder.Build();

            _features = new List<Feature>();
            _configuration.GetSection("Features").Bind(_features);

        }

        public bool IsEnabled(string featureName, string forWho = "")
        {
            if (_features == null) return false;

            featureName = featureName.ToLower();

            if (string.IsNullOrEmpty(featureName)) return false;

            if (!_features.Exists(f => f.Name.ToLower() == featureName)) return false;

            var feature = _features.Find(f => f.Name.ToLower() == featureName);

            if (feature == null) return false;

            var featureFor = feature.For?.Trim();
            if (!string.IsNullOrEmpty(featureFor) && !featureFor.Equals(forWho.Trim()))
            {
                return false;
            }
            DateTime now = DateTime.Now;

            if (feature.StartDate == null && feature.EndDate == null)
            {
                return true;
            }

            if (feature.StartDate <= now && feature.EndDate == null)
            {
                return true;
            }

            if (feature.StartDate == null && feature.EndDate > now)
            {
                return true;
            }

            if (feature.StartDate <= now && feature.EndDate > now)
            {
                return true;
            }

            return false;
        }
    }


}
