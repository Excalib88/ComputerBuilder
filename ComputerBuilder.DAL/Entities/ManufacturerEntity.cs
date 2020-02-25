using System;
using System.Collections.Generic;

namespace ComputerBuilder.DAL.Entities
{
    public class ManufacturerEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// Название производителя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список оборудования с таким производителем
        /// </summary>
        public ICollection<HardwareItemEntity> HardwareList { get; set; }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public ManufacturerEntity() { }
        /// <summary>
        /// Создать нового производителя.
        /// </summary>
        /// <param name="name">Название производителя</param>
        public ManufacturerEntity(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название не может быть пустым", nameof(name));
            }
            Name = name;
            HardwareList = new List<HardwareItemEntity>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
