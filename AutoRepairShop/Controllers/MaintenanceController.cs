using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Arguments.Maintenance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepairShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaintenanceController : Controller
    {
        readonly IMaintenanceService _maintenanceService;

        public MaintenanceController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List() => await _maintenanceService.List();

        [HttpGet("today")]
        [Authorize]
        public async Task<IActionResult> ListDaily() => await _maintenanceService.ListDaily();

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(long id) => await _maintenanceService.Get(id);

        [HttpGet("dates")]
        [Authorize]
        public async Task<IActionResult> ListWithDates([FromQuery] string initialDate, string finalDate) => await _maintenanceService.ListWithDates(initialDate, finalDate);

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddMaintenanceRequest request) => await _maintenanceService.Add(request.ToMaintenance());

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(long id, [FromBody] EditMaintenanceRequest request) => await _maintenanceService.Edit(request.ToMaintenance(id));

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(long id) => await _maintenanceService.Delete(id);
    }
}
