using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

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

    public interface IPortExtractor
    {
        int Port(string record);
    }

    public class PortExtractor : IPortExtractor
    {
        private readonly Regex _portRegex = new Regex(@"audio (\d+) RTP\/AVP");
        public int Port(string record)
        {

            var match = _portRegex.Match(record);
            if (match.Groups.Count < 2)
            {
                throw new InvalidPortData();
            }

            if(int.TryParse(match.Groups[1].Value, out int port))
            {
                return port;
            }
            throw new InvalidPortData();
        }
    }
}
