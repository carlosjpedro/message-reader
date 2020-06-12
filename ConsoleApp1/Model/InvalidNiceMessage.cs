using System.Collections.Generic;

namespace ConsoleApp1.Model
{
    internal class InvalidNiceMessage : NiceMessage
    {
        private List<string> _payload;

        public InvalidNiceMessage(List<string> payload) : base(string.Empty, 0, null)
        {
            _payload = payload;
        }

        public override string ToString()
        {
            return $"Invalid Message with payload: {string.Join('n', _payload)}";
        }
    }
}