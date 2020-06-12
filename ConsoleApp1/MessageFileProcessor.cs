using ConsoleApp1.Parsing;
using ConsoleApp1.Reading;
using ConsoleApp1.Writing;
using System.Collections.Generic;
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
            var messageLines =_reader.ReadMessagesAsync(filePath).GetAsyncEnumerator();

            while (await messageLines.MoveNextAsync())
            {
                var message = await Task.Run(() => _parser.Parse(messageLines.Current));
                _writer.Write(message);
            }

        }
    }
}
