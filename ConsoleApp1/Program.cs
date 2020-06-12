using Microsoft.Extensions.DependencyInjection;
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
            var serviceProvider = new ServiceCollection()
                .AddTransient<IMessageFileProcessor, MessageFileProcessor>()
                .AddTransient<IMessageReader, MessageReader>()
                .AddTransient<IMessageWriter, ConsoleMessageWriter>()
                .AddTransient<IMessageParser, MessageParser>()
                .AddTransient<IExtractIp, IpExtractor>()
                .AddTransient<IPortExtractor, PortExtractor>()
                .BuildServiceProvider();

            var fileProcessor = serviceProvider.GetRequiredService<IMessageFileProcessor>();

            fileProcessor.ProcessFile(FilePath);

        }


    }
}
