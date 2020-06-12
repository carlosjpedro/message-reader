using System.Collections.Generic;

namespace ConsoleApp1
{
    public class MessageParser : IMessageParser
    {
        private readonly IExtractIp _ipExtractor;
        private readonly IPortExtractor _portExtractor;

        public MessageParser(IExtractIp ipExtractor, IPortExtractor portExtractor)
        {
            _ipExtractor = ipExtractor;
            _portExtractor = portExtractor;
        }

        public NiceMessage Parse(List<string> messageLines)
        {
            string ip = null;
            int? port = null;
            List<string> codecs = new List<string>();

            foreach (var line in messageLines)
            {
                var keyValue = line.Split('=');

                if (keyValue.Length != 2)
                    throw new InvalidMessageFormat();

                switch (keyValue[0])
                {
                    case "c":
                        ip = _ipExtractor.Ip(keyValue[1]);
                        break;
                    case "m":
                        port = _portExtractor.Port(keyValue[1]);
                        break;
                    case "a":
                        codecs.Add(keyValue[1]);
                        break;
                    default:
                        break;
                }

            }

            if (!port.HasValue)
            {
                throw new InvalidMessageFormat();
            }
            if (string.IsNullOrWhiteSpace(ip))
            {
                throw new InvalidMessageFormat();
            }

            if (codecs.Count == 0)
            {
                throw new InvalidMessageFormat();
            }

            return new NiceMessage(ip, port.Value, codecs);
        }
    }


}
