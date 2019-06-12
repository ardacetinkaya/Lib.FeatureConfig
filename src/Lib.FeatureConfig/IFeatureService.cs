namespace Lib.FeatureConfig
{
    public interface IFeatureService
    {
        bool IsEnabled(string featureName);
    }
}
