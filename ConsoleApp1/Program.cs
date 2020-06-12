using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\Carlos\Desktop\sdp_input.txt");
            foreach(var l in lines)
            {
                Console.WriteLine(l);
            }
        }

        private IEnumerable<List<string>> ReadMessageLines(string filePath)
        {
            var lines = File.ReadLines(@"C:\Users\Carlos\Desktop\sdp_input.txt");
            var currentMessage = new List<string>();
            foreach (var l in lines)
            {
                if(string.IsNullOrWhiteSpace( l))
                {
                    yield return currentMessage;
                    currentMessage = new List<string>();
                }
                currentMessage.Add(l);
                
            }
        }
    }
}
