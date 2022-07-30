using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Models;
using ConsoleApp.Services.Interfaces;

namespace ConsoleApp.Services
{
    public class ImportedObjectsLogger : ILogger<IEnumerable<ImportedObject>>
    {
        private readonly Action<string> _logAction;
        private IList<ImportedObject> _objectToLog;

        public ImportedObjectsLogger(Action<string> logAction)
        {
            _logAction = logAction;
        }

        public void Log(IEnumerable<ImportedObject> importedObjects)
        {
            _objectToLog = importedObjects.ToList();

            PrintDatabases();
        }

        private void PrintDatabases()
        {
            foreach (var database in _objectToLog.Where(db => db.Type == "DATABASE"))
            {
                _logAction.Invoke($"Database '{database.Name}' ({database.NumberOfChildren} tables)");

                PrintDatabaseTables(database);
            }
        }

        private void PrintDatabaseTables(ImportedObject database)
        {
            foreach (var table in _objectToLog)
            {
                if (table.ParentType.ToUpper() != database.Type || table.ParentName != database.Name)
                {
                    continue;
                }

                _logAction.Invoke($"\tTable '{table.Schema}.{table.Name}' ({table.NumberOfChildren} columns)");

                PrintTableColumns(table);
            }
        }

        private void PrintTableColumns(ImportedObject table)
        {
            foreach (var column in _objectToLog)
            {
                if (column.ParentType.ToUpper() != table.Type || column.ParentName != table.Name) continue;

                _logAction.Invoke(
                    $"\t\tColumn '{column.Name}' with {column.DataType} data type {(column.IsNullable == "1" ? "accepts nulls" : "with no nulls")}");
            }
        }
    }
}