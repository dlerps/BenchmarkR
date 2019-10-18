using System;
using System.Threading.Tasks;

namespace BenchmarkR.Examples.RandomDelay
{
    public class RandomDelayBenchmark : IBenchmark
    {
        private const int MIN_DELAY = 5;

        private const int MAX_DELAY = 500;
        
        private readonly Random _random;

        public int TotalCount => 100;
        
        public int BatchSize => 4;

        public string Name => "Random Delay Benchmark";

        public RandomDelayBenchmark()
        {
            _random = new Random(DateTime.UtcNow.Millisecond);
        }
        
        public async Task Execute(params string[] args)
        {
            var ms = _random.Next(MIN_DELAY, MAX_DELAY);
            await Task.Delay(ms);
        }
    }
}