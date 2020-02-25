using System;
using System.Collections.Generic;

namespace ComputerBuilder.BL.Model
{
    public class HardwareTypeModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Название типа оборудования
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список оборудования с таким типом
        /// </summary>
        public ICollection<HardwareItemModel> HardwareList { get; set; }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public HardwareTypeModel() { }
        public HardwareTypeModel(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Название типа оборудования должно быть заполнено", nameof(name));
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