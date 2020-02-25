using System;

namespace ComputerBuilder.BL.Model
{
    public class CompatibilityPropertyModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Название характеристики
        public string Name { get; set; }
        /// <summary>
        /// Тип характеристики
        /// </summary>
        //[StringLength(50)]
        public string PropertyType { get; set; }
        /// <summary>
        /// Железка с такими свойствами
        /// </summary>
        public int HardwareItemId { get; set; }
        public virtual HardwareItemModel HardwareItem { get; set; }
        public CompatibilityPropertyModel() { }
        public CompatibilityPropertyModel(string propertyType, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Не определён";
            }
            if (string.IsNullOrWhiteSpace(propertyType))
            {
                throw new ArgumentNullException("Название типа характеристики должно быть заполнено", nameof(propertyType));
            }
            Name = name;
            PropertyType = propertyType;
        }
        public override string ToString()
        {
            return PropertyType + " - " + Name;
        }
    }
}