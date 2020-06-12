using ConsoleApp1.Model;
using ConsoleApp1.Parsing;
using ConsoleApp1.Reading;
using ConsoleApp1.Writing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MessageFileProcessor : IMessageFileProcessor
    {
        private readonly IMessageReader _reader;

        private readonly IMessageWriter _writer;

        private readonly IMessageParser _parser;

        public MessageFileProcessor(IMessageReader reader, IMessageWriter writer, IMessageParser parser)
        {
            _reader = reader;
            _writer = writer;
            _parser = parser;
        }

        public async Task ProcessFileAsync(string filePath)
        {
            var messageLines = _reader.ReadMessagesAsync(filePath).GetAsyncEnumerator();
            var tasks = new List<Task<NiceMessage>>();

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            while (await messageLines.MoveNextAsync())
            {

                tasks.Add(Task.Run(() => _parser.Parse(messageLines.Current)));
            }

            await Task.WhenAll(tasks.ToArray());

            stopWatch.Stop();
            Console.WriteLine($"Elapsed Time {stopWatch.ElapsedMilliseconds}ms");
            //await Task.Delay(15000);
            //foreach (var task in tasks)
            //{
            //    _writer.Write(task.Result);
            //}


        }
    }
}
