using System;
using System.Collections.Generic;

namespace ComputerBuilder.DAL.Entities
{
    public class HardwareTypeEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// Название типа оборудования
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список оборудования с таким типом
        /// </summary>
        public ICollection<HardwareItemEntity> HardwareList { get; set; }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public HardwareTypeEntity() { }
        public HardwareTypeEntity(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Название типа оборудования должно быть заполнено", nameof(name));
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