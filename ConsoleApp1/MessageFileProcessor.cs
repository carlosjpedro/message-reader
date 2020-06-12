namespace ConsoleApp1
{
    public class MessageFileProcessor : IMessageFileProcessor
    {
        private readonly IMessageReader _reader;

        public IMessageWriter _writer { get; }

        public MessageFileProcessor(IMessageReader reader, IMessageWriter writer) {
            _reader = reader;
            _writer = writer;
        }

        public void ProcessFile(string filePath)
        {
            foreach(var message in _reader.ReadMessages(filePath))
            {
                _writer.Write(message);
            }
        }
    }


}
