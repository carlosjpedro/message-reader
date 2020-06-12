using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface IMessageReader
    {
        IEnumerable<List<string>> ReadMessages(string filePath);
    }

}
