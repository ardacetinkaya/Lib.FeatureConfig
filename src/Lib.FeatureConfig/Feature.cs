namespace Lib.FeatureConfig
{
    using System;
    public class Feature
    {
        public string Name { get; set; }

        public string For { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
