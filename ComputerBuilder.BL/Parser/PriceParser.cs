using ComputerBuilder.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ComputerBuilder.BL.Parser
{
    public class PriceParser : IParser<HardwareItem[]>
    {

        //Парсим общий список и создаём список комплектующих из Прайса
        public HardwareItem[] Parse(string price)
        {
            //var temp = Regex.Match(price, @"[^Специальное предложение]").Value.Length;
            //price = price.Remove(price.Length - temp, temp);
            //Список правил для парсинга
            List<ParserRule> parserRules = new ParserRule().GetRules();

            //Создаём новый список
            List<HardwareItem> hardware_list = new List<HardwareItem>();

            //Парсим процессоры и вставляем в список
            var matches = price.SelectByHardwareType("(?<=Процессор\\s)[^ы;]+");
            hardware_list.AddRange(ParseCPU(matches, parserRules.Where(r => r.HardwareType == "CPU").ToList()));
            ////Парсим материнские платы
            matches = price.SelectByHardwareType("(?<=Мат.плата\\s)[^ы;]+");
            hardware_list.AddRange(ParseMB(matches, parserRules.Where(r=>r.HardwareType == "Motherboard").ToList()));
            ////Парсим оперативную память
            matches = price.SelectByHardwareType("(?<=Модуль_DIMM\\s)[^;]+");
            hardware_list.AddRange(ParseMemory(matches, parserRules.Where(r => r.HardwareType == "Memory").ToList()));
            ////Парсим ХД
            matches = price.SelectByHardwareType("(?<=Жесткий диск\\s)[^;]+");
            hardware_list.AddRange(ParseHDD(matches, parserRules.Where(r => r.HardwareType == "HDD").ToList()));
            //Парсим GPU
            matches = price.SelectByHardwareType("(?<=Видеоплата\\sPCI-E_)[^;]+");
            hardware_list.AddRange(ParseGPU(matches, parserRules.Where(r => r.HardwareType == "GPU").ToList()));
            return hardware_list.ToArray();
        }
        private List<HardwareItem> ParseCPU(string[] CPUs, List<ParserRule> cpuRules)
        {
            //Задаем тип комплектующего
            HardwareType type = new HardwareType("Процессор");
            //Создаем новый список процессоров
            List<HardwareItem> cpu_list = new List<HardwareItem>();
            //Создаем список производителей процессоров
            List<Manufacturer> cpu_manufacturers = new List<Manufacturer>();
            //Заполняем список производителей из правил
            foreach(ParserRule r in cpuRules)
            {
                cpu_manufacturers.Add(new Manufacturer(r.Rule_name));
            }
            //Перебираем все строки процессоров из прайса
            foreach (string s in CPUs)
            {
                //Для каждого правила
                foreach(ParserRule rule in cpuRules)
                {
                    //Если правило подходит к данной строке, заполняем характеристики
                    if (Regex.IsMatch(s, rule.Rule_name, RegexOptions.IgnoreCase))
                    {
                        var description = s.SelectDescription();
                        var cost = s.SelectCost();
                        var sock = Regex.Match(s, rule.Property_templates["Сокет"]).Value;
                        var cpu_name = Regex.Match(s, string.Format(rule.Property_templates["Name"],Regex.Escape(sock))).Value;
                        var cpu = new HardwareItem(cpu_name, cost, description, cpu_manufacturers.Where(m=>m.Name==rule.Rule_name).FirstOrDefault(), type, new List<Property>());
                        cpu.PropertyList.Add(new Property("Сокет", sock));
                        cpu_list.Add(cpu);
                    }
                }
            }
            return cpu_list;
        }

        private List<HardwareItem> ParseMB(string[] MBs, List<ParserRule> mbRules)
        {
            List<HardwareItem> mb_list = new List<HardwareItem>();
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            HardwareType motherboard = new HardwareType("Материнская плата");
            foreach (ParserRule r in mbRules)
            {
                manufacturers.Add(new Manufacturer(r.Rule_name));
            }
            foreach (string s in MBs)
            {
                foreach (ParserRule r in mbRules)
                {
                    if (Regex.IsMatch(s, r.Rule_name))
                    {
                        HardwareItem mb = new HardwareItem();
                        var socket = Regex.Match(s, r.Property_templates["Сокет"]).Value;
                        mb.PropertyList.Add(new Property("Сокет", socket));
                        mb.Name = Regex.Match(s, r.Property_templates["Name"]).Value;
                        mb.Cost = s.SelectCost();
                        mb.Description = s.SelectDescription();
                        mb.Manufacturer = manufacturers.Where(m => m.Name == r.Rule_name).FirstOrDefault();
                        mb.HardwareType = motherboard;
                        mb_list.Add(mb);
                    }
                }
            }
            return mb_list;
        }
        private List<HardwareItem> ParseMemory(string[] mems, List<ParserRule> memRules)
        {
            List<HardwareItem> mem_list = new List<HardwareItem>();
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            HardwareType ram = new HardwareType("Оперативная память");
            foreach (ParserRule r in memRules)
            {
                manufacturers.Add(new Manufacturer(r.Rule_name));
            }
            foreach (string s in mems)
            {
                foreach (ParserRule r in memRules)
                {
                    if (Regex.IsMatch(s, r.Rule_name))
                    {
                        HardwareItem mem = new HardwareItem();
                        var prop = Regex.Match(s, r.Property_templates["Тип памяти"]).Value;
                        mem.PropertyList.Add(new Property("Тип памяти", prop));
                        prop = Regex.Match(s, r.Property_templates["Объём памяти"]).Value;
                        mem.PropertyList.Add(new Property("Объём памяти", prop));
                        mem.Name = Regex.Match(s, r.Property_templates["Name"]).Value;
                        mem.Cost = s.SelectCost();
                        mem.Description = Regex.Match(s, r.Property_templates["Description"]).Value;
                        mem.Manufacturer = manufacturers.Where(m => m.Name == r.Rule_name).FirstOrDefault();
                        mem.HardwareType = ram;
                        mem_list.Add(mem);
                    }
                }
            }
            return mem_list;
        }
        private List<HardwareItem> ParseHDD(string[] hdds, List<ParserRule> hddRules)
        {
            List<HardwareItem> hdd_list = new List<HardwareItem>();
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            HardwareType hd = new HardwareType("Жесткий диск");
            foreach (ParserRule r in hddRules)
            {
                manufacturers.Add(new Manufacturer(r.Rule_name));
            }
            foreach (string s in hdds)
            {
                foreach (ParserRule r in hddRules)
                {
                    if (Regex.IsMatch(s, r.Rule_name))
                    {
                        HardwareItem hdd = new HardwareItem();
                        var prop = Regex.Match(s, r.Property_templates["Тип устройства"],RegexOptions.IgnoreCase).Value;
                        hdd.PropertyList.Add(new Property("Тип устройства", prop));
                        prop = Regex.Match(s, r.Property_templates["Разъём"]).Value;
                        hdd.PropertyList.Add(new Property("Разъём", prop));
                        prop = Regex.Match(s, r.Property_templates["Объём памяти"], RegexOptions.IgnoreCase).Value;
                        hdd.PropertyList.Add(new Property("Объём памяти", prop));
                        hdd.Name = Regex.Match(s, r.Property_templates["Name"]).Value;
                        hdd.Cost = s.SelectCost();
                        hdd.Description = s.SelectDescription();
                        hdd.Manufacturer = manufacturers.Where(m => m.Name == r.Rule_name).FirstOrDefault();
                        hdd.HardwareType = hd;
                        hdd_list.Add(hdd);
                    }
                }
            }
            return hdd_list;
        }
        private List<HardwareItem> ParseGPU(string[] gpus, List<ParserRule> gpuRules)
        {
            List<HardwareItem> gpu_list = new List<HardwareItem>();
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            HardwareType videocard = new HardwareType("Видеокарта");
            foreach (ParserRule r in gpuRules)
            {
                manufacturers.Add(new Manufacturer(r.Rule_name));
            }
            foreach (string s in gpus)
            {
                foreach (ParserRule r in gpuRules)
                {
                    if (Regex.IsMatch(s, r.Rule_name))
                    {
                        HardwareItem gpu = new HardwareItem();
                        var prop = Regex.Match(s, r.Property_templates["Объём памяти"], RegexOptions.IgnoreCase).Value;
                        gpu.PropertyList.Add(new Property("Объём памяти", prop));
                        gpu.Name = Regex.Match(s, r.Property_templates["Name"], RegexOptions.IgnoreCase).Groups[3].Value;
                        gpu.Description = Regex.Match(s, r.Property_templates["Описание"]).Value;
                        gpu.Cost = s.SelectCost();
                        gpu.Manufacturer = manufacturers.Where(m => m.Name == r.Rule_name).FirstOrDefault();
                        gpu.HardwareType = videocard;
                        gpu_list.Add(gpu);
                    }
                }
            }
            return gpu_list;
        }

    }
}
