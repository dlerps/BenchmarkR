using System;
using System.Collections.Generic;

namespace BenchmarkR.Model
{
    public class BenchmarkRun
    {
        public string Name { get; private set; }
        
        public string Comment { get; set; }
        
        public DateTime StartedAt { get; private set; }
        
        public int BatchSize { get; private set; }
        
        public List<BenchmarkResult> BenchmarkResults { get; private set; }

        public int TotalCount => BenchmarkResults.Count;

        public BenchmarkRun(string name, int batchSize, int totalCount)
        {
            Name = name;
            BatchSize = batchSize;
            
            BenchmarkResults = new List<BenchmarkResult>(totalCount);
            StartedAt = DateTime.UtcNow;
        }

        public void AddResults(IEnumerable<BenchmarkResult> results)
        {
            BenchmarkResults.AddRange(results);
        }
    }
}