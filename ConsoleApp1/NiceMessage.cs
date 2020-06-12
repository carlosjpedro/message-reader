using System.Collections.Generic;
using System.Linq;

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

        public override string ToString()
        {
            return $"IP: {Ip}, Port: {Port}, Codecs: [{string.Join(", ", Codecs)}]";
        }
    }


}
