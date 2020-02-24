using ComputerBuilder.DAL.Entities;
using System.Collections.Generic;

namespace ComputerBuilder.DAL.Repositories
{
    public interface IDbRepository
    {
        IEnumerable<HardwareItem> GetHardwareItems();
    }
}