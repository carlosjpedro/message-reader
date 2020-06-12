using System.Collections.Generic;

namespace ConsoleApp1.Parsing
{

    public interface IMessageParser
    {
        NiceMessage Parse(List<string> messageLines);
    }


}
