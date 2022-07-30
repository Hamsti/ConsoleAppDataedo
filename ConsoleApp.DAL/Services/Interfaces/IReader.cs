using System.Collections.Generic;

namespace ConsoleApp.DAL.Services.Interfaces
{
    public interface IReader
    {
        IEnumerable<string> ReadAllLines(string path);
    }
}