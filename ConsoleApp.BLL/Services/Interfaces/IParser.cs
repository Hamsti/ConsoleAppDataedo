using System.Collections.Generic;
using ConsoleApp.BLL.Models;

namespace ConsoleApp.BLL.Services.Interfaces
{
    public interface IParser
    {
        IEnumerable<ImportedObject> Parse(IEnumerable<string> data);
    }
}