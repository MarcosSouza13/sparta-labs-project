using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Arguments.Maintenance;
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

        [HttpGet("all")]
        public async Task<IActionResult> List()
        {
            return await _maintenanceService.List();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return await _maintenanceService.Get(id);
        }

        [HttpGet("all/dates")]
        public async Task<IActionResult> ListWithDates([FromQuery] string initalDate, string finalDate)
        {
            return await _maintenanceService.ListWithDates(initalDate, finalDate);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([FromBody] AddMaintenanceRequest request)
        {
            return await _maintenanceService.Add(request.ToMaintenance());
        }

        [HttpPut]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Put(long id, [FromBody] EditMaintenanceRequest request)
        {
            return await _maintenanceService.Edit(request.ToMaintenance(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return await _maintenanceService.Delete(id);
        }
    }
}
