using System.Collections.Generic;

namespace ConsoleApp.Services.Interfaces
{
    public interface IReader
    {
        IEnumerable<string> ReadAllLines(string path);
    }
}