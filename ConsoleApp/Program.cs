using System;
using ConsoleApp.Services;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            var importedLines = new FileReader().ReadAllLines("Data/data.csv");

            var parsedData = new DataParser().Parse(importedLines);

            var logger = new ImportedObjectsLogger(Console.WriteLine);

            logger.Log(parsedData);

            Console.ReadLine();
        }
    }
}
