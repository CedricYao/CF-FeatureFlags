using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace FeatureFlags.Tests
{
    public class Given_populated_FeatureFlagEngine
    {
        private readonly FeatureFlagEngine _featureFlagEngine;
        private object IDictionary;
        private const string FEATURE_NAME = "TestFeature";

        public Given_populated_FeatureFlagEngine()
        {
            var provider = new TestProvider();
            _featureFlagEngine = new FeatureFlagEngine(provider);
        }

        [Fact]
        public void Should_return_feature_flag()
        {
            var result = _featureFlagEngine.Get(FEATURE_NAME);
            result.IsEnabled.Should().BeTrue();
            result.Name.Should().Be(FEATURE_NAME);
        }

        [Fact]
        public void Should_return_null_when_key_miss()
        {
            var result = _featureFlagEngine.Get("cache_miss");
            result.Should().BeNull();
        }

        private class TestProvider : IFeatureFlagCacheProvider
        {
            public IDictionary<string, IFeature> Build()
            {
                var cache = new Dictionary<string, IFeature>();
                cache.Add(FEATURE_NAME, new Feature(true, FEATURE_NAME));

                return cache;
            }
        }
    }
}