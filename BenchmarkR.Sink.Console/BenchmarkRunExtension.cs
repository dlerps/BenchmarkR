using BenchmarkR.Model;

namespace BenchmarkR.Sink.Console
{
    public static class BenchmarkRunExtension
    {
        private static ConsoleBenchmarkSink ConsoleBenchmarkSink = new ConsoleBenchmarkSink();
        
        public static void WriteToConsole(this BenchmarkRun me)
        {
            ConsoleBenchmarkSink.Write(me);
        }
    }
}