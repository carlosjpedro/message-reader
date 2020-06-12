using System.Collections.Generic;

namespace ConsoleApp1
{
    public class NiceMessage
    {
        public string Ip { get; }
        public string Port { get; }
        public List<string> Codecs { get; }

        public NiceMessage(string ip, string port, List<string> codecs)
        {
            Ip = ip;
            Port = port;
            Codecs = codecs;
        }
    }


}
