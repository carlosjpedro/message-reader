namespace ConsoleApp1
{
    public class MessageFileProcessor : IMessageFileProcessor
    {
        private readonly IMessageReader _reader;

        private readonly IMessageWriter _writer;

        private readonly IMessageParser _parser;

        public MessageFileProcessor(IMessageReader reader, IMessageWriter writer, IMessageParser parser) {
            _reader = reader;
            _writer = writer;
            _parser = parser;
        }

        public void ProcessFile(string filePath)
        {
            foreach(var messageLines in _reader.ReadMessages(filePath))
            {
                var message = _parser.Parse(messageLines);
                _writer.Write(message);
            }
        }
    }


}
