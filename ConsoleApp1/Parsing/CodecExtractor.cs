using System.Text.RegularExpressions;

namespace ConsoleApp1.Parsing
{
    public class CodecExtractor : ICodecExtractor
    {
        private readonly Regex _codecRegex = new Regex(@"rtpmap:\d ([a-zA-Z0-9]+)\/\d+");
        public string Codec(string record)
        {
            var match = _codecRegex.Match(record);
            if (match.Groups.Count < 2)
            {
                return null;
            }

            return match.Groups[1].Value;
        }
    }
}
