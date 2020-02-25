using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ComputerBuilder.DAL.Repositories;
using ComputerBuilder.DAL.Entities;

namespace ComputerBuilder.Controllers
{
    [Route("home")]
    public class HomeController : BaseController
    {
        private readonly IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("add_hwitem/")]
        public IActionResult AddHwItem(string name, double cost, string description, string manufacturerName, string hardwareType, string propertyName, string propertyType)
        {
            HardwareItemEntity hardwareItem = new HardwareItemEntity(name, cost, description, new ManufacturerEntity(manufacturerName), new HardwareTypeEntity(hardwareType));
            CompatibilityPropertyEntity compatibilityProperty = new CompatibilityPropertyEntity(propertyName, propertyType);          
            hardwareItem.PropertyList.Add(compatibilityProperty);
            _repository.AddAsync(hardwareItem);
            return Ok();//как сделать Created и нужно ли?
        }

        [HttpGet("find_by_manufacturer/")]
        public IActionResult FindItem(string manufacturer)
        {
            var items = _repository.Find<HardwareItemEntity>(i => i.Manufacturer.Name == manufacturer);
            return Ok(items);
        }

        [HttpGet("get_all_hardware/")]
        public IActionResult GetAllHardware()
        {
            var items = _repository.GetAll<HardwareItemEntity>().ToList();
            return Ok(items);
        }
    }
    

}
