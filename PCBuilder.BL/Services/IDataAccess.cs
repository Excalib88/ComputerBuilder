using ComputerBuilder.BL.Model;
using System.Collections.Generic;

namespace PCBuilder.BL.Services
{
    public interface IDataAccess
    {
        IEnumerable<HardwareItem> GetHardwareItems();
    }
}