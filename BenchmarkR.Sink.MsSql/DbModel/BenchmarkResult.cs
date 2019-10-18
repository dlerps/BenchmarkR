using System;
using System.ComponentModel.DataAnnotations.Schema;
using BenchmarkR.Sink.MsSql.DbModel.Abstract;

namespace BenchmarkR.Sink.MsSql.DbModel
{
    [Table("Results")]
    public class BenchmarkResult : BaseEntity
    {
        public Guid BenchmarkRunId { get; set; }
        
        public BenchmarkRun BenchmarkRun { get; set; }
        
        public double Milliseconds { get; set; }
    }
}