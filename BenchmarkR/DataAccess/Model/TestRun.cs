using System;
using System.ComponentModel.DataAnnotations.Schema;
using BenchmarkR.DataAccess.Model.Abstract;

namespace BenchmarkR.DataAccess.Model
{
    [Table("TestRuns")]
    public class TestRun : BaseEntity
    {
        public string Name { get; set; }
        
        public DateTime Timestamp { get; set; }
    }
}