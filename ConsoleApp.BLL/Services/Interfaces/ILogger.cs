namespace ConsoleApp.BLL.Services.Interfaces
{
    public interface ILogger<in T>
    {
        void Log(T message);
    }
}