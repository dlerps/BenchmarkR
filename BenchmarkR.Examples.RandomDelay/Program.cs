using System;
using System.Threading.Tasks;
using BenchmarkR.Sink.Console;
using BenchmarkR.Sink.MsSql;

namespace BenchmarkR.Examples.RandomDelay
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var benchmark = new RandomDelayBenchmark();
            
            var benchmarkRunner = new BenchmarkRunner(benchmark);
            var benchmarkRun = await benchmarkRunner.Run();

            benchmarkRun.WriteToConsole();
            await benchmarkRun.WriteToMsSql();
        }
    }
}