namespace FeatureFlags
{
    public interface IFeature
    {
        bool IsEnabled { get; }
        string Name { get; }
    }
}