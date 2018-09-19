using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace FeatureFlags.Sample
{
    public class PcfFeatureFlagCacheProvider : IFeatureFlagCacheProvider
    {
        private readonly IConfiguration _config;

        public PcfFeatureFlagCacheProvider(IConfiguration config)
        {
            _config = config;
        }

        public IDictionary<string, IFeature> Build()
        {
            var cache = new Dictionary<string, IFeature>();

            var opts = new CloudFoundryServicesOptions();
            var serviceSection = _config.GetSection(CloudFoundryServicesOptions.CONFIGURATION_PREFIX);
            serviceSection.Bind(opts);

            var cups = opts.Services["user-provided"];

            var featureFlag = cups.FirstOrDefault(x => x.Name == "FeatureFlags");

            foreach (var credential in featureFlag.Credentials)
            {
                var enabled = credential.Value.Value.ToLowerInvariant() == "enabled";

                var feature = new Feature(enabled, credential.Key);
                cache[credential.Key] = feature;
            }

            return cache;
        }
    }
}