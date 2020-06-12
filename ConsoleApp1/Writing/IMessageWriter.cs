using ConsoleApp1.Model;
using System.Collections.Generic;

namespace ConsoleApp1.Writing
{
    public interface IMessageWriter
    {
        public void Write(NiceMessage message);
    }
}
