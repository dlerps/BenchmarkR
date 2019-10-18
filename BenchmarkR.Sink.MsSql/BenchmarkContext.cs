using System;
using BenchmarkR.Sink.MsSql.DbModel;
using Microsoft.EntityFrameworkCore;

namespace BenchmarkR.Sink.MsSql
{
    public class BenchmarkContext : DbContext
    {
        private static string _connectionString;

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public BenchmarkContext()
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SetConnectionString(
                "Server=localhost;" +
                "Database=benchmarks;" +
                "User Id=sa;" +
                "Password=1234-Axz;"
            );
            
            Console.WriteLine($"Configuring DB with Connection String: {_connectionString}");
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<BenchmarkRun> BenchmarkRuns { get; set; }
        
        public DbSet<BenchmarkResult> BenchmarkResults { get; set; }
    }
}