using System.Collections.Generic;
using System.IO;
using ConsoleApp.Services.Interfaces;

namespace ConsoleApp.Services
{
    public class FileReader : IReader
    {
        public IEnumerable<string> ReadAllLines(string pathToFile)
        {
            var importedLines = new List<string>();

            using (var streamReader = new StreamReader(pathToFile))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();

                    importedLines.Add(line);
                }
            }

            return importedLines;
        }
    }
}