using ComputerBuilder.BL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ComputerBuilder.DAL.Repositories;

namespace ComputerBuilder.Controllers
{
    [Route("home")]
    public class HomeController : BaseController
    {
        private readonly IDbRepository _dataAccess;
        public HomeController (IDbRepository dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("get_all_hardware/")]
        public IActionResult GetAllHardware()
        {
            var items = _dataAccess.GetHardwareItems();
            return Ok(items);
        }
        [HttpGet("get_hwitem_by_manufacturer/{manufacturer_name}")]
        public IActionResult GetHwItemByManufacturer(string manufacturer_name)
        {
            if (string.IsNullOrWhiteSpace(manufacturer_name))
            {
                return Ok("Название фирмы должно быть заполнено");
            }
            var items = _dataAccess.GetHardwareItems().Where(i => i.Manufacturer.Name == manufacturer_name).Select(i => new LookupItem
            {
                DisplayName = i.Manufacturer.Name + " " + i.Name + " -- Цена:" + i.Cost
            }).ToList();
            return Ok(items);
        }
    }
    

}
