# ConsoleAppDataedo

### Oleg Belous, some comments

- Remove unnecessary using directives anywhere and move them outside of namespace
- Remove properties, which is never used (useless code)
- Move classes to separate files
- Before of refactoring code, write tests, that’s cover all your logic
- Dispose used unmanaged resources (e.g. Stream) 
- Use explicit access modifiers (like 12 line of `DataReader`, use private)
- Too many instructions in one method, therefore and multiply responsibility of it, like supermethod (-class). Instead of adding comments, move this logic to different services or private methods with name, which clearly describe reasonability of it.
- Code formatting, naming of variables, private fields
- Use properties instead of public fields.
- Reduce nesting of conditions and cycles.
- Try to use LINQ methods
- Move `ImportedObject` and `ImportedObjectBaseClass` to Models folder
- Move `DataReader` to folder Services inside of which, create specific name of even move it to differ layer
