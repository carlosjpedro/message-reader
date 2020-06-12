using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class ConsoleMessageWriter : IMessageWriter
    {
        public void Write(IEnumerable<string> message)
        {
            foreach (var line in message)
            {
                Console.WriteLine(line);
            }
        }
    }


}
