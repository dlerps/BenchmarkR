using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BenchmarkR.Sink.MsSql.DbModel.Abstract;

namespace BenchmarkR.Sink.MsSql.DbModel
{
    [Table("Runs")]
    public class BenchmarkRun : BaseEntity
    {
        public string Name { get; set; }
        
        public string Comment { get; set; }
        
        public DateTime StartedAt { get; set; }
        
        public int BatchSize { get; set; }
        
        public int TotalCount { get; set; }
        
        public IList<BenchmarkResult> BenchmarkResults { get; set;  }
    }
}