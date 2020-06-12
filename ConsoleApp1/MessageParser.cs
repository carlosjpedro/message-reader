using System.Collections.Generic;

namespace ConsoleApp1
{
    public class MessageParser : IMessageParser
    {
        public NiceMessage Parse(List<string> messageLines)
        {
            string ip = null, port = null;
            List<string> codecs = new List<string>();

            foreach (var line in messageLines)
            {
                var keyValue = line.Split('=');

                if (keyValue.Length != 2)
                    throw new InvalidMessageFormat();

                switch (keyValue[0])
                {
                    case "c":
                        ip = keyValue[1];
                        break;
                    case "m":
                        port = keyValue[1];
                        break;
                    case "a":
                        codecs.Add(keyValue[1]);
                        break;
                    default:
                        break;
                }

            }

            if (string.IsNullOrWhiteSpace(port))
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

            return new NiceMessage(ip, port, codecs);
        }
    }


}
