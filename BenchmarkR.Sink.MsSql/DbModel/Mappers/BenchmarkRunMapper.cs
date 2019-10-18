using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable PossibleMultipleEnumeration

namespace BenchmarkR.Sink.MsSql.DbModel.Mappers
{
    public class BenchmarkRunMapper
    {
        public BenchmarkRun Map(Model.BenchmarkRun @in)
        {
            var id = Guid.NewGuid();
            var results = MapResults(@in.BenchmarkResults);

            foreach (var result in results)
            {
                result.BenchmarkRunId = id;
            }
            
            return new BenchmarkRun()
            {
                Id = id,
                Comment = @in.Comment,
                Name = @in.Name,
                BatchSize = @in.BatchSize,
                StartedAt = @in.StartedAt,
                TotalCount = @in.TotalCount
            };
        }

        private IList<BenchmarkResult> MapResults(IEnumerable<Model.BenchmarkResult> results)
        {
            var @out = new List<BenchmarkResult>(results.Count());

            foreach (var result in results)
            {
                @out.Add(MapResult(result));
            }

            return @out;
        }

        private BenchmarkResult MapResult(Model.BenchmarkResult result)
        {
            return new BenchmarkResult()
            {
                Id = Guid.NewGuid(),
                Milliseconds = result.Milliseconds
            };
        }
    }
}