using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using System.Threading.Tasks;

namespace FeatureFlagClient.FilterHelpers
{
    [FilterAlias("ApplicationContextFilter")]
    public class ApplicationContextFilter : IContextualFeatureFilter<Context>
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext featureFilterContext, Context appContext)
        {
            var param = featureFilterContext.Parameters.Get<Parameters>();

            return Task.FromResult(true);
        }
    }
}
