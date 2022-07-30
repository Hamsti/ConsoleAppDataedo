using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.BLL.Models;
using ConsoleApp.BLL.Services.Interfaces;

namespace ConsoleApp.BLL.Services
{
    public class DataParser : IParser
    {
        public IEnumerable<ImportedObject> Parse(IEnumerable<string> data)
        {
            var importedObjects = ParseImportedLines(data).ToList();

            ClearImportedObjects(importedObjects);

            AssignChildrenNumber(importedObjects);

            return importedObjects;
        }

        private static void AssignChildrenNumber(IEnumerable<ImportedObject> importedObjects)
        {
            var impObjects = importedObjects.ToArray();

            var childrenObjects = impObjects
                .SelectMany(parentObject => impObjects, (parentObject, childObj) => new { parentObject, childObj })
                .Where(t => t.childObj.ParentType == t.parentObject.Type && t.childObj.ParentName == t.parentObject.Name)
                .Select(t => t.parentObject);

            foreach (var item in childrenObjects)
            {
                item.NumberOfChildren++;
            }
        }

        private static void ClearImportedObjects(IEnumerable<ImportedObject> importedObjects)
        {
            string GetClearString(string input) => input.Trim().Replace(" ", "").Replace(Environment.NewLine, "");

            foreach (var importedObject in importedObjects)
            {
                importedObject.Type = GetClearString(importedObject.Type).ToUpper();
                importedObject.Name = GetClearString(importedObject.Name);
                importedObject.Schema = GetClearString(importedObject.Schema);
                importedObject.ParentName = GetClearString(importedObject.ParentName);
                importedObject.ParentType = GetClearString(importedObject.ParentType);
            }
        }

        private static IEnumerable<ImportedObject> ParseImportedLines(IEnumerable<string> importedLines) =>
            importedLines
                .Select(line => line.Split(';'))
                .Where(values => values.Length >= 7)
                .Select(values => new ImportedObject
                {
                    Type = values[0],
                    Name = values[1],
                    Schema = values[2],
                    ParentName = values[3],
                    ParentType = values[4],
                    DataType = values[5],
                    IsNullable = values[6]
                });
    }
}