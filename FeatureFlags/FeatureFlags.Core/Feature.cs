namespace FeatureFlags
{
    public class Feature : IFeature
    {
        public Feature(bool isEnabled, string name)
        {
            IsEnabled = isEnabled;
            Name = name;
        }

        public bool IsEnabled { get; }
        public string Name { get; }
    }
}