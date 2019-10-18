using System;
using System.Threading.Tasks;
using BenchmarkR.Model;

namespace BenchmarkR.Sink.Console
{
    public class ConsoleBenchmarkSink : IBenchmarkSink
    {
        public Task Write(BenchmarkRun benchmarkRun)
        {
            var outputCount = 0;
            
            foreach (var result in benchmarkRun.BenchmarkResults)
            {
                var success = result.Successful ? "successful" : "FAILED!";

                System.Console.WriteLine(
                    $"{++outputCount}: {result.Milliseconds} ms  |  {success}"
                );
            }

            return Task.CompletedTask;
        }
    }
}