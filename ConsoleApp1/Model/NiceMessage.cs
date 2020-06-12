using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Model
{
    public class NiceMessage
    {
        public string Ip { get; }
        public int Port { get; }
        public List<string> Codecs { get; }

        public NiceMessage(string ip, int port, List<string> codecs)
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
