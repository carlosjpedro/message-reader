using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IMessageFileProcessor
    {
        Task ProcessFileAsync(string filePath);

    }


}
