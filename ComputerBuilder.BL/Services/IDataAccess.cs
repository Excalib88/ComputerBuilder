using ComputerBuilder.BL.Model;
using System.Collections.Generic;

namespace ComputerBuilder.BL.Services
{
    public interface IDataAccess
    {
        IEnumerable<HardwareItem> GetHardwareItems();
    }
}