using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ComputerBuilder.DAL.Repositories;
using ComputerBuilder.DAL.Entities;

namespace ComputerBuilder.Controllers
{
    [Route("home")]
    public class HomeController : BaseController
    {
        private readonly IDbRepository _repository;
        public HomeController(IDbRepository repository)
        {
            _repository = repository;
        }

        //public IActionResult Index()
        //{
        //    return Ok();
        //}

        [HttpPost("add_hwItem/")]
        public IActionResult AddHwItem(string name, double cost, string description, string manufacturerName, string hardwareType, string prop1, string propName)
        {
            HardwareItem hardwareItem = new HardwareItem(name, cost, description, new Manufacturer(manufacturerName), new HardwareType(hardwareType));
            CompatibilityProperty compatibilityProperty = new CompatibilityProperty(prop1, propName);          
            hardwareItem.PropertyList.Add(compatibilityProperty);
            _repository.Add(hardwareItem);
            return Ok();
        }

        [HttpGet("get_all_hardware/")]
        public IActionResult GetAllHardware()
        {
            var items = _repository.GetAll<HardwareItem>().ToList();
            return Ok(items);
        }
        //[HttpGet("get_hwitem_by_manufacturer/{manufacturer_name}")]
        //public IActionResult GetHwItemByManufacturer(string manufacturer_name)
        //{
        //    if (string.IsNullOrWhiteSpace(manufacturer_name))
        //    {
        //        return Ok("Название фирмы должно быть заполнено");
        //    }
        //    var items = _dbcontext.GetHardwareItems().Where(i => i.Manufacturer.Name == manufacturer_name).Select(i => new LookupItem
        //    {
        //        DisplayName = i.Manufacturer.Name + " " + i.Name + " -- Цена:" + i.Cost
        //    }).ToList();
        //    return Ok(items);
        //}
    }
    

}
