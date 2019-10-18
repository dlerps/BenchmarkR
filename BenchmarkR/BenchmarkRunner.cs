using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using BenchmarkR.Exceptions;
using BenchmarkR.Model;
using BenchmarkR.Validation;

namespace BenchmarkR
{
    public class BenchmarkRunner
    {
        private static readonly BenchmarkValidator _benchmarkValidator = new BenchmarkValidator();
        
        private readonly IBenchmark _benchmark;

        private int _count;

        public BenchmarkRunner(IBenchmark benchmark)
        {
            ValidateBenchmark(benchmark);
            _benchmark = benchmark;
            _count = 0;
        }

        public async Task<BenchmarkRun> Run()
        {
            var benchmarkRun = new BenchmarkRun(
                _benchmark.GetType().Name,
                _benchmark.BatchSize,
                _benchmark.TotalCount
            );

            do
            {
                var batchTasks = PrepareBatch();
                var results = await Task.WhenAll(batchTasks);

                _count += results.Length;

                benchmarkRun.AddResults(results);
            } while (_benchmark.TotalCount > _count);

            return benchmarkRun;
        }

        private IList<Task<BenchmarkResult>> PrepareBatch()
        {
            var left = _benchmark.TotalCount - _count;
            var sizeOfBatch = Math.Min(left, _benchmark.BatchSize);
            var batch = new List<Task<BenchmarkResult>>(sizeOfBatch);

            do
            {
                batch.Add(
                    Task.Run(
                        () => ExecuteBenchmarkTask(() => _benchmark.Execute())
                    )
                );
            } while (--sizeOfBatch > 0);

            return batch;
        }

        private async Task<BenchmarkResult> ExecuteBenchmarkTask(Func<Task> execute)
        {
            var benchmarkResult = new BenchmarkResult();
            var benchmarkStopwatch = Stopwatch.StartNew();

            try
            {
                await execute();
                benchmarkResult.Successful = true;
            }
            catch (Exception e)
            {
                benchmarkResult.ExceptionType = e.GetType().Name;
                benchmarkResult.Successful = false;
            }
            
            benchmarkStopwatch.Stop();
            benchmarkResult.Milliseconds = benchmarkStopwatch.ElapsedMilliseconds;

            return benchmarkResult;
        }

        private void ValidateBenchmark(IBenchmark benchmark)
        {
            var validationResult = _benchmarkValidator.Validate(benchmark);

            if (validationResult.IsValid)
                return;

            throw BenchmarkConfigurationException.FromValidationResult(validationResult);
        }
    }
}