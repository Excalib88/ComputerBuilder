using System;

namespace ComputerBuilder.BL.Model
{
    public class CompatibilityProperty
    {
        public int PropertyId { get; set; }
        /// <summary>
        /// Название характеристики
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Тип характеристики
        /// </summary>
        public string PropertyType { get; set; }
        /// <summary>
        /// Железка с такими свойствами
        /// </summary>
        public int HardwareItemId { get; set; }
        public virtual HardwareItem HardwareItem { get; set; }
        public CompatibilityProperty() { }
        public CompatibilityProperty (string propertyType, string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                name="Не определён";
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
            return PropertyType + " - " +Name;
        }
    }
}