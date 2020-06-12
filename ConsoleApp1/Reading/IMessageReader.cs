using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Reading
{
    public interface IMessageReader
    {
        IAsyncEnumerable<List<string>> ReadMessagesAsync(string filePath);
    }

}
