using System.Collections.Generic;
using ConsoleApp.Models;

namespace ConsoleApp.Services.Interfaces
{
    public interface IParser
    {
        IEnumerable<ImportedObject> Parse(IEnumerable<string> data);
    }
}