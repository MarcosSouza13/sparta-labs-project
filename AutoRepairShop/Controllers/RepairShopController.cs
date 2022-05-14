using AutoRepairShop.Api.Services.Interfaces;
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

        [HttpGet]
        public ActionResult Get(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Put(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}
