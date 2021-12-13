using Azure.Data.AppConfiguration;
using FeatureFlagManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;

namespace FeatureFlagManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeatureFlagController : Controller
    {
        private readonly ILogger<FeatureFlagController> _logger;
        private readonly IConfiguration _configuration;
        public FeatureFlagController(ILogger<FeatureFlagController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("CreateFeatureFlag")]
        public IActionResult CreateFeatureFlag(CreateFeatureRequest request)
        {
            try
            {
                var client = new ConfigurationClient(_configuration.GetConnectionString("AppConfigConnectionString"));

                var serializedRequestValue = JsonSerializer.Serialize(request);

                var featureFlagToCreate = new ConfigurationSetting
                    (".appconfig.featureflag/" + request.Id, serializedRequestValue)
                {
                    ContentType = "application/vnd.microsoft.appconfig.ff+json;charset=utf-8"
                };

                client.SetConfigurationSetting(featureFlagToCreate);

                client.SetConfigurationSetting(new ConfigurationSetting("LatestUpdate", DateTime.Now.ToString()));

                return Created(string.Empty, "");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured");
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateFeatureFlag")]
        public IActionResult UpdateFeatureFlag(UpdateFeatureRequest request)
        {
            try
            {
                var client = new ConfigurationClient(_configuration.GetConnectionString("AppConfigConnectionString"));

                var serializedRequestValue = JsonSerializer.Serialize(request);

                var featureFlagToUpdate = new ConfigurationSetting(".appconfig.featureflag/" + request.Id, serializedRequestValue)
                {
                    ContentType = "application/vnd.microsoft.appconfig.ff+json;charset=utf-8"
                };

                client.SetConfigurationSetting(featureFlagToUpdate);

                client.SetConfigurationSetting(new ConfigurationSetting("LatestUpdate", DateTime.Now.ToString()));

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured");
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("DeleteFeatureFlag")]
        public IActionResult DeleteFeatureFlag(DeleteFeatureRequest request)
        {
            try
            {
                var client = new ConfigurationClient(_configuration.GetConnectionString("AppConfigConnectionString"));

                var featureFlagToDelete = new FeatureFlagConfigurationSetting(request.Id, request.Enabled);

                client.DeleteConfigurationSetting(featureFlagToDelete);

                client.SetConfigurationSetting(new ConfigurationSetting("LatestUpdate", DateTime.Now.ToString()));

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured");
                return Ok(ex.Message);
            }
        }

    }
}
