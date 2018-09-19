using System;
using Microsoft.Extensions.Configuration;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace FeatureFlags.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!!");
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCloudFoundry();

            var config = builder.Build();

            var engine = new FeatureFlagEngine(new PcfFeatureFlagCacheProvider(config));

            var feature1 = engine.Get("feature1");
            if (feature1 != null && feature1.IsEnabled)
            {
                Console.WriteLine("Feature 1 is enabled");
            }
            else
            {
                Console.WriteLine("Feature 1 is disabled");
            }

            while (true)
            {

            }
        }
    }
}
