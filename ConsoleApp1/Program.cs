using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        const string FilePath = @"C:\Users\Carlos\Desktop\sdp_input.txt";
        static void Main(string[] args)
        {

            var messages = ReadMessageLines(FilePath);
            foreach(var m in messages)
            {
                OutputMessage(m);
            }
        }

        private static IEnumerable<List<string>> ReadMessageLines(string filePath)
        {
            var lines = File.ReadLines(filePath);
            var currentMessage = new List<string>();
            foreach (var l in lines)
            {
                if (string.IsNullOrWhiteSpace(l))
                {
                    yield return currentMessage;
                    currentMessage = new List<string>();
                }
                currentMessage.Add(l);
            }
        }

        private static void OutputMessage(IEnumerable<string> message)
        {
            foreach (var line in message)
            {
                Console.WriteLine(line);
                    }
        }
    }
}
