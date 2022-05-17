using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Arguments.RepairShop;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepairShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepairShopController : Controller
    {
        readonly IRepairShopService _repairShopService;

        public RepairShopController(IRepairShopService repairShopService)
        {
            _repairShopService = repairShopService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddRepairShopRequest request) => await _repairShopService.Add(request.ToRepairShop());
    }
}
