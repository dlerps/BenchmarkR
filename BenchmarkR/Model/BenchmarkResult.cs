using System;

namespace BenchmarkR.Model
{
    public class BenchmarkResult
    {
        public double Milliseconds { get; internal set; }

        public bool Successful { get; internal set; }
        
        public string ExceptionType { get; internal set; }
    }
}