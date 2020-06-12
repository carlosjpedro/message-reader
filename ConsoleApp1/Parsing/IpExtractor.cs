using ConsoleApp1.Exceptions;
using System.Text.RegularExpressions;

namespace ConsoleApp1.Parsing
{
    public class IpExtractor : IExtractIp
    {
        private readonly Regex _ipRegex = new Regex(@"IN IP4 ((?:[0-9]{1,3}\.){3}[0-9]{1,3})$");
        public string Ip(string record)
        {
            var match = _ipRegex.Match(record);
            if (match.Groups.Count < 2)
            {
                throw new InvalidIpData();
            }

            return match.Groups[1].Value;
        }
    }
}
