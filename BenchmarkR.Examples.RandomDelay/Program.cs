using System;
using System.Threading.Tasks;
using BenchmarkR.Sink.Console;

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
        }
    }
}