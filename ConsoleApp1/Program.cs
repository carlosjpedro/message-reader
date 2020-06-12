using ConsoleApp1.Parsing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        const string FilePath = @"C:\Users\Carlos\Desktop\sdp_input huge.txt";
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IMessageFileProcessor, MessageFileProcessor>()
                .AddTransient<IMessageReader, MessageReader>()
                .AddTransient<IMessageWriter, ConsoleMessageWriter>()
                .AddTransient<IMessageParser, MessageParser>()
                .AddTransient<IExtractIp, IpExtractor>()
                .AddTransient<IPortExtractor, PortExtractor>()
                .AddTransient<ICodecExtractor, CodecExtractor>()
                .BuildServiceProvider();

            var fileProcessor = serviceProvider.GetRequiredService<IMessageFileProcessor>();

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            await fileProcessor.ProcessFileAsync(FilePath);
            stopWatch.Stop();
            Console.WriteLine($"Elapsed Time {stopWatch.ElapsedMilliseconds}ms");

        }


    }
}
