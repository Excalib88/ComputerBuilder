using ComputerBuilder.BL.Model;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.BL.Services;
using System.Linq;

namespace ComputerBuilder.Controllers
{
    //[Route("test")] //Почему можно не указывать?
    public class DataAccessController : BaseController
    {
        private readonly IDataAccess _dataAccess;
        public DataAccessController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
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
