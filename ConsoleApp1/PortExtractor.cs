using System.Text.RegularExpressions;

namespace ConsoleApp1
{
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
