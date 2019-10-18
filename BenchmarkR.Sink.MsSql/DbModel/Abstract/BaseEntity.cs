using System;
using System.ComponentModel.DataAnnotations;

namespace BenchmarkR.Sink.MsSql.DbModel.Abstract
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}