using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface IMessageWriter
    {
        public void Write(IEnumerable<string> message);
    }


}
