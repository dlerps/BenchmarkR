using System.Threading.Tasks;
using BenchmarkR.Model;

namespace BenchmarkR
{
    public interface IBenchmark
    {
        int TotalCount { get; }
        
        int BatchSize { get; }

        string Name { get; }
        
        Task Execute(params string[] args);
    }
}