using System.Threading.Tasks;
using BenchmarkR.Model;

namespace BenchmarkR.Sink.MsSql
{
    public static class BenchmarkRunExtensions
    {
        public static async Task WriteToMsSql(this BenchmarkRun me)
        {
            var sink = new MsSqlBenchmarkSink();
            await sink.Write(me);
        }
    }
}