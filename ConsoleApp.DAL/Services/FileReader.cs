using ConsoleApp.DAL.Services.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp.DAL.Services
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

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    importedLines.Add(line);
                }
            }

            return importedLines;
        }
    }
}