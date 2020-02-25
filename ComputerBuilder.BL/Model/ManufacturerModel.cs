using System;
using System.Collections.Generic;

namespace ComputerBuilder.BL.Model
{
    public class ManufacturerModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Название производителя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список оборудования с таким производителем
        /// </summary>
        public ICollection<HardwareItemModel> HardwareList { get; set; }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public ManufacturerModel() { }
        /// <summary>
        /// Создать нового производителя.
        /// </summary>
        /// <param name="name">Название производителя</param>
        public ManufacturerModel(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название не может быть пустым", nameof(name));
            }
            Name = name;
            HardwareList = new List<HardwareItemModel>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
