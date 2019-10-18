using System.Threading.Tasks;
using BenchmarkR.Sink.MsSql.DbModel.Mappers;

namespace BenchmarkR.Sink.MsSql
{
    public class MsSqlBenchmarkSink : IBenchmarkSink
    {
        public async Task Write(Model.BenchmarkRun @in)
        {
            var mapper = new BenchmarkRunMapper();
            var benchmarkRun = mapper.Map(@in);

            using (var dbContext = new BenchmarkContext())
            {
                await dbContext.BenchmarkRuns.AddAsync(benchmarkRun);
                //await dbContext.BenchmarkResults.AddRangeAsync(benchmarkRun.BenchmarkResults);
                
                await dbContext.SaveChangesAsync();
            }
        }
    }
}