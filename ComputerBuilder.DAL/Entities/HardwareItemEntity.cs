﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerBuilder.DAL.Entities
{
    public class HardwareItemEntity
    {
        #region Свойства
        public int Id { get; set; }
        /// <summary>
        /// Название железки
        /// </summary>
        //[StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// Цена железки
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// Описание других характеристик
        /// </summary>
        [StringLength(255)]
        public string Description { get; set; }
        /// <summary>
        /// Производитель
        /// </summary>
        public int ManufacturerId { get; set; }
        public ManufacturerEntity Manufacturer { get; set; }
        /// <summary>
        /// Тип железа
        /// </summary>
        public int HardwareTypeId { get; set; }
        public HardwareTypeEntity HardwareType { get; set; }
        /// <summary>
        /// Список характеристик железки
        /// </summary>
        public ICollection<CompatibilityPropertyEntity> PropertyList { get; set; }

        public ICollection<ManyBuildsToManyHwItemsEntity> BuildItems { get; set; }
        #endregion

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public HardwareItemEntity()
        {
            Name = "Не определено";
            Cost = 0;
            Description = "Не определено";
            Manufacturer = null;
            HardwareType = null;
            PropertyList = new List<CompatibilityPropertyEntity>();
            BuildItems = new List<ManyBuildsToManyHwItemsEntity>();
        }
        /// <summary>
        /// Создание новой железки
        /// </summary>
        /// <param name="name">Название железа</param>
        /// <param name="cost">Цена</param>
        /// <param name="description">Описание (не обязательно)</param>
        /// <param name="manufacturer">Производитель</param>
        /// <param name="hardwareType">Тип оборудования</param>
        public HardwareItemEntity(string name,
            double cost,
            string description,
            ManufacturerEntity manufacturer,
            HardwareTypeEntity hardwareType)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название не может быть пустым", nameof(name));
            }
            if (cost < 0)
            {
                throw new ArgumentException("Цена не может быть отрицательная", nameof(cost));
            }
            if (string.IsNullOrEmpty(description))
            {
                description = " ";
            }
            if (manufacturer == null)
            {
                throw new ArgumentException("Производитель должен быть заполнен", nameof(manufacturer));
            }
            if (hardwareType == null)
            {
                throw new ArgumentException("Тип комплектующего должен быть заполнен", nameof(hardwareType));
            }
            #endregion

            Name = name;
            Cost = cost;
            Description = description;
            Manufacturer = manufacturer;
            HardwareType = hardwareType;
            PropertyList = new List<CompatibilityPropertyEntity>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
