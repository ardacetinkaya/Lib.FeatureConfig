using Lib.FeatureConfig;
using System;
using Xunit;

namespace Lib.FeatureConfigTest
{
    public class FeatureConfigTests
    {
        [Fact]
        public void FeatureWithNoDate_Test()
        {
            FeaturesService fs = new FeaturesService("features.json");
            fs._features = new System.Collections.Generic.List<Feature>();
            fs._features.Add(new Feature
            {
                Name = "featurewithnodate",
                StartDate = null,
                EndDate = null,
            });

            var result = fs.IsEnabled("featurewithnodate");
            Assert.True(result);
        }

        [Fact]
        public void InvalidFeatureConfigFile_Test()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new FeaturesService(""));

            Assert.Equal("Invalid file name.", ex.Message);
        }

        [Fact]
        public void FeatureWithStartDate_Test()
        {
            FeaturesService fs = new FeaturesService("features.json");
            fs._features = new System.Collections.Generic.List<Feature>();
            fs._features.Add(new Feature
            {
                Name = "featurewithstartdate",
                StartDate = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0)),
                EndDate = null,
            });

            var result = fs.IsEnabled("featurewithstartdate");

            Assert.False(result);
        }

        [Fact]
        public void FeatureWithEndDate_Test()
        {
            FeaturesService fs = new FeaturesService("features.json");
            fs._features = new System.Collections.Generic.List<Feature>();
            fs._features.Add(new Feature
            {
                Name = "featurewithenddate",
                StartDate = null,
                EndDate = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0)),
            });

            var result = fs.IsEnabled("featurewithenddate");

            Assert.True(result);
        }

        [Fact]
        public void FeatureWithStartEndDate_Test()
        {
            FeaturesService fs = new FeaturesService("features.json");
            fs._features = new System.Collections.Generic.List<Feature>();
            fs._features.Add(new Feature
            {
                Name = "featurewithstartenddate",
                StartDate = DateTime.Now.Add(new TimeSpan(-2, 0, 0, 0)),
                EndDate = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0)),
            });

            var result = fs.IsEnabled("featurewithstartenddate");

            Assert.True(result);
        }
    }
}
