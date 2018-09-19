using System.Collections.Generic;

namespace FeatureFlags
{
    public class FeatureFlagEngine
    {
        private readonly IDictionary<string, IFeature> _featureFlagCache;

        public FeatureFlagEngine(IFeatureFlagCacheProvider provider)
        {
            _featureFlagCache = provider.Build();
        }

        public IFeature Get(string featureName)
        {
            if (!_featureFlagCache.ContainsKey(featureName))
                return null;

            return _featureFlagCache[featureName];
        }
    }
}