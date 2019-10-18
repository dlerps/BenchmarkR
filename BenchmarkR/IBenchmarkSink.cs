using System.Threading.Tasks;
using BenchmarkR.Model;

namespace BenchmarkR
{
    public interface IBenchmarkSink
    {
        Task Write(BenchmarkRun benchmarkRun);
    }
}