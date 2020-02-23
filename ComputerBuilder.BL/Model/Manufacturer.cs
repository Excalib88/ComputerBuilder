using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerBuilder.BL.Model
{
    public class Manufacturer
    {
        public int Id { get; set; }
        /// <summary>
        /// Название производителя
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// Список оборудования с таким производителем
        /// </summary>
        public virtual ICollection<HardwareItem> HardwareList { get; set; }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Manufacturer() { }
        /// <summary>
        /// Создать нового производителя.
        /// </summary>
        /// <param name="name">Название производителя</param>
        public Manufacturer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название не может быть пустым", nameof(name));
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
