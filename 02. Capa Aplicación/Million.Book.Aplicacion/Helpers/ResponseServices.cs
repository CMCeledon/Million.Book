using System.Diagnostics.CodeAnalysis;
namespace Million.Book.Aplicacion.Helpers
{
    [ExcludeFromCodeCoverage]
    public class ResponseServices<T>
    {
        public bool State { get; set; }
        public string Message { get; set; }
        public T Info { get; set; }
        public string Type { get; set; }
    }
}