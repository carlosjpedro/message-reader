using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class ConsoleMessageWriter : IMessageWriter
    {
        public void Write(NiceMessage message)
        {
            Console.WriteLine(message);            
        }
    }
}
