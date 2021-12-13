using FeatureFlagClient.FilterHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using System.Threading.Tasks;

namespace FeatureFlagClient.Controllers
{
    public class NewFeatureController : Controller
    {
        private readonly IFeatureManager _featureManager;

        public NewFeatureController(IFeatureManagerSnapshot featureManager) =>
            _featureManager = featureManager;

        public async Task<IActionResult> Index()
        {
            var IsFeatureEnabled = await _featureManager.IsEnabledAsync("testfeature", new Context() { Application = "App1"});


            if (IsFeatureEnabled){
                return View("FlagEnabled");
            }
            else
            {
                return View("FlagDisabled");
            }
        }
    }
}
