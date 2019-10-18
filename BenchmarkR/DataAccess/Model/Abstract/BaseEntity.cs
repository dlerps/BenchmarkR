using System;
using System.ComponentModel.DataAnnotations;

namespace BenchmarkR.DataAccess.Model.Abstract
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}