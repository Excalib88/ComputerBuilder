using ComputerBuilder.BL.Model;
using System.Collections.Generic;

namespace PCBuilder.BL.Services
{
    public class DataAccess : IDataAccess
    {
        public IEnumerable<HardwareItem> GetHardwareItems()
        {
            List<Property> propertiesIntel = new List<Property>();
            List<Property> propertiesAMD = new List<Property>();
            Property socket1151v2 = new Property("Сокет", "1151v2");
            Property SocketAM4 = new Property("Сокет", "SocketAM4");
            propertiesIntel.Add(socket1151v2);
            propertiesAMD.Add(SocketAM4);
            yield return new HardwareItem("PRIME B360M-A",
                5550,
                "4xDDR4, PCI-Ex16, 6SATA3, 7.1-ch, GLAN, 5USB 3.1, USB Type-C, VGA, DVI, HDMI, mATX, Retail",
                new Manufacturer("Asus"),
                new HardwareType("Материнская плата"),
                propertiesIntel);
            yield return new HardwareItem("A320M-DVS",
               3300,
               "AMD A320, 2xDDR4, PCI-Ex16, 4SATA3, 7.1-ch, GLAN, 6USB 3.1, VGA, DVI, mATX, Retail",
               new Manufacturer("ASRock"),
               new HardwareType("Материнская плата"),
               propertiesAMD);
            yield return new HardwareItem("Core i7-9700K",
               30600,
               "Coffee Lake R, 8C/ 8T, 3600MHz 12Mb TDP-95W Socket1151 v2 BOX (без кулера)",
               new Manufacturer("Intel"),
               new HardwareType("Процессор"),
               propertiesIntel);
            yield return new HardwareItem("Ryzen 7-3700X",
               22900,
               "Matisse, 8C/ 16T, 3600MHz 32Mb TDP-65W SocketAM4 tray",
               new Manufacturer("AMD"),
               new HardwareType("Процессор"),
               propertiesAMD);
            yield return new HardwareItem("Core i9-9900K",
               40100,
               "Coffee Lake R, 8C/ 16T, 3600MHz TDP-95W Socket1151 v2 tray (Совместимы только с 3хх чипсетами!)",
               new Manufacturer("Intel"),
               new HardwareType("Процессор"),
               propertiesIntel);
            yield return new HardwareItem("Ryzen 9-3900X",
               39000,
               "Matisse, 12C/ 24T, 3800MHz 64Mb TDP-105W SocketAM4 tray",
               new Manufacturer("AMD"),
               new HardwareType("Процессор"),
               propertiesAMD);
            yield return new HardwareItem("DESIGNARE",
               21700,
               "Socket1151v2, Intel Z390, 4xDDR4, 3PCI-Ex16, 6SATA3, 7.1-ch, 2GLAN, 8USB 3.1, 2USB Type-C, HDMI, DisplayPort, ATX, Retail ",
               new Manufacturer("GIGABYTE"),
               new HardwareType("Материнская плата"),
               propertiesIntel);
            yield return new HardwareItem("MPG X570 GAMING PRO CARBON",
               21700,
               "WIFI, SocketAM4, AMD X570, 4xDDR4, 2PCI-Ex16, 6SATA3, 7.1-ch, GLAN, 9USB 3.1, USB Type-C, HDMI, ATX, Retail",
               new Manufacturer("MSI"),
               new HardwareType("Материнская плата"),
               propertiesAMD);
        }

    }
}
