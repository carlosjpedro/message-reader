using System.Collections.Generic;

namespace ConsoleApp1
{

    public interface IMessageParser
    {
        NiceMessage Parse(List<string> messageLines);
    }


}
