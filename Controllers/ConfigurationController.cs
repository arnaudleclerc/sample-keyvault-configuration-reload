using KeyVault.Reload.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace KeyVault.Reload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationRoot _configuration;
        private readonly AuthenticationConfiguration _authenticationConfiguration;
        public ConfigurationController(IConfiguration configuration, IOptionsMonitor<AuthenticationConfiguration> authenticationConfiguration)
        {
            _configuration = configuration as IConfigurationRoot;
            _authenticationConfiguration = authenticationConfiguration.CurrentValue;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authenticationConfiguration);
        }

        [HttpPost]
        public IActionResult Refresh()
        {
            _configuration.Reload();
            return NoContent();
        }

    }
}
