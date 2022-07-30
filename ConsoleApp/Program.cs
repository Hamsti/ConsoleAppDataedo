using ConsoleApp.BLL.Services;
using ConsoleApp.DAL.Services;
using System;

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
