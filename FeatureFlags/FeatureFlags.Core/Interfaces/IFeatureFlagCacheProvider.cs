using System.Collections.Generic;

namespace FeatureFlags
{
    public interface IFeatureFlagCacheProvider
    {
        IDictionary<string, IFeature> Build();
    }
}