using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    public class MessageReader : IMessageReader
    {
        public async IAsyncEnumerable<List<string>> ReadMessagesAsync(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                var currentMessage = new List<string>();
                string line = null;
                while( (line = await reader.ReadLineAsync()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        yield return currentMessage;
                        currentMessage = new List<string>();
                        continue;
                    }
                    currentMessage.Add(line);
                }
            }
        }
    }
}
