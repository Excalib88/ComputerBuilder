using System.Collections;
using System.Text.RegularExpressions;

namespace ComputerBuilder.BL.Parser
{
    public interface IParser<T> where T : class
    {
        T Parse(string price);
    }
}
