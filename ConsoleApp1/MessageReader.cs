using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    public class MessageReader : IMessageReader
    {
        public IEnumerable<List<string>> ReadMessages(string filePath)
        {
            var lines = File.ReadLines(filePath);
            var currentMessage = new List<string>();
            foreach (var l in lines)
            {
                if (string.IsNullOrWhiteSpace(l))
                {
                    yield return currentMessage;
                    currentMessage = new List<string>();
                    continue;
                }
                currentMessage.Add(l);
            }
        }
    }
}
