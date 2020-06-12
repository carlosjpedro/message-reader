using ConsoleApp1.Model;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Writing
{
    public class ConsoleMessageWriter : IMessageWriter
    {
        public void Write(NiceMessage message)
        {
            Console.WriteLine(message);
        }
    }
}
