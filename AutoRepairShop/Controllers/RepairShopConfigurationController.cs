using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Arguments.RepairShopConfiguration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepairShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepairShopConfigurationController : Controller
    {
        readonly IRepairShopConfigurationService _repairShopConfigurationService;

        public RepairShopConfigurationController(IRepairShopConfigurationService maintenanceService)
        {
            _repairShopConfigurationService = maintenanceService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List()
        {
            return await _repairShopConfigurationService.List();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddRepairShopConfigurationRequest request)
        {
            return await _repairShopConfigurationService.Add(request.ToRepairShopConfiguration());
        }
    }
}
