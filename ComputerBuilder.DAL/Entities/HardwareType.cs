using System;
using System.Collections.Generic;

namespace ComputerBuilder.DAL.Entities
{
    public class HardwareType
    {
        public int Id { get; set; }
        /// <summary>
        /// Название типа оборудования
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список оборудования с таким типом
        /// </summary>
        public ICollection<HardwareItem> HardwareList { get; set; }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public HardwareType() { }
        public HardwareType(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Название типа оборудования должно быть заполнено", nameof(name));
            }
            Name = name;
            HardwareList = new List<HardwareItem>();
        }

        public override string ToString()
        {
            return Name;
        }


    }
}