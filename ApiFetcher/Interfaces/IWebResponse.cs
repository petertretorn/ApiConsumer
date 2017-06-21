
namespace ApiFetcher.Interfaces
{
    public interface IWebResponse<T>
    {
        T[] Data { get; set; }
    }
}
